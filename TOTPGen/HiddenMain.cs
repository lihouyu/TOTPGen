/**
 * No License Applied.
 * Can be used freely.
 *
 * HouYu Li <lihouyu (at) phpex.net> 2015/9/30 18:51
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace TOTPGen
{
    /// <summary>
    /// The main form always hidden
    /// </summary>
    public partial class HiddenMain : Form
    {
        private readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly string _sTOTPSectionName = "TOTPSecret";
        private readonly string _sSecretProtect = "RsaProtectedConfigurationProvider";
        private readonly string _sConfPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\.TOTPGen\";
        
        private Configuration _confApp;
        private TOTP_Secret _TOTPSecret;
        private TOTP_SecretInfoCollection _TOTPAccounts;
        private SetSecretForm _frmAddAcct;
        
        private string _sCurrAcctID = "";
        private DialogResult _rsDialog = DialogResult.Cancel;
        
        public HiddenMain()
        {
            this.Hide();
            
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
           
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            // Prepare the configuration file path
            if (! Directory.Exists(this._sConfPath)) {
                DirectoryInfo confDirInfo = Directory.CreateDirectory(this._sConfPath);
                confDirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            // The config file map
            ExeConfigurationFileMap confFileMap = new ExeConfigurationFileMap();
            confFileMap.ExeConfigFilename = this._sConfPath + "totp.config";
            
            // Prepare related objects
            this._confApp = ConfigurationManager.OpenMappedExeConfiguration(confFileMap, ConfigurationUserLevel.None);
            this._TOTPSecret = (TOTP_Secret)this._confApp.GetSection(this._sTOTPSectionName);
            if (null == this._TOTPSecret) {
                this._TOTPSecret = new TOTP_Secret();
                this._confApp.Sections.Add(this._sTOTPSectionName, this._TOTPSecret);
                
                this._TOTPSecret.SectionInformation.ProtectSection(this._sSecretProtect);
                this._TOTPSecret.SectionInformation.ForceSave = true;
    
                this._confApp.Save(ConfigurationSaveMode.Full, true);
            }
            this._TOTPAccounts = this._TOTPSecret.TOTPAccounts;
            if (this._TOTPAccounts.Count == 0) {
                this.AddNewAcct(null, null);
            }
            
            // Load accounts in menu
            for (int i = 0; i < this._TOTPAccounts.Count; i++) {
                this._TOTPAccounts[i].MenuItem = this.CreateAcctMenu(this._TOTPAccounts[i].ID);
                
                this.msTrayIcon.Items.Insert(i+1, 
                                            this._TOTPAccounts[i].MenuItem);
            }
                        
            // Tooltip
            this.trayIcon.ShowBalloonTip(5000);
            
            // Start timer
            this.timer1.Start();
        }
        
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void Timer1Tick(object sender, EventArgs e)
        {
            long lTimeDiff = (long)(DateTime.UtcNow - this.UNIX_EPOCH).TotalSeconds;
            long lCounter =  lTimeDiff / 30;
            long lSecToGo = lTimeDiff % 30;
            string sCopyTxt = "";
            string sMyCode = "";
            Color cMyColor = Color.Black;
            
            if (lSecToGo == 0) {
                Clipboard.Clear();
            }
            if (lSecToGo < 4 || lSecToGo > 26) {
                cMyColor = Color.Red;
            } else {
                cMyColor = Color.Black;
            }
            sCopyTxt = "Copy Code (" + (30 - lSecToGo).ToString() + " s)";
            
            for (int i = 0; i < this._TOTPAccounts.Count; i++) {
                sMyCode = TOTP_GA.GeneratePassword(this._TOTPAccounts[i].Key, lCounter, this._TOTPAccounts[i].CodeLen);
                this._TOTPAccounts[i].MenuItem.DropDown.Items[0].Text = sMyCode;
                this._TOTPAccounts[i].MenuItem.DropDown.Items[0].ForeColor = cMyColor;
                this._TOTPAccounts[i].MenuItem.DropDown.Items[1].Text = sCopyTxt;
            }
        }
        
        private void AddNewAcct(object sender, EventArgs e)
        {
            int iHasError = 1;
            
            if (null != this._frmAddAcct) {
                if (! this._frmAddAcct.IsDisposed)
                    return;
            }
            
            TOTP_SecretInfo csTOTPSecret = new TOTP_SecretInfo();
            
            // Config the first newly created account
            this._frmAddAcct = new SetSecretForm(this);
            
            while (iHasError == 1) {
                this._frmAddAcct.ShowDialog();
                
                if (this._rsDialog != DialogResult.Cancel) {
                    csTOTPSecret.ID = this._frmAddAcct.GetAcctID();
                    
                    if (null != this._TOTPAccounts.FindByID(csTOTPSecret.ID)) {
                        // Account name duplicate
                        this._frmAddAcct.SetErrTxt("Account Name exists!");
                    } else {
                        csTOTPSecret.Key = this._frmAddAcct.GetSecretText();
                        csTOTPSecret.CodeLen = Convert.ToInt32(this._frmAddAcct.GetCodeLen());
                        
                        this._frmAddAcct.Dispose();
            
                        this._TOTPAccounts.Add(csTOTPSecret);
                        
                        this._confApp.Save(ConfigurationSaveMode.Full, true);
                        
                        // Add account menu item
                        int iAcctCnt = this._TOTPAccounts.Count;
                        
                        this._TOTPAccounts[iAcctCnt - 1].MenuItem = this.CreateAcctMenu(csTOTPSecret.ID);
                        
                        this.msTrayIcon.Items.Insert(iAcctCnt, 
                                                    this._TOTPAccounts[iAcctCnt - 1].MenuItem);
                        //
                        
                        iHasError = 0;
                    }
                } else {
                    // Form closed
                    iHasError = 0;
                    this._frmAddAcct.Dispose();
                }
            }
        }
        
        private ToolStripMenuItem CreateAcctMenu(string AcctID) {
            ToolStripMenuItem tsAcct = new ToolStripMenuItem(AcctID);
            
            ContextMenuStrip tsAcctDrop = new ContextMenuStrip();
            tsAcctDrop.Items.Add("------");
            tsAcctDrop.Items.Add("Copy Code");
            tsAcctDrop.Items.Add("Edit");
            tsAcctDrop.Items.Add("Remove");
            tsAcctDrop.Items.Add(AcctID);
            
            tsAcctDrop.Items[0].Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            tsAcctDrop.Items[1].Click += new System.EventHandler(this.CopyCode);
            tsAcctDrop.Items[2].Click += new System.EventHandler(this.EditAcct);
            tsAcctDrop.Items[3].Click += new System.EventHandler(this.RemoveAcct);
            tsAcctDrop.Items[4].Visible = false;
            
            tsAcct.DropDown = tsAcctDrop;
            
            return tsAcct;
        }
        
        private void CopyCode(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(((ToolStripMenuItem)sender).Owner.Items[0].Text);
        }
        
        private void EditAcct(object sender, EventArgs e)
        {
            TOTP_SecretInfo thisAcct;
            
            int iHasError = 1;
            
            this._sCurrAcctID = ((ToolStripMenuItem)sender).Owner.Items[4].Text;
            thisAcct = this._TOTPAccounts.FindByID(this._sCurrAcctID);
            if (null == thisAcct) {
                this._sCurrAcctID = "";
                MessageBox.Show("Account not found!", "Error");
                return;
            }
            
            if (null != this._frmAddAcct) {
                if (! this._frmAddAcct.IsDisposed) {
                    this._sCurrAcctID = "";
                    return;
                }
            }

            this._frmAddAcct = new SetSecretForm(this);
            this._frmAddAcct.SetAcctID(thisAcct.ID);
            this._frmAddAcct.SetSecretText(thisAcct.Key);
            this._frmAddAcct.SetCodeLen(thisAcct.CodeLen.ToString());

            while (iHasError == 1) {
                this._frmAddAcct.ShowDialog();
                
                if (this._rsDialog != DialogResult.Cancel) {
                    thisAcct.ID = this._frmAddAcct.GetAcctID();
                    thisAcct.Key = this._frmAddAcct.GetSecretText();
                    thisAcct.CodeLen = Convert.ToInt32(this._frmAddAcct.GetCodeLen());
                    
                    this._frmAddAcct.Dispose();
        
                    this._confApp.Save(ConfigurationSaveMode.Full, true);
                    
                    // Update the hidden account ID
                    ((ToolStripMenuItem)sender).Owner.Items[4].Text = thisAcct.ID;
                    // Update the account menu item name
                    for (int i = 0; i < this.msTrayIcon.Items.Count; i++) {
                        if (this.msTrayIcon.Items[i].Text == this._sCurrAcctID) {
                            this.msTrayIcon.Items[i].Text = thisAcct.ID;
                            break;
                        }
                    }
                    
                    
                    iHasError = 0;
                } else {
                    // Form closed
                    iHasError = 0;
                    this._frmAddAcct.Dispose();
                }
            }
            
            this._sCurrAcctID = "";
        }
        
        private void RemoveAcct(object sender, EventArgs e)
        {
            TOTP_SecretInfo thisAcct;
            
            DialogResult rsDialog;
            bool bRemoved;
            
            this._sCurrAcctID = ((ToolStripMenuItem)sender).Owner.Items[4].Text;
            thisAcct = this._TOTPAccounts.FindByID(this._sCurrAcctID);
            if (null == thisAcct) {
                this._sCurrAcctID = "";
                MessageBox.Show("Account not found!", "Error");
                return;
            }
            
            rsDialog = MessageBox.Show("Are you sure to remove account \"" + this._sCurrAcctID + "\" ?",
                                       "Warning", MessageBoxButtons.OKCancel);
            if (rsDialog == DialogResult.OK) {
                bRemoved = this._TOTPAccounts.RemoveByID(this._sCurrAcctID);
                if (!bRemoved) {
                    this._sCurrAcctID = "";
                    MessageBox.Show("Remove account failed!", "Error");
                    return;
                } else {
                    // Account removed, save configuration
                    this._confApp.Save(ConfigurationSaveMode.Full, true);
                    
                    // Remove menu item
                    for (int i = 0; i < this.msTrayIcon.Items.Count; i++) {
                        if (this.msTrayIcon.Items[i].Text == this._sCurrAcctID) {
                            this.msTrayIcon.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            this._sCurrAcctID = "";
        }
        
        public void SetDialogRs(DialogResult rs)
        {
            this._rsDialog = rs;
        }
        
        void CreditToolStripMenuItemClick(object sender, EventArgs e)
        {
            MessageBox.Show("Mainly by HouYu Li <lihouyu@phpex.net>", "Hello!", MessageBoxButtons.OK);
        }
    }
}

/**
 * No License Applied.
 * Can be used freely.
 *
 * HouYu Li <lihouyu (at) phpex.net> 2015/9/29 16:06
 */
using System;
using System.Windows.Forms;

namespace TOTPGen
{
    /// <summary>
    /// Account setup form
    /// </summary>
    public partial class SetSecretForm : Form
    {
        private HiddenMain _mainForm;
        
        public SetSecretForm(HiddenMain frm)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            this._mainForm = frm;
            this._mainForm.SetDialogRs(DialogResult.Cancel);
        }
        
        public void SetSecretText(string sSecret) {
            this.txtSecret.Text = sSecret;
        }
        
        public string GetSecretText() {
            return this.txtSecret.Text;
        }
        
        public void SetAcctID(string sAcctID) {
            this.txtAcctID.Text = sAcctID;
        }
        
        public string GetAcctID() {
            return this.txtAcctID.Text;
        }
        
        public void SetCodeLen(string sCodeLen) {
            this.numCodeLen.Value = Convert.ToInt32(sCodeLen);
        }
        
        public string GetCodeLen() {
            return this.numCodeLen.Value.ToString();
        }
        
        public void SetErrTxt(string sErrTxt) {
            this.toolStripStatusError.Text = sErrTxt;
        }
        
        void TxtSecretEnter(object sender, EventArgs e)
        {
            if (this.txtSecret.Text == TOTP_GA.DummySecret)
                this.txtSecret.Text = "";
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            if (this.ValidateInput()) {
                this.toolStripStatusError.Text = "";
                this._mainForm.SetDialogRs(DialogResult.OK);
                this.Hide();
            }
        }
        
        void TxtSecretKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                if (this.ValidateInput()) {
                    this.toolStripStatusError.Text = "";
                    this._mainForm.SetDialogRs(DialogResult.OK);
                    this.Hide();
                }
            }
        }
        
        private bool ValidateInput() {
            if (this.txtAcctID.Text.Trim().Length == 0) {
                this.toolStripStatusError.Text = "Account Name cannot be empty!";
                return false;
            }
            if (this.txtSecret.Text == TOTP_GA.DummySecret || this.txtSecret.Text.Trim().Length == 0 || this.txtSecret.Text.Trim().Length % 8 != 0) {
                this.toolStripStatusError.Text = "Invalid Secret Key!";
                return false;
            }
            return true;
        }

    }
}

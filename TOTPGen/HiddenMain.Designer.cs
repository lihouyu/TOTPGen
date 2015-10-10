/**
 * No License Applied.
 * Can be used freely.
 *
 * HouYu Li <lihouyu (at) phpex.net> 2015/9/30 18:51
 */
namespace TOTPGen
{
    partial class HiddenMain
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip msTrayIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem setSecretKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem creditToolStripMenuItem;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HiddenMain));
            this.msTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setSecretKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.creditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTrayIcon
            // 
            this.msTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.toolStripSeparator2,
            this.setSecretKeyToolStripMenuItem,
            this.toolStripSeparator1,
            this.creditToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.msTrayIcon.Name = "msTrayIcon";
            this.msTrayIcon.Size = new System.Drawing.Size(153, 126);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Enabled = false;
            this.accountsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // setSecretKeyToolStripMenuItem
            // 
            this.setSecretKeyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setSecretKeyToolStripMenuItem.Name = "setSecretKeyToolStripMenuItem";
            this.setSecretKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setSecretKeyToolStripMenuItem.Text = "Add Account";
            this.setSecretKeyToolStripMenuItem.Click += new System.EventHandler(this.AddNewAcct);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Access TOTP Generator Here :)";
            this.trayIcon.BalloonTipTitle = "2FA TOTP Key Generator";
            this.trayIcon.ContextMenuStrip = this.msTrayIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "2FA TOTP Key Gen";
            this.trayIcon.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // creditToolStripMenuItem
            // 
            this.creditToolStripMenuItem.Name = "creditToolStripMenuItem";
            this.creditToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.creditToolStripMenuItem.Text = "Credit";
            this.creditToolStripMenuItem.Click += new System.EventHandler(this.CreditToolStripMenuItemClick);
            // 
            // HiddenMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HiddenMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hidden";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.msTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

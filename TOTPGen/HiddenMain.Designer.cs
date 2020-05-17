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
            this.creditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.msTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTrayIcon
            // 
            resources.ApplyResources(this.msTrayIcon, "msTrayIcon");
            this.msTrayIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.toolStripSeparator2,
            this.setSecretKeyToolStripMenuItem,
            this.toolStripSeparator1,
            this.creditToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.msTrayIcon.Name = "msTrayIcon";
            // 
            // accountsToolStripMenuItem
            // 
            resources.ApplyResources(this.accountsToolStripMenuItem, "accountsToolStripMenuItem");
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // setSecretKeyToolStripMenuItem
            // 
            this.setSecretKeyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setSecretKeyToolStripMenuItem.Name = "setSecretKeyToolStripMenuItem";
            resources.ApplyResources(this.setSecretKeyToolStripMenuItem, "setSecretKeyToolStripMenuItem");
            this.setSecretKeyToolStripMenuItem.Click += new System.EventHandler(this.AddNewAcct);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // creditToolStripMenuItem
            // 
            this.creditToolStripMenuItem.Name = "creditToolStripMenuItem";
            resources.ApplyResources(this.creditToolStripMenuItem, "creditToolStripMenuItem");
            this.creditToolStripMenuItem.Click += new System.EventHandler(this.CreditToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.ContextMenuStrip = this.msTrayIcon;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // HiddenMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HiddenMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.msTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

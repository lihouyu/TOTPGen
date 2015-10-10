/**
 * No License Applied.
 * Can be used freely.
 *
 * HouYu Li <lihouyu (at) phpex.net> 2015/9/29 16:06
 */
namespace TOTPGen
{
    partial class SetSecretForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcctID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodeLen;
        private System.Windows.Forms.Label txtError;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSecretForm));
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcctID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodeLen = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(118, 38);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.PasswordChar = '#';
            this.txtSecret.Size = new System.Drawing.Size(159, 22);
            this.txtSecret.TabIndex = 1;
            this.txtSecret.Enter += new System.EventHandler(this.TxtSecretEnter);
            this.txtSecret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSecretKeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 99;
            this.label1.Text = "Secret Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 99;
            this.label2.Text = "Account Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAcctID
            // 
            this.txtAcctID.Location = new System.Drawing.Point(118, 10);
            this.txtAcctID.Name = "txtAcctID";
            this.txtAcctID.Size = new System.Drawing.Size(159, 22);
            this.txtAcctID.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 99;
            this.label3.Text = "Code Length:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodeLen
            // 
            this.txtCodeLen.Location = new System.Drawing.Point(118, 66);
            this.txtCodeLen.Name = "txtCodeLen";
            this.txtCodeLen.Size = new System.Drawing.Size(78, 22);
            this.txtCodeLen.TabIndex = 2;
            this.txtCodeLen.Text = "6";
            // 
            // txtError
            // 
            this.txtError.ForeColor = System.Drawing.Color.Red;
            this.txtError.Location = new System.Drawing.Point(14, 99);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(263, 23);
            this.txtError.TabIndex = 100;
            this.txtError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetSecretForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 131);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.txtCodeLen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAcctID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSecret);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSecretForm";
            this.Text = "Setup Account";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

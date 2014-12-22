namespace deskbugz
{
    partial class LoginDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.siteEditText = new System.Windows.Forms.TextBox();
            this.siteLabel = new System.Windows.Forms.Label();
            this.emailEditText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordEditText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.fogbugzcomLabel = new System.Windows.Forms.Label();
            this.httpSiteLabel = new System.Windows.Forms.Label();
            this.logonBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(235, 197);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(81, 29);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // siteEditText
            // 
            this.siteEditText.Location = new System.Drawing.Point(184, 42);
            this.siteEditText.Name = "siteEditText";
            this.siteEditText.Size = new System.Drawing.Size(181, 20);
            this.siteEditText.TabIndex = 1;
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(73, 45);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(28, 13);
            this.siteLabel.TabIndex = 2;
            this.siteLabel.Text = "Site:";
            // 
            // emailEditText
            // 
            this.emailEditText.Location = new System.Drawing.Point(143, 80);
            this.emailEditText.Name = "emailEditText";
            this.emailEditText.Size = new System.Drawing.Size(253, 20);
            this.emailEditText.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(76, 80);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            // 
            // passwordEditText
            // 
            this.passwordEditText.Location = new System.Drawing.Point(184, 118);
            this.passwordEditText.Name = "passwordEditText";
            this.passwordEditText.Size = new System.Drawing.Size(181, 20);
            this.passwordEditText.TabIndex = 5;
            this.passwordEditText.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(79, 124);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password";
            // 
            // fogbugzcomLabel
            // 
            this.fogbugzcomLabel.AutoSize = true;
            this.fogbugzcomLabel.Location = new System.Drawing.Point(371, 45);
            this.fogbugzcomLabel.Name = "fogbugzcomLabel";
            this.fogbugzcomLabel.Size = new System.Drawing.Size(71, 13);
            this.fogbugzcomLabel.TabIndex = 7;
            this.fogbugzcomLabel.Text = ".fogbugz.com";
            // 
            // httpSiteLabel
            // 
            this.httpSiteLabel.AutoSize = true;
            this.httpSiteLabel.Location = new System.Drawing.Point(140, 45);
            this.httpSiteLabel.Name = "httpSiteLabel";
            this.httpSiteLabel.Size = new System.Drawing.Size(38, 13);
            this.httpSiteLabel.TabIndex = 8;
            this.httpSiteLabel.Text = "http://";
            // 
            // logonBackgroundWorker
            // 
            this.logonBackgroundWorker.WorkerReportsProgress = true;
            this.logonBackgroundWorker.WorkerSupportsCancellation = true;
            this.logonBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.logonBackgroundWorker_DoWork);
            this.logonBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.logonBackgroundWorker_RunWorkerCompleted);
            // 
            // LoginDlg
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 238);
            this.Controls.Add(this.httpSiteLabel);
            this.Controls.Add(this.fogbugzcomLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordEditText);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailEditText);
            this.Controls.Add(this.siteLabel);
            this.Controls.Add(this.siteEditText);
            this.Controls.Add(this.connectButton);
            this.Name = "LoginDlg";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox siteEditText;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.TextBox emailEditText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox passwordEditText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label fogbugzcomLabel;
        private System.Windows.Forms.Label httpSiteLabel;
        private System.ComponentModel.BackgroundWorker logonBackgroundWorker;
    }
}
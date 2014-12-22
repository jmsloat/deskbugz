using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deskbugz
{
    public partial class LoginDlg : Form
    {
        private FBXml api;
        private bool connectionSuccess = false;
        public LoginDlg(FBXml xmlApi)
        {
            this.api = xmlApi;
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            logonBackgroundWorker.RunWorkerAsync();
        }

        private void logonBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder urlStringBuilder = new StringBuilder();
            urlStringBuilder.Append(this.httpSiteLabel.Text);
            urlStringBuilder.Append(this.siteEditText.Text);
            urlStringBuilder.Append(this.fogbugzcomLabel.Text);
            string url = urlStringBuilder.ToString();
            string email = this.emailEditText.Text;
            string password = this.passwordEditText.Text;
            connectionSuccess = api.connect(url, email, password);
            
        }

        private void logonBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Console.WriteLine("Logon worker completed running");
            if(connectionSuccess)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Abort; // which one is proper?
        }
    }
}

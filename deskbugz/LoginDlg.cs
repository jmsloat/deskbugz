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
        public LoginDlg(FBXml xmlApi)
        {
            this.api = xmlApi;
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            StringBuilder urlStringBuilder = new StringBuilder();
            urlStringBuilder.Append(this.httpSiteLabel.Text);
            urlStringBuilder.Append(this.siteEditText.Text);
            urlStringBuilder.Append(this.fogbugzcomLabel.Text);
            string url = urlStringBuilder.ToString();
            string email = this.emailEditText.Text;
            string password = this.passwordEditText.Text;
            if (api.connect(url, email, password))
            {
                this.DialogResult = DialogResult.OK;
            }
                
            else
                this.DialogResult = DialogResult.Abort; // which one is proper?
        }
    }
}

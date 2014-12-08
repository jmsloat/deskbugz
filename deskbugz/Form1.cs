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
    public partial class deskBugzMainWindow : Form
    {
        private FBXml xmlApi = new FBXml();

        public deskBugzMainWindow()
        {
            InitializeComponent();
            this.testConnectToolStripMenuItem.Click += new EventHandler(testConnectToolStripMenuItem_Click);
            LoginDlg loginDlg = new LoginDlg(xmlApi);

            bool run = true;
            while(run)
            {
                DialogResult res = loginDlg.ShowDialog();
                if (res == DialogResult.OK)
                    run = false;
                else if (res == DialogResult.Cancel)
                    run = false;
            }
            //else
            
            loginDlg.Dispose();
        }

        public void testConnect()
        {
            string url = "https://sloatapitest.fogbugz.com";
            string username = "sloatthrowaway@gmail.com";
            string pass = "samson27";

            if(xmlApi.connect(url, username, pass))
            {
                System.Console.WriteLine("Connect Successful");
            }
            else
                System.Console.WriteLine("Connect Failed...");
            
            //xmlApi.connect();
        }

        private void testConnectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Clicked!");
            this.testConnect();
            xmlApi.getFilters();
        }
    }
}

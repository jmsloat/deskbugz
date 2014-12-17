﻿using System;
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

            //check application settings for token - so we don't have to login again
            string token = Properties.Settings.Default.token;
            string site = Properties.Settings.Default.site;

            if (token == "")
            {
                LoginDlg loginDlg = new LoginDlg(xmlApi);

                bool run = true;
                while (run)
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
        }
    }
}

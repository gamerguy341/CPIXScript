using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CustomItems.CMDUtils;

namespace WindowsFormsApplication1
{
    public partial class FixVuln : Form
    {
        public FixVuln()
        {
            InitializeComponent();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            List<string> code = new List<string>();

            if (treeView1.Nodes["TlFTP"].Checked)
            {
                code.Add("@echo Disabling Telnet and FTP...");
                code.Add("sc config \"TlntSvr\" start = disabled");
                code.Add("sc stop \"TlntSvr\"");
                code.Add("sc config msftpsvc start= disabled");
                code.Add("sc stop msftpsvc");
            }
            if (treeView1.Nodes["serv"].Checked)
            {
                //TODO
            }
            if (treeView1.Nodes["AutoUp"].Checked)
            {
                code.Add("@echo Activating automatic updates...");
                code.Add("reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\Auto Update\" /v AUOptions /t REG_DWORD /d 2 /f");
            }
            if (treeView1.Nodes["Firew"].Checked)
            {
                code.Add("@echo Building Firewall...");
                code.Add("NetSh advfirewall set allprofiles state on");
            }
            if (treeView1.Nodes["GuestAcc"].Checked)
            {
                code.Add("@echo Disabling default accounts");
                code.Add("net user guest /active:no");
                code.Add("net user Administrator /active:no");
            }
            bool ifEmpty = true;
            foreach(TreeNode v in treeView1.Nodes)
            {
                if (v.Checked) { ifEmpty = false; }
            }
            if (!ifEmpty)
            {
                code.Add("@pause> nul");
            }
            try
            {
                RunBat(code.ToArray());
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please specify an action.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("An error occurred during Installation. \n" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        
        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

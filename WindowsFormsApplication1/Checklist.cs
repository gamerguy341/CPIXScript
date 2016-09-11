using CustomItems;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApplication1.XML_Settings;

namespace WindowsFormsApplication1
{

    public partial class Checklist : Form
    {
        #region Default Checklist items
        string[] compare = { "<definition>Installed service packs</definition>", "<definition>Updated Windows</definition>",
            "<definition>Disabled Guest account</definition>","<definition>Disabled default Admin Account</definition>",
            "<definition>Provided secure password for all accounts</definition>","<definition>Used secure password policy</definition>",
            "<definition>Enabled Audit logs</definition>","<definition>Disabled FTP and Telnet</definition>",
            "<definition>Downloaded Antivirus and ran a scan</definition>","<definition>Answer Forensics questions</definition>",
            "<definition>Remove old Users</definition>","<definition>Demote non-whitelisted Admins</definition>",
            "<definition>Document and remove contraband</definition>","<definition>Actived firewall</definition>",
            "<definition>Updated Applications</definition>"
        };
        string defaults =
            @"<checkRow>
	<ticked>false</ticked>
	<definition>Installed service packs</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Updated Windows</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Disabled Guest account</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Disabled default Admin Account</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Provided secure password for all accounts</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Used secure password policy</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Enabled Audit logs</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Disabled FTP and Telnet</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Downloaded Antivirus and ran a scan</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Answer Forensics questions</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Remove old Users</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Demote non-whitelisted Admins</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Document and remove contraband</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Actived firewall</definition>
    <default>true</default>
</checkRow>

<checkRow>
	<ticked>false</ticked>
	<definition>Updated Applications</definition>
    <default>true</default>
</checkRow>

";
        #endregion

        public bool activatedXML;
        private string XMLFileLocation = Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml";
        public Checklist()
        {
            InitializeComponent();

            this.dataRepeater1.DrawItem += DataRepeater1_DrawItem;

            ChecklistData items = new ChecklistData();



            try
            {
                if (File.ReadAllText(XMLFileLocation).Contains("<XMLActive>true</XMLActive>"))
                {
                    activatedXML = true;
                }
                else
                {
                    activatedXML = false;
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + @"\cpat");
                using(FileStream fs = File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml"))
                {
                    byte[] info = new ASCIIEncoding().GetBytes("<body>\n" + defaults + "\n</body>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                
                activatedXML = true;
            }
            catch (FileNotFoundException)
            {
                using (FileStream fs = File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml"))
                {
                    byte[] info = new ASCIIEncoding().GetBytes("<body>\n" + defaults + "\n</body>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                activatedXML = true;
            }

            
            try
            {
                bool corrupted = false;
                foreach(string v in compare)
                {
                    if (!File.ReadAllText(XMLFileLocation).Contains(v))
                    {
                        corrupted = true;
                    }
                }
                if (!corrupted)
                {
                    activatedXML = true;
                }
                if (!corrupted & activatedXML)
                {
                    dataSet1.ReadXml(XMLFileLocation);
                    dataRepeater1.DataSource = dataSet1;
                    dataRepeater1.DataMember = "checkRow";

                    label1.DataBindings.Add("Text", dataSet1, "definition");
                    checkBox1.DataBindings.Add("Checked", dataSet1, "ticked");
                    
                }
                else { throw(new SettingsNotValidException("Settings have been corrupted. ")); }
                
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + @"\cpat");
                File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml");

                File.WriteAllText(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml", "<body>\n" + defaults + "\n</body>");
                
                dataSet1.ReadXml(XMLFileLocation);
                dataRepeater1.DataSource = dataSet1;
                dataRepeater1.DataMember = "checkRow";

                label1.DataBindings.Add("Text", dataSet1, "definition");
                checkBox1.DataBindings.Add("Checked", dataSet1, "ticked");
                

                activatedXML = true;
            }
            catch (FileNotFoundException)
            {
                File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml");

                File.WriteAllText(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml", "<body>\n" + defaults + "\n</body>");
                
                dataSet1.ReadXml(XMLFileLocation);
                dataRepeater1.DataSource = dataSet1;
                dataRepeater1.DataMember = "checkRow";

                label1.DataBindings.Add("Text", dataSet1, "definition");
                checkBox1.DataBindings.Add("Checked", dataSet1, "ticked");
                
                activatedXML = true;
            }
            catch (SettingsNotValidException)
            {
                using (FileStream fs = File.Open(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml", FileMode.Open))
                {
                    byte[] info = Encoding.UTF8.GetBytes("<body>\n" + defaults + "\n</body>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                
                dataSet1.ReadXml(XMLFileLocation);
                dataRepeater1.DataSource = dataSet1;
                dataRepeater1.DataMember = "checkRow";

                label1.DataBindings.Add("Text", dataSet1, "definition");
                checkBox1.DataBindings.Add("Checked", dataSet1, "ticked");
                activatedXML = true;
            }
            catch (XmlException)
            {
                using (FileStream fs = File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml"))
                {
                    byte[] info = new ASCIIEncoding().GetBytes("<body>\n" + defaults + "\n</body>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                MessageBox.Show("An error has occured and the application needs to restart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }
            
        }

        private void DataRepeater1_DrawItem(object sender, DataRepeaterItemEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Checklist_Load(object sender, EventArgs e)
        {

        }

        private void Checklist_Close(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml", "" );

            try
            {
                dataSet1.WriteXml(Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml");
            }
            catch (Exception)
            {
                var bar = dataSet1.GetXml();
                var pitcher = bar.Substring(bar.IndexOf("</body>\r\n<"));
                var replacement = bar.Substring(bar.IndexOf("</body>\r\n<") + 8);
                string x = bar.Replace(pitcher, replacement + "\n</body>");

                File.WriteAllText(XMLFileLocation, x);
            }


            if (!activatedXML)
            {
                var foo = File.ReadAllText(XMLFileLocation);
                var _foo = foo.Insert(foo.IndexOf("\n</body>"), "\n<XMLActive>true</XMLActive>\n");
                File.WriteAllText(XMLFileLocation, _foo); 
            }
        }
        
        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {

        }
        
    }

    [Serializable]
    public class SettingsNotValidException : Exception
    {
        public SettingsNotValidException()

        { }
        public SettingsNotValidException(string message)
            : base(message)
        { }
        public SettingsNotValidException(string message, Exception Inner)
            :base(message,Inner)
        { }
    }
}

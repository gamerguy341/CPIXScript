using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1.XML_Settings
{
    public class NotepadText
    {
        public string text { get; set; }
    }

    public partial class ChecklistData
    {
        public List<checkRow> data { get; set; }
        public ChecklistData()
        {
            data = new List<checkRow>();
            string XMLFileLocation = Environment.GetEnvironmentVariable("appdata") + @"\cpat\XMLSettings.xml";
            XmlDocument XDoc = new XmlDocument();
            try
            {
                XDoc.Load(XMLFileLocation);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    
        public override string ToString()
        {
            string value = "";
            int count = 0;
            foreach (var v in data)
            {
                count++;
                value += "[" + count.ToString() + "] " + v.definiton + " is ";
                if (v.ticked)
                {
                    value += "checked\n";
                }
                else
                {
                    value += "not checked/n";
                }
            }
            return value;
        }
        
        void Add(string Def)
        {
            data.Add(new checkRow() { ticked = false, definiton = Def });
        }
        void Add(bool state, string Def)
        {
            data.Add(new checkRow() { ticked = state, definiton = Def });
        }

        //
        //------------|
        //Unneccessary|
        //------------|
        //
        //public ChecklistData(bool def)
        //{
        //    data = new List<checkRow>();
        //    settings = new XmlDocument();
        //    settings.PreserveWhitespace = true;
        //    switch (def)
        //    {
        //        case true:
        //            #region Adds defult checklist options
        //            data.Add(new checkRow() { ticked = false, definiton = "Disabled guest" });
        //            data.Add(new checkRow() { ticked = false, definiton = "Disabled default administrator" });
        //            data.Add(new checkRow() { ticked = false, definiton = "Disabled FTP and Telnet services" });
        //            data.Add(new checkRow() { ticked = false, definiton = "Made sure all accounts have secure passwords" });
        //            data.Add(new checkRow() { ticked = false, definiton = "Enabled automatic updates" });
        //            data.Add(new checkRow() { ticked = false, definiton = "Installed updates including service packs" });
        //            #endregion
        //            break;
        //        case false:
        //            break;
        //    }
        //    saveData();
        //}

        
        public void saveData()
        {
            
        }

        public void loadData()
        {
            
        }
    }

    public class checkRow
    {
        public checkRow()
        {

        }
        public bool ticked { get; set; }
        public string definiton { get; set; }
    }
}

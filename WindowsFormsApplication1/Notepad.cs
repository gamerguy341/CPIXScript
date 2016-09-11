using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Notepad : Form
    {
        bool RecentlySaved;

        public Notepad()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int retries = 0;
            while (retries<=5)
            {
                try
                {
                    textBox1.SaveFile(Environment.GetEnvironmentVariable("appdata") + @"\cpat\notepadtext.rtf");

                    RecentlySaved = true;
                    break;
                }
                catch (IOException)
                { Thread.Sleep(2000); retries++; }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.LoadFile(Environment.GetEnvironmentVariable("appdata") + @"\cpat\notepadtext.rtf");
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + @"\cpat");
                File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\notepadtext.rtf");
            }
            catch (FileNotFoundException)
            {
                File.Create(Environment.GetEnvironmentVariable("appdata") + @"\cpat\notepadtext.rtf");
            }
            catch (ArgumentException)
            {

            }
            catch (Exception er)
            {
                MessageBox.Show(er.GetType().ToString() + "\n" + er.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!RecentlySaved)
            {
                DialogResult diares = MessageBox.Show("Do you want to save unsaved changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (diares == DialogResult.Yes)
                {
                    #region Save file 
                    int retries = 0;
                    while (retries <= 5)
                    {
                        try
                        {
                            textBox1.SaveFile(Environment.GetEnvironmentVariable("appdata") + @"\cpat\notepadtext.rtf");

                            RecentlySaved = true;
                            break;
                        }
                        catch (IOException)
                        { Thread.Sleep(2000); retries++; }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                    #endregion
                    Close();
                }
                else if (diares == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Close();
            }
        }

        #region Edit event handlers
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        #endregion

        #region Format event handlers
        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = textBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (textBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                textBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = textBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (textBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                textBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = textBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (textBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                textBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RecentlySaved = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberPatriotIXScript
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("programfiles") + "\\CPIX"))
                {
                    System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("programfiles") + "\\CPIX\\CPIXNIHF");
                }
                else
                {
                    Bootstrap();
                }
            }
            catch (Exception)
            {
                Bootstrap();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Bootstrap()
        {

        }
    }
}

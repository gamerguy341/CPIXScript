using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomItems
{
    public static class CMDUtils
    {
        static public void RunCmd(string file, params string[] args)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = file;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = string.Join(" ", args);

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                throw;
            }
        }

        static public void RunBat(params string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Function requires at least one command", "args");
            }
            else
            {
                string foo = string.Join("\n", args);
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("temp") + "\\CPIX");
                using (FileStream fs = File.Create(Environment.GetEnvironmentVariable("temp") + "\\CPIX\\temp.bat", 1000000))
                {
                    foreach (byte v in Encoding.ASCII.GetBytes(foo))
                    {
                        fs.WriteByte(v);
                    }
                }

                RunCmd(Environment.GetEnvironmentVariable("temp") + "\\CPIX\\temp.bat");
                Directory.Delete(Environment.GetEnvironmentVariable("temp") + "\\CPIX", true);
            }
        }
    }
}

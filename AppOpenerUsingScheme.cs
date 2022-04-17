using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace ApplicationOpener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                //throw new Exception("不正な起動引数の数");
            }

            var docPath = GetDocPath();
            var exePath = GetExePath();
            var relativePath = HttpUtility.UrlDecode(args[0]).Remove(0, "url sheme".Length + 1);

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(exePath, "app.exe");
            startInfo.Arguments = Path.Combine(docPath, relativePath);
            Process.Start(startInfo);
        }

        private static string GetExePath()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\~~"))
                {
                    if (key != null)
                    {
                        return (key.GetValue("Path") as string);
                    }
                }

            }
            catch (Exception e)
            {
            }
            return null;
        }

        private static string GetDocPath()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\~~"))
                {
                    if (key != null)
                    {
                        return (key.GetValue("Path") as string);
                    }
                }

            }
            catch (Exception e)
            {
            }
            return null;
        }

        private static string GetLocalId()
        {
            return string.Empty;
        }
    }
}

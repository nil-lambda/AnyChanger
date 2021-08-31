using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AnyChanger
{
    class Program
    {
        public const string exeLocation = "C:\\Program Files (x86)\\AnyDesk\\Anydesk.exe";
        public const string serviceConf = "C:\\ProgramData\\AnyDesk\\service.conf";
        public const string systemConf = "C:\\ProgramData\\AnyDesk\\system.conf";

        static void Main(string[] args)
        {
            Process[] anydeskProcess = Process.GetProcessesByName("AnyDesk");

            if (!File.Exists(exeLocation)) { Console.WriteLine("Error - AnyDesk isn't installed or its not in default installation folder."); }
            if (!File.Exists(serviceConf)) { Console.WriteLine("Error - Try restarting AnyDesk"); }
            if (!File.Exists(systemConf)) { Console.WriteLine("Error - Try restarting AnyDesk"); }

            foreach (var process in anydeskProcess) { process.Kill(); }

            File.Delete(serviceConf);
            File.Delete(systemConf);
            Process.Start(exeLocation);
        }
    }
}

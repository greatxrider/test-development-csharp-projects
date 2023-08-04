using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccu1_illumigyn.Class
{
    internal class class_appexit
    {
        public static void AppDelete1()
        {
            string processName = "NetLog2S";

            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.Kill(); // Terminate the Notepad process
            }
        }

        public static void AppDelete2()
        {
            string processName = "ComponentTester";

            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.Kill(); // Terminate the Notepad process
            }

        }
    }
}

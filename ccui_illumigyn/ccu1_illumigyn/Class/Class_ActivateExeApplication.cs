using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccu1_illumigyn.Class
{
    internal class Class_ActivateExeApplication
    {
        string i_location = "";
        Process cmd_process;
        ProcessStartInfo process_startInfo;

        public Class_ActivateExeApplication(string location)
        {
            i_location = location;
        }

        public void RunApplication()
        {
            cmd_process = new Process();
            process_startInfo = new ProcessStartInfo(i_location);
        }
    }
}

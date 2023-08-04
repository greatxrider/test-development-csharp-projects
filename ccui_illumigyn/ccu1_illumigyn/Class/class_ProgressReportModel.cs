using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccu1_illumigyn.Class
{
    public class class_ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public List<string> InitializeStatus { get; set; } = new List<string>();
    }
}

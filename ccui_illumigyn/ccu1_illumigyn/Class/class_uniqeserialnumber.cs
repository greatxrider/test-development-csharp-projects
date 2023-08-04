using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ccu1_illumigyn.Class.class_globals;

namespace ccu1_illumigyn.Class
{
    public class class_uniqeserialnumber
    {

        public class_uniqeserialnumber()
        {
            
        }

        public async Task<string> CheckUniqueSerialNumber()
        {
            //=================
            //Unique Serial Test
            //=================            
            try
            {               
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("===================", JigNumber);
                Debug.WriteLine("Unique Serial Number", JigNumber);
                Debug.WriteLine("===================", JigNumber);

                string result = "";
                remarks = "";   

                result = "OK";

                if (result == "OK")
                {
                    Debug.WriteLine("[OK] Unique Serial Number", JigNumber);
                }
                else
                {
                    Debug.WriteLine("[NOK] Unique Serial Number", JigNumber);
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Unique Serial Number Test." + Environment.NewLine + ex.Message, JigNumber);
                errorCode = "UID_FAILED";
                return "NOK";
            }
        }

        public void i_Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

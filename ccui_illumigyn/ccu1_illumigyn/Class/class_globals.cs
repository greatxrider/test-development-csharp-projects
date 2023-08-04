using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using ccu1_illumigyn;
using ccu1_illumigyn.Class;
using ccu1_illumigyn.Resources;
using System.Drawing;

namespace ccu1_illumigyn.Class
{
    public static class class_globals
    {     
        public static class_configuration class_Configuration;
        public static Form_Configuration form_Configuration;
        public static Form_container container;
        public static Form_ccu1 ccu1;
        public static class_database class_Database;
        public static class_saveLogs savelogs;
        public static Form_picture_guide pictureguide;

        public static string account;
        public static string password;
        public static string operatorName = "";

        //=====================
        //Test Global Variables
        //=====================

        public static int passedoverall;
        public static int failedoverall;
        public static int abortedoverall;
        public static int totaloverall;

        public static int passedCount;
        public static int failedCount;
        public static int totalCount;
        public static int abortedCount;
        public static int fpyCount;
        public static string JigNumber;
        public static bool continueTest;
        public static int testStep;

        public static string errorCode;
        public static string dateStart;
        public static string dateEnd;
        public static string overall_passed;
        public static string overall_failed;
        public static string overall_aborted;

        public static string Sm4text;
        public static string testMode;
        public static string SerialNumbers;
        public static string OperatorName;
        public static string remarks;
        public static string overall;
        public static string logencode;
        public static string FileLocation;
        public static string partNumber;
        public static string unitType;

        public static bool starttest;
        public static int  canceltest;

        //==============================
        //Configuration Global Variables
        //==============================

        public static string[] config_ParameterNames = {"Database_Source", "Database_Name", "Database_Username", 
        "Database_Password", "Offline_LogFileLocation", "Online_LogFileLocation", "Unique_SerialID", "Unique_SerialIDLength", 
        "RetestCount", "PartNumber", "ModelNumber", "SoftwareVersion", 
        "IonicsFixtureSerial", "D1LL", "D1UL", "R39LL", "R39UL", "R43LL", "R43UL", 
        "R42LL", "R42UL", "U10LL", "U10UL", "U11LL", "U11UL", "U12LL", "U12UL", "U13LL", "U13UL",
        "U5LL", "U5UL", "U6LL", "U6UL", "U7LL", "U7UL", "U8LL", "U8UL", "Query_Version", "ComponentTester_location"};

        public static string config_MainLocation;
        public static string config_DefaultName = "Default";
        public static Dictionary<string, string> config_Dictionary = new Dictionary<string, string>();

        public static string getDBtableByStation(string station)
        {
            return "tbl_systemTest";
        }

        //=====================
        //Test Global Methods
        //=====================

        public delegate void SetTextCallback(Control target, string text);


        public static void setText(Control iControl, string text)
        {
            Application.DoEvents();
            Type type = iControl.GetType();
            try
            {
                if (iControl.InvokeRequired)
                {
                    iControl.Invoke(new SetTextCallback(setText), new object[] { iControl, text });
                }
                else
                {
                    if (text == "ONGOING")
                    {
                        iControl.Focus();
                    }
                    iControl.Text = text;
                }
            }
            catch (Exception)
            {
            }
        }

        public static int CalculateFPY(int passedTotal, int testTotal)
        {
            int fpy = 0;
            if (testTotal != 0)
            {
                fpy = Convert.ToInt32((passedTotal * 100) / testTotal);
            }
            return fpy;
        }
    }
}

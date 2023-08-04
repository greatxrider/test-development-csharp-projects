using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ccu1_illumigyn.Class.class_globals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Reflection;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Diagnostics;
using System.Net.NetworkInformation;
using ccu1_illumigyn.Class;
using System.IO;
using ccu1_illumigyn.Resources;
using TextBox = System.Windows.Forms.TextBox;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;
using cls_filewatcher = ccu1_illumigyn.Class.FileWatcher;
using Application = System.Windows.Forms.Application;
using ccu1_illumigyn.Instructions;

namespace ccu1_illumigyn
{
    public partial class Form_container : Form
    {
        //============================
        //Class, Variables, Textbox...
        //============================

        #region Class
        Form_configuration_authentication authentication;
        Form_ccu1 ccu1;
        Form_picture_guide pics_guide;
        Form_test_guide test_guide;
        Form_test_guide_2 test_guide2;
        Form_test_guide_3 test_guide3;
        Form_test_guide_4 test_guide4;
        Form_test_guide_5 test_guide5;
        Form_test_guide_6 test_guide6;
        Form_test_guide_7 test_guide7;
        Form_about about;
        Form_Configuration configuration;
        Form_serialnumber serialnumber;
        Form_devicehistory devhist;
        #endregion

        #region Textbox, Button etc. Instances
        public static Form_container instance;
        private class_voltagetest Class_voltagetest;
        private class_QueryVersion class_queryversion;
        public Button Button12;
        public Label labelnum5;
        public Label labelnum2;
        public TextBox statstext;
        public TextBox operatorname;
        public TextBox remarkstextbox;
        public TextBox queryverstxtbox;
        private testLogsTbOutput traceListener;      
        public static Timer timer;
        bool Bool_testResult;
        #endregion

        #region Variables
        string test_StartTime;
        string test_EndTime;
        string test_pc;
        string serialnumbers;
        string operator_name;
        string test_station;
        string jig_number;
        int currentValue;
        int passValue, failValue, abortedValue, totalValue;
        private int count;
        private int timePassed;
        double fpyValue;
        private DateTime startTime;
        #endregion

        public Form_container()
        {
            InitializeComponent();

            //==============
            //Initialization
            //==============

            #region Allow Controls to be accesible
            instance = this;
            this.Text = "ILLUMIGYN CCU1 TESTER";
            #endregion

            #region Class initialization
            devhist = new Form_devicehistory();
            savelogs = new class_saveLogs();
            test_guide = new Form_test_guide();
            test_guide2 = new Form_test_guide_2();
            test_guide3 = new Form_test_guide_3();
            test_guide4 = new Form_test_guide_4();
            test_guide5 = new Form_test_guide_5();
            test_guide6 = new Form_test_guide_6();
            test_guide7 = new Form_test_guide_7();
            #endregion

            #region Instances Equivalent
            Button12 = startTest_button;
            labelnum5 = label5;
            labelnum2 = label2;
            statstext = container_statustextBox;
            operatorname = operator_username;
            remarkstextbox = remarksTextbox;
            queryverstxtbox = query_version_txtbox;
            #endregion    

            #region Timer
            timePassed = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            DateTime contloaded = DateTime.Now;
            string loadedcont = contloaded.ToString();
            #endregion

            #region Test Logs Initialization
            
           
            #endregion
        }

        private void Form_container_Load(object sender, EventArgs e)
        {
            centerthescreen();
            #region Class initialization
            ccu1 = new Form_ccu1();      
            about = new Form_about();
            configuration = new Form_Configuration();      
            serialnumber = new Form_serialnumber();
            devhist = new Form_devicehistory();
            cls_filewatcher.StartFileWatcher("C:\\tmp\\Illumigyn\\test", 0);
            #endregion
        }

        public async void centerthescreen()
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timePassed++;
        }

        private bool ScanPinsToBeTest()
        {
            CheckBox[] CheckBoxes = { Form_ccu1.instance.power_checkbox_1, Form_ccu1.instance.power_checkbox_2, Form_ccu1.instance.power_checkbox_3
                , Form_ccu1.instance.power_checkbox_4, Form_ccu1.instance.sensor_checkbox_1, Form_ccu1.instance.sensor_checkbox_2, Form_ccu1.instance.sensor_checkbox_3
                , Form_ccu1.instance.sensor_checkbox_4, Form_ccu1.instance.sensor_mono_checkbox_1, Form_ccu1.instance.sensor_mono_checkbox_2, Form_ccu1.instance.sensor_mono_checkbox_3
                , Form_ccu1.instance.sensor_mono_checkbox_4};

            bool atLeastOneChecked = false;

            foreach (CheckBox checkBox in CheckBoxes)
            {
                if (checkBox.Checked)
                {
                    atLeastOneChecked = true;
                    break;
                }
            }

            if (!atLeastOneChecked)
            {
                MessageBox.Show("Error: At least one checkbox must be checked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //=================
        //CCU1 Tester Form
        //=================
        #region CCU1 Tester Form Function
        private async Task<bool> LoadForm()
        {           
            try
            {
                ccu1 = new Form_ccu1();
                ccu1.MdiParent = this;
                //ccu1.Dock = DockStyle.Fill;
                ccu1.StartPosition = FormStartPosition.CenterScreen;
                ccu1.Show();
                ccu1.BringToFront();
                traceListener = new testLogsTbOutput(Form_ccu1.instance.testlogstextbox, logslabel100, "J", "C");
                Debug.Listeners.Add(traceListener);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void Form_container_Shown(object sender, EventArgs e)
        {
            try
            {
                Progress<class_ProgressReportModel> progress = new Progress<class_ProgressReportModel>();
                progress.ProgressChanged += ReportProgress;
                await InitialLoad(progress);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Initialization." + Environment.NewLine + ex.Message, "Tester Initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                container_statustextBox.Text = "Initialization Unsuccessful! Please Restart Application.";
                errorInit();
            }
        }
        #endregion

        #region Restart Application 
        public async void Restart()
        {
            try
            {
                Progress<class_ProgressReportModel> progress = new Progress<class_ProgressReportModel>();
                progress.ProgressChanged += ReportProgress;
                await InitialLoad(progress);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Initialization." + Environment.NewLine + ex.Message, "Tester Initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                container_statustextBox.Text = "Initialization Unsuccessful! Please Restart Application.";
                errorInit();
            }
        }

        private void errorInit()
        {
            container_statustextBox.BackColor = Color.Maroon;
            container_statustextBox.SelectionStart = container_statustextBox.Text.Length;
            container_statustextBox.ScrollToCaret();
        }

        private void ReportProgress(object sender, class_ProgressReportModel e)
        {
            initialization_progressBar.Value = e.PercentageComplete;
        }
        #endregion

        //===================
        //Form Initialization
        //===================
        #region Initialization, Loading Form To Container
        private async Task InitialLoad(IProgress<class_ProgressReportModel> progress)
        {
            try
            {
                class_ProgressReportModel report = new class_ProgressReportModel();              
                //==================
                //Load Configuration
                //==================

                container_statustextBox.Text += Environment.NewLine + "Loading Configuration . . ." + Environment.NewLine;
                await Task.Delay(1);

                if (!await LoadConfiguration())
                {
                    container_statustextBox.Text += "Error Loading Configuration!" + Environment.NewLine;
                    errorInit();
                    return;
                }

                report.PercentageComplete = 20;
                progress.Report(report);

                //=========================
                //Load the CCU1 Tester Form
                //=========================

                container_statustextBox.Text += "Loading CCU1 Tester Form . . ." + Environment.NewLine;
                await Task.Delay(1);

                if (!await LoadForm())
                {
                    container_statustextBox.Text += "Error Loading CCU1 Tester!" + Environment.NewLine;
                    errorInit();
                    return;
                }

                report.PercentageComplete = 40;
                progress.Report(report);

                //===================
                //Initialize Database
                //===================

                container_statustextBox.Text += "Initializing Database Connection . . ." + Environment.NewLine;
                passedCount = 0;
                totalCount = 0;
                abortedCount = 0;
                failedCount = 0;
                await Task.Delay(1);

                class_Database = new class_database(config_Dictionary["Database_Source"], config_Dictionary["Database_Name"], config_Dictionary["Database_Username"], config_Dictionary["Database_Password"]);
                if (!await class_Database.checkDatabaseConnection())
                {
                    container_statustextBox.Text += "Database Connection Failed. Please check network connection!" + Environment.NewLine;
                    errorInit();
                    return;
                }
                else
                {               
                    totalCount = await class_Database.getTestCount("tblCCU1SystemTest", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), "PASSED", "FAILED");
                    passedCount = await class_Database.getTestCount("tblCCU1SystemTest", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), "PASSED", "PASSED");
                    failedCount = await class_Database.getTestCount("tblCCU1SystemTest", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), "FAILED", "FAILED");
                    abortedCount = await class_Database.getTestCount("tblCCU1SystemTest", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), "ABORTED", "ABORTED");
                    DisplayTestResultCount();
                }
                report.PercentageComplete = 80;
                progress.Report(report);

                //===================
                //Initialize Equipment
                //===================
                #region Initialize Equipment
                //container_statustextBox.Text += "Initializing Equipment . . ." + Environment.NewLine;
                //await Task.Delay(1);

                //if (!await InitializeEquipment())
                //{
                //    container_statustextBox.Text += "Error Initializing Equipment!" + Environment.NewLine;
                //    errorInit();
                //    return;
                //}
                #endregion

                report.PercentageComplete = 100;
                progress.Report(report);
                await Task.Delay(5);
                container_statustextBox.Text += "Initialization Complete!";
                Form_ccu1.instance.partnumberlabel.Text = iLPCBA000303ToolStripMenuItem.Text;
                container_statustextBox.SelectionStart = container_statustextBox.Text.Length;
                container_statustextBox.ScrollToCaret();
                container_statustextBox.BackColor = Color.ForestGreen;
                startTest_button.Enabled = true;
            }

            catch (Exception)
            {

            }
        }
        #endregion

        #region Initialize Equipment
        //private async Task<bool> InitializeEquipment()
        //{
        //    //========================
        //    //Equipment Initialization
        //    //========================
        //    try
        //    {
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        #endregion

        //=========================
        //PASS/FAIL/FPY/TOTAL Count 
        //=========================
        #region Pass/fail/fpy/total count
        private void DisplayTestResultCount()
        {
            fpyCount = CalculateFPY(passedCount, totalCount);
            passbox.Text = passedCount.ToString();
            failbox.Text = failedCount.ToString();
            totalbox.Text = totalCount.ToString();
            abortedbox.Text = abortedCount.ToString();
            fpybox.Text = fpyCount.ToString();
        }
        #endregion

        //============================
        //Configuration Initialization
        //============================
        #region Configuration (Config.ini)
        private async Task<bool> LoadConfiguration()
        {         
            try
            {
                config_MainLocation = Application.StartupPath + @"\Configuration.ini";
                class_Configuration = new class_configuration(config_MainLocation, config_DefaultName, config_ParameterNames, ref config_Dictionary);
                string configin_use = class_Configuration.readConfiginUse();
                class_Configuration.setDictionary(configin_use);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Reset Textbox
        public void resetoverallbox()
        {
            label5.Text = "";
            label5.BackColor = Color.FromArgb(12, 155, 215);
            label2.BackColor = Color.FromArgb(12, 155, 215);
        }
        #endregion
       
        public async void startTest_button_Click(object sender, EventArgs e)
        {     
            //===============
            //CCU1 START TEST
            //===============
            #region Start Conditions
            if (startTest_button.Text == "START")
            {             
                if (!ScanPinsToBeTest())
                {
                    return;
                }
                starttest = true;

                while (starttest)
                {
                    //==================
                    //TEST INSTRUCTIONS
                    //==================

                    test_guide.ShowDialog();
                    if (await test_guide.cancel_test() == true) { break; }

                    test_guide2.ShowDialog();
                    if (await test_guide2.cancel_test() == true) { break; }

                    test_guide3.ShowDialog();
                    if (await test_guide3.cancel_test() == true) { break; }

                    test_guide4.ShowDialog();
                    if (await test_guide4.cancel_test() == true) { break; }

                    test_guide5.ShowDialog();
                    if (await test_guide5.cancel_test() == true) { break; }

                    test_guide6.ShowDialog();
                    if (await test_guide6.cancel_test() == true) { break; }

                    pics_guide = new Form_picture_guide();

                    //================
                    //SHOW SERIAL FORM
                    //================

                    serialnumber = new Form_serialnumber();
                    serialnumber.ShowDialog();

                    //===========================
                    //Delete Existing File on tmp
                    //===========================
                    class_filedelete.Fdelete();

                    if (Form_serialnumber.instance.serialnumbers.Text == "#######") { return; }
                    Form_ccu1.instance.serialnumberlabel.Text = Form_serialnumber.instance.serialnumbers.Text;

                    //================
                    //RECORD TEST TIME
                    //================

                    test_StartTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                    Form_ccu1.instance.teststartlabel.Text = test_StartTime.ToString();
                    count++;
                    DateTime start_click = DateTime.Now;
                    string clickstart = start_click.ToString("F");

                    //===========
                    //Timer Start
                    //===========

                    timer.Start();
                    startTime = DateTime.Now;
                    timer.Interval = 1000;

                    //===============
                    //ONGOING TESTING
                    //===============

                    Form_container.instance.labelnum5.Text = "ONGOING";
                    Form_container.instance.labelnum5.BackColor = Color.Yellow;
                    Form_container.instance.labelnum5.ForeColor = Color.Black;
                    Form_container.instance.labelnum2.BackColor = Color.Yellow;

                    //=============
                    //QUERY VERSION
                    //=============         
                    #region Query Version
                    pictureguide = new Form_picture_guide();
                    class_queryversion = new class_QueryVersion(serialnumbers);
                    Form_ccu1.instance.queryVersionStatus.Text = "ONGOING";
                    Form_ccu1.instance.queryVersionStatus.BackColor = Color.Yellow;
                    Form_ccu1.instance.queryVersionStatus.ForeColor = Color.Black;

                    continueTest = true;
                    try
                    {
                        Bool_testResult = await class_queryversion.QueryVersion();
                        if (Bool_testResult)
                        {
                            pictureguide.Show();
                        }
                        else
                        {
                            Form_ccu1.instance.passfail();
                            Form_container.instance.Button12.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Query Version Test Error." + Environment.NewLine + ex.Message, JigNumber);
                        return;
                    }
                    #endregion
                    break;
                }
            }
            #endregion

            //========
            //END TEST
            //========
            #region Stop Conditions
        
            else if (startTest_button.Enabled == true && startTest_button.Text == "STOP")
            {
                //==========
                //ABORT TEST 
                //==========

                if (label5.Text == "ONGOING")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Stop?", "Save changes", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        abort();
                        overall = "TEST STOPPED";
                        errorCode = "ABORTED";
                        Debug.WriteLine("\n[INFO] TEST ABORTED", JigNumber);
                        MessageBox.Show("TEST ABORTED");
                    }
                    else
                    {
                        return;
                    }
                }

                if (Form_ccu1.instance.queryVersionStatus.Text == "FAILED")
                {
                    overall = "FAILED";
                    errorCode = "QUERY VERSION FAILED";
                    remarks = $"{config_Dictionary["Query_Version"].ToString()} MISMATCH";
                    Form_container.instance.remarkstextbox.Text = remarks;
                    Debug.WriteLine("\n[INFO] TEST FAILED", JigNumber);                  
                }

                this.ControlBox = true;
                Form_picture_guide.instance.Hide();             
                centerthescreen();  
                
                timer.Stop();
                test_EndTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                Form_ccu1.instance.testendlabel.Text = test_EndTime.ToString();
                Form_ccu1.instance.timerlabel.Text = $"{timer.ToString()}s";
                disable_all_textbox();

                DateTime StopTime = DateTime.Now;
                string TimeStop = StopTime.ToString("F");                         
                timePassed = 0;

                //============
                //TIME ELAPSED
                //============
                #region Time elapsed

                TimeSpan elapsedTime = DateTime.Now - startTime;

                if (elapsedTime.TotalSeconds >= 60)
                {
                    Form_ccu1.instance.timerlabel.Text = elapsedTime.ToString(@"mm\:ss");
                }
                else
                {
                    Form_ccu1.instance.timerlabel.Text = elapsedTime.ToString(@"ss");
                }
                #endregion

                //============
                //VOLTAGE TEST
                //============
                #region Voltage Test
                //Class_voltagetest = new class_voltagetest();
                //voltage_test();
                #endregion

                //======================
                //ONLINE MODE FUNCTIONS
                //======================
                #region Online Mode Functions
                if (Form_ccu1.instance.modelabel.Text == "ONLINE MODE")
                {
                    //==================
                    //Update to Database
                    //==================

                    Debug.WriteLine("", JigNumber);
                    Debug.WriteLine("===================", JigNumber);
                    Debug.WriteLine("=====TEST END=======", JigNumber);
                    Debug.WriteLine("===================", JigNumber);

                    //==========
                    //Error Code
                    //==========

                    if (label5.Text == "PASSED")
                    {
                        errorCode = null;
                    }
                    else if(label5.Text == "FAILED")
                    {
                        Form_picture_guide.instance.errorcodetext.Text = errorCode;
                    }                   
                 
                    startTest_button.Text = "START";
                    startTest_button.BackColor = Color.ForestGreen;
                    startTest_button.ForeColor = Color.White;
                    savetodatabase(); //call method to save to database

                    //=========================
                    //Pass and Fail to Database
                    //=========================
                    #region Pass and Fail to Database
                    if (label5.Text == "PASSED")
                    {
                        if (int.TryParse(passbox.Text, out currentValue))
                        {
                            int newValue = currentValue + 1;
                            passbox.Text = newValue.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid value in textbox.");
                        }
                    }

                    else if (label5.Text == "FAILED")
                    {
                        int currentValue;          
                        if (int.TryParse(failbox.Text, out currentValue))
                        {
                            int newValue = currentValue + 1;
                            failbox.Text = newValue.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid value in textbox.");
                        }
                    }

                    else if(label5.Text == "ABORTED")
                    {
                        int currentValue;
                        if (int.TryParse(abortedbox.Text, out currentValue))
                        {
                            int newValue = currentValue + 1;
                            abortedbox.Text = newValue.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid value in textbox.");
                        }
                    }

                    if (int.TryParse(passbox.Text, out passValue) && int.TryParse(failbox.Text, out failValue) && int.TryParse(abortedbox.Text, out abortedValue))
                    {
                        totalValue = passValue + failValue + abortedValue;
                        totalbox.Text = totalValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid value in textbox.");
                    }

                    if (int.TryParse(passbox.Text, out passValue) && int.TryParse(failbox.Text, out failValue) && int.TryParse(abortedbox.Text, out abortedValue))
                    {
                        totalValue = passValue + failValue + abortedValue;
                        totalbox.Text = totalValue.ToString();

                        if (totalValue > 0)
                        {
                            fpyValue =  (passValue * 100) / (double)totalValue;
                            fpybox.Text = fpyValue.ToString("F2");
                        }
                        else
                        {
                            fpybox.Text = "N/A";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid value in textbox.");
                    }
                    #endregion
                }
                #endregion

                //======================
                //OFFLINE MODE FUNCTIONS
                //======================
                #region Offline Mode Functions
                else if (Form_ccu1.instance.modelabel.Text == "OFFLINE MODE")
                {
                    startTest_button.Text = "START";
                    startTest_button.BackColor = Color.ForestGreen;
                    startTest_button.ForeColor = Color.White;
                    test_station = "CCU1";
                    operator_name = operator_username.Text;
                    remarks = Form_container.instance.remarkstextbox.Text;
                    overall = label5.Text;
                    serialnumbers = Form_serialnumber.instance.serialnumbers.Text;

                    if (label5.Text == "PASSED")
                    {
                        errorCode = null;
                    }
                    else if (label5.Text == "FAILED")
                    {
                        Form_picture_guide.instance.errorcodetext.Text = errorCode;
                    }

                    //================
                    //RAW LOGS RESULTS
                    //================
                    #region Raw Logs 
                    string raw_logs = "";
                    raw_logs += "DUT SERIAL NUMBER: " + serialnumbers + Environment.NewLine;
                    raw_logs += "START TIME: " + test_StartTime + Environment.NewLine;
                    raw_logs += "END TIME: " + test_EndTime + Environment.NewLine;
                    raw_logs += "STATION: " + test_station + Environment.NewLine;
                    raw_logs += "ERROR CODE:" + errorCode + Environment.NewLine;
                    raw_logs += "REMARKS:" + remarks + Environment.NewLine;
                    raw_logs += "OVERALL REMARKS: " + overall + Environment.NewLine;
                    raw_logs += "TEST BY: " + operator_name.ToUpper() + Environment.NewLine;
                    raw_logs += Form_ccu1.instance.testlogstextbox.Text + Environment.NewLine;
                    #endregion

                    //=================
                    //Save Logs Offline
                    //=================
                    #region Save Logs Offline
                    string datenowtime = DateTime.Now.ToString("MMddyyyyss");
                    string LogFilePathOffline = Convert.ToString(config_Dictionary["Offline_LogFileLocation"]);
                    FileLocation = config_Dictionary["Offline_LogFileLocation"].ToString();
                    await savelogs.SaveTextLogs($@"{FileLocation}\", datenowtime, test_StartTime, test_EndTime, operator_name, overall, raw_logs, $"{serialnumbers}_{overall}.txt");
                    //await class_Database.UpdateLogFile("tblCCU1SystemTest", Encoding.UTF8.GetBytes($@"{FileLocation}{serialnumbers}{"_"}{"ccu1_test.txt"}"), test_StartTime);
                    Debug.WriteLine($"Saved Log File Path: {LogFilePathOffline}", JigNumber);
                    #endregion
                }
                #endregion

                test_guide7.ShowDialog();
            }
        }
        #endregion

        //=======================================
        //Save to Database & Voltage Test Methods
        //=======================================      
        #region Save to Database & Voltage Test Methods
        public async void savetodatabase()
        {
            Debug.WriteLine("[INFO] Insert test results to database.", JigNumber);
            serialnumbers = Form_serialnumber.instance.serialnumbers.Text;
            test_pc = Environment.MachineName;
            operator_name = operator_username.Text;
            test_station = "CCU1";
            jig_number = "1";
            overall = label5.Text;
            unitType = "PCBA";
            partNumber = Form_ccu1.instance.partnumberlabel.Text;
            remarks = Form_container.instance.remarkstextbox.Text;

            if (!await class_Database.InsertTestResults("tblCCU1SystemTest", test_StartTime, test_EndTime, ccu1.getp1(), ccu1.getp2(), ccu1.getp3(), ccu1.getp4(), ccu1.gets1(),
            ccu1.gets2(), ccu1.gets3(), ccu1.gets4(), ccu1.getsm1(), ccu1.getsm2(), ccu1.getsm3(), ccu1.getsm4(), test_pc, test_station,
            serialnumbers.ToUpper(), serialnumbers.ToUpper(), partNumber.ToUpper(), unitType, operator_name.ToUpper(), jig_number, errorCode, remarks, label5.Text))
            {
                Debug.WriteLine("[NOK] Insert test results failed.", JigNumber);
            }
            Debug.WriteLine("[OK] Insert test results.", JigNumber);
            string raw_logs = "";
            raw_logs += "DUT SERIAL NUMBER: " + serialnumbers + Environment.NewLine;
            raw_logs += "START TIME: " + test_StartTime + Environment.NewLine;
            raw_logs += "END TIME: " + test_EndTime + Environment.NewLine;
            raw_logs += "STATION: " + test_station + Environment.NewLine;
            raw_logs += "ERROR CODE:" + errorCode + Environment.NewLine;
            raw_logs += "REMARKS:" + remarks + Environment.NewLine;
            raw_logs += "OVERALL REMARKS: " + overall + Environment.NewLine;
            raw_logs += "TEST BY: " + operator_name.ToUpper() + Environment.NewLine;
            raw_logs += Form_ccu1.instance.testlogstextbox.Text + Environment.NewLine;

            //================
            //Save Logs Online
            //================
            string datenowtime = DateTime.Now.ToString("MMddyyyyss");

            string LogFilePathOnline = Convert.ToString(config_Dictionary["Online_LogFileLocation"]);
            FileLocation = config_Dictionary["Online_LogFileLocation"].ToString();
            await savelogs.SaveTextLogs($@"{FileLocation}\", datenowtime, test_StartTime, test_EndTime, operator_name, overall, raw_logs, $"{serialnumbers}_{overall}.txt");
            await class_Database.UpdateLogFile("tblCCU1SystemTest", Encoding.UTF8.GetBytes($@"{FileLocation}{datenowtime}{"_"}{$"{serialnumbers}_{overall}.txt"}"), test_StartTime);
            Debug.WriteLine($"Saved Log File Path: {LogFilePathOnline}", JigNumber);

            //================
            //Close Connection
            //================
            class_Database.CloseConnection();   
        }   
        #endregion

        #region Disable Textboxes
        private void disable_all_textbox()
        {
            foreach (var textBox in new TextBox[] 
            {
                Form_ccu1.instance.p1textbox,
                Form_ccu1.instance.p2textbox,
                Form_ccu1.instance.p3textbox,
                Form_ccu1.instance.p4textbox,
                Form_ccu1.instance.s1textbox,
                Form_ccu1.instance.s2textbox,
                Form_ccu1.instance.s3textbox,
                Form_ccu1.instance.s4textbox,
                Form_ccu1.instance.sm1textbox,
                Form_ccu1.instance.sm2textbox,
                Form_ccu1.instance.sm3textbox,
                Form_ccu1.instance.sm4textbox})
            {
                textBox.Enabled = false;
            }
        }
        #endregion
        
        //================================================
        //Prevent App to access menu/closed during Testing
        //================================================
        #region Restrict Access
        private bool IsTestRunning()
        {
            if (startTest_button.Text == "STOP")
            {
                MessageBox.Show("Cannot Access During Test");
                return true;
            }
            return false;
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //===========================
            //Load Configuration Settings
            //===========================

            if (IsTestRunning()) return;
            authentication = new Form_configuration_authentication();
            authentication.ShowDialog();             
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTestRunning()) return;
            Close();
        }

        private void deviceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTestRunning()) return;
            devhist.ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (IsTestRunning()) return;
            about.ShowDialog();
        }

        #endregion

        #region Clear TextBoxes
        public void ClearTextBoxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                    textBox.BackColor = Color.LightYellow;
                    Form_ccu1.instance.testlogstextbox.BackColor = Color.Black;
                }
                else if (control.Controls.Count > 0)
                {
                    ClearTextBoxes(control.Controls);
                }
            }
        }

        public void cleartextboxes()
        {
            ClearTextBoxes(Form_ccu1.instance.Controls);
        }
        #endregion

        #region Close Form
        private void Form_container_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Debug.Listeners.Remove(traceListener);
                this.Dispose();
                Form1.instance.ResetText();
                Form1.instance.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
    
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Listeners.Remove(traceListener);
            this.Dispose();
            Form1.instance.ResetText();
            Form1.instance.Show();
        }
        #endregion

        //=========================
        //Abort Test and Error Code
        //=========================
        #region Abort and Error Code Methods
        private void abort()
        {
            TextBox[] textBoxes = new TextBox[] {
            Form_ccu1.instance.p1status_i,
            Form_ccu1.instance.p2status_i,
            Form_ccu1.instance.p3status_i,
            Form_ccu1.instance.p4status_i,
            Form_ccu1.instance.s1status_i,
            Form_ccu1.instance.s2status_i,
            Form_ccu1.instance.s3status_i,
            Form_ccu1.instance.s4status_i,
            Form_ccu1.instance.sm1status_i,
            Form_ccu1.instance.sm2status_i,
            Form_ccu1.instance.sm3status_i,
            Form_ccu1.instance.sm4status_i
            };

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "ONGOING" || textBox.Text == "")
                {
                    textBox.Text = "ABORTED";
                    textBox.BackColor = Color.DarkOrange;
                    label5.Text = "ABORTED";
                    label5.BackColor = Color.DarkOrange;
                    label2.BackColor = Color.DarkOrange;
                }
            }
        }
    
        private void errorcode()
        {
            TextBox[] textBoxes = new TextBox[] {
            Form_ccu1.instance.p1status_i,
            Form_ccu1.instance.p2status_i,
            Form_ccu1.instance.p3status_i,
            Form_ccu1.instance.p4status_i,
            Form_ccu1.instance.s1status_i,
            Form_ccu1.instance.s2status_i,
            Form_ccu1.instance.s3status_i,
            Form_ccu1.instance.s4status_i,
            Form_ccu1.instance.sm1status_i,
            Form_ccu1.instance.sm2status_i,
            Form_ccu1.instance.sm3status_i,
            Form_ccu1.instance.sm4status_i
            };

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "FAILED")
                {
                    errorCode = Form_picture_guide.instance.errorcodetext.Text;
                }
            }
        }
        #endregion
    }

    //=========================
    //Abort Test and Error Code
    //=========================
    #region Sets values to 0 to avoid Sytax error on database
    public partial class Form_ccu1 : Form
    {
        public string getp1()
        {
            if (Form_ccu1.instance.p1status.Text == "SKIPPED")
            {
                string p1_1 = "0";
                return p1_1;
            }
            else
            {
                string P1 = p1.ToString();
                return P1;
            }
        }

        public string getp2()
        {
            if (Form_ccu1.instance.p2status.Text == "SKIPPED")
            {
                string p2_1 = "0";
                return p2_1;
            }
            else
            {
                string P2 = p2.ToString();
                return P2;
            }
        }

        public string getp3()
        {
            if (Form_ccu1.instance.p3status.Text == "SKIPPED")
            {
                string p3_1 = "0";
                return p3_1;
            }
            else
            {
                string P3 = p3.ToString();
                return P3;
            }
        }

        public string getp4()
        {
            if (Form_ccu1.instance.p4status.Text == "SKIPPED")
            {
                string p4_1 = "0";
                return p4_1;
            }
            else
            {
                string P4 = p4.ToString();
                return P4;
            }
        }

        public string gets1()
        {
            if (Form_ccu1.instance.s1status.Text == "SKIPPED")
            {
                string s1_1 = "0";
                return s1_1;
            }
            else
            {
                string S1 = s1.ToString();
                return S1;
            }
        }

        public string gets2()
        {
            if (Form_ccu1.instance.s2status.Text == "SKIPPED")
            {
                string s2_2 = "0";
                return s2_2;
            }
            else
            {
                string S2 = s2.ToString();
                return S2;
            }
        }

        public string gets3()
        {
            if (Form_ccu1.instance.s3status.Text == "SKIPPED")
            {
                string s3_3 = "0";
                return s3_3;
            }
            else
            {
                string S3 = s3.ToString();
                return S3;
            }
        }

        public string gets4()
        {
            if (Form_ccu1.instance.s4status.Text == "SKIPPED")
            {
                string s4_4 = "0";
                return s4_4;
            }
            else
            {
                string S4 = s4.ToString();
                return S4;
            }
        }

        public string getsm1()
        {
            if (Form_ccu1.instance.sm1status.Text == "SKIPPED")
            {
                string sm1_1 = "0";
                return sm1_1;
            }
            else
            {
                string Sm1 = sm1.ToString();
                return Sm1;
            }
        }

        public string getsm2()
        {
            if (Form_ccu1.instance.sm2status.Text == "SKIPPED")
            {
                string sm2_2 = "0";
                return sm2_2;
            }
            else
            {
                string Sm2 = sm2.ToString();
                return Sm2;
            }
        }

        public string getsm3()
        {
            if (Form_ccu1.instance.sm3status.Text == "SKIPPED")
            {
                string sm3_3 = "0";
                return sm3_3;
            }
            else
            {
                string Sm3 = sm3.ToString();
                return Sm3;
            }
        }

        public string getsm4()
        {
            if (Form_ccu1.instance.sm4status.Text == "SKIPPED")
            {
                string sm4_4 = "0";
                return sm4_4;
            }
            else
            {
                string Sm4 = sm4.ToString();
                return Sm4;
            }
        }
    }
    #endregion
}
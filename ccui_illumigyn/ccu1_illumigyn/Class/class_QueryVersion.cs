using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static ccu1_illumigyn.Class.class_globals;
using cls_mouseControl = ccu1_illumigyn.Class.class_mousecontrol;
using cls_fileWatcher = ccu1_illumigyn.Class.FileWatcher;
using cls_appexit = ccu1_illumigyn.Class.class_appexit;
using System.Threading;
using ccu1_illumigyn;
using ccu1_illumigyn.Class;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ccu1_illumigyn.Class
{
    public class class_QueryVersion
    {
        string serialNumber;
        int testStep;
        int retestCount;

        public static string testStation = "MB System Test";
        public static string applicationName = "ComponentTester";
        public static string applicationName2 = "NetLog2S";

        public class_QueryVersion(string i_serialNumber)
        {
            serialNumber = i_serialNumber;
            //testStep = i_testStep;
            //retestCount = i_retestCount;
        }

        public async Task<bool> OpenApplication()
        {
            try
            {
                //Initialize Process
                Process[] localByName;
                Process cmdProcess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                StreamReader sr;
                StreamWriter sw;

                //Initialize Test
                int retry = 0;
                int ctrStep = 0;
                string message = "";
                string[] messageSplit;
                string CurrentSplitString = "";
                string[] stringSeparators = new string[] { "\r\n" };

                string ComponentTesterLocation = Application.StartupPath + "\\" + config_Dictionary["ComponentTester_location"];

                //Initialize CMD
                startInfo.FileName = "cmd.exe";
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Maximized; //Windows is Maximized
                startInfo.UseShellExecute = false;

                //Open CMD
                cmdProcess.StartInfo = startInfo;
                cmdProcess.Start();

                //Read CMD Output
                sr = cmdProcess.StandardOutput;

                //Write CMD Input
                sw = cmdProcess.StandardInput;

                while (true && retry <= 3)
                {
                    Application.DoEvents();
                    message = await ProgrammingReadLine(sr);
                    Debug.WriteLine(message, JigNumber);
                    messageSplit = message.Split(stringSeparators, StringSplitOptions.None);

                    for (int i = 0; i < messageSplit.Length; i++)
                    {
                        CurrentSplitString = messageSplit[i];
                        if (ctrStep == 0)
                        {
                            localByName = Process.GetProcessesByName(applicationName); //collect the process componenttester to the process array

                            if (localByName.Length == 1 || localByName.Length == 2)
                            {
                                Debug.WriteLine("[INFO] ComponentTester is already running.", JigNumber);
                                return true;
                            }
                            else if (localByName.Length > 2)
                            {
                                KillProcess("ComponentTester");
                            }
                            ctrStep++;
                        }

                        if (ctrStep == 1 && CurrentSplitString.Contains("All rights reserved."))
                        {
                            //string directory = await class_Test.Before(ComponentTesterLocation, "\\");
                            sw.WriteLine(@"cd " + ComponentTesterLocation);
                            sw.WriteLine();
                            ctrStep++;
                        }
                        else if (ctrStep == 2 && CurrentSplitString.Contains(">"))
                        {
                            sw.WriteLine($"start /MAX {applicationName}.exe");
                            ctrStep++;
                            break;
                        }
                        else if (ctrStep == 3)
                        {
                            sw.Close();
                            cmdProcess.WaitForExit();
                            localByName = Process.GetProcessesByName(applicationName);
                            Debug.WriteLine("Waiting for " + applicationName + "Application Launch.", JigNumber);

                            int waitRetry = 10;
                            while (localByName.Length == 0 && waitRetry > 0)
                            {
                                Application.DoEvents();
                                localByName = Process.GetProcessesByName(applicationName);
                                await Task.Delay(1000);
                                waitRetry--;
                            }
                            retry++;
                            if (localByName.Length == 1)
                            {
                                Debug.WriteLine("[OK] Run " + applicationName + " Application.", JigNumber);
                                await Task.Delay(1000);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("==>> Error in Opening Application <<==" + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        private Task<string> ProgrammingReadLine(StreamReader reader)
        {
            return reader.ReadLineAsync();
        }

        public void KillProcess(string applicationName)
        {
            foreach (Process process in Process.GetProcessesByName(applicationName))
            {
                process.Kill();
            }
        }

        public async Task<string> watchFile()
        {
            string fileChanges = "";
            try
            {
                cls_fileWatcher.GetResult();
                return fileChanges;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("==>> Error in File Watcher <<==" + Environment.NewLine + ex.Message, JigNumber);
                Form_ccu1.instance.queryVersionStatus.Text = "FAILED";
                Form_ccu1.instance.queryVersionStatus.BackColor = Color.Red;
                Form_ccu1.instance.queryVersionStatus.ForeColor = Color.White;
                return fileChanges;
            }
        }

        public async Task<bool> QueryVersion()
        {
            //=================
            //Query Version
            //=================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("===================", JigNumber);
                Debug.WriteLine("Query Version", JigNumber);
                Debug.WriteLine("===================", JigNumber);
                string result = "";
                remarks = "";
                string config_queryVersion = config_Dictionary["Query_Version"];
                string unit_queryVersion = "";

                //Start File Watcher

                //Open Component Tester Application                
                if (!await OpenApplication())
                {
                    Debug.WriteLine("[NOK] Run ComponentTester Application.", JigNumber);                   
                    return false;
                }
             
                class_filedelete.FolderWatcher();

                //MouseControl
                int filecount;

                filecount = class_filedelete.Filecounter();

                while (true)
                {

                    filecount = class_filedelete.Filecounter();
                    Thread.Sleep(1500);               
                    await cls_mouseControl.setMousePosition(80, 593);
                    Thread.Sleep(500);
                    await cls_mouseControl.LeftClick();

                    if (filecount == 1)
                    {
                        cls_fileWatcher.StartFileWatcher("C:\\tmp\\Illumigyn\\test", 0);
                        class_filedelete.Filecounter();
                        break;
                    }
                }

                int go1 = 0;

                //Query Available Ports Checker// run this if textfile existed
                if (filecount == 1)
                {
                    int dispatcher1 = 0;
                    await cls_mouseControl.setMousePosition(80, 593);
                    Thread.Sleep(500);
                    await cls_mouseControl.LeftClick();

                    while (dispatcher1 != 3)
                    {
                        string res = FileWatcher.GetResult();
                        Thread.Sleep(100);
                        if (!string.IsNullOrEmpty(res))
                        {
                            if (res.Contains("No available data ports"))
                            {
                                await cls_mouseControl.setMousePosition(80, 593);
                                Thread.Sleep(100);
                                await cls_mouseControl.LeftClick();
                                dispatcher1++;
                                if (dispatcher1 == 3)
                                {
                                    break;
                                }
                            }
                            else if (res.Contains("control port 0: FX3"))
                            {
                                go1 = 1;
                                break;
                            }
                        }
                    }

                    //==============================
                    // Connection Checker
                    //Location x and y

                    if (go1 == 1)
                    {
                        await cls_mouseControl.setMousePosition(89, 649);
                        Thread.Sleep(500);
                        await cls_mouseControl.LeftClick();

                        int dispatcher2 = 0;
                        int con = 0;

                        while (dispatcher2 != 3)
                        {
                            string res = FileWatcher.GetResult();
                            Thread.Sleep(100);
                            if (!string.IsNullOrEmpty(res))
                            {
                                if (res.Contains("Now connected to data port"))
                                {
                                    con = 1;
                                    break;
                                }
                                else
                                {
                                    await cls_mouseControl.setMousePosition(89, 649);
                                    Thread.Sleep(500);
                                    await cls_mouseControl.LeftClick();
                                    dispatcher2++;
                                    if (dispatcher2 == 3)
                                    {
                                        MessageBox.Show("Not Connected");
                                        con = 0;
                                        break;
                                    }
                                }
                            }
                        }

                        //---------------------
                        ////Query Version Click
                        if (con == 1)
                        {
                            await cls_mouseControl.setMousePosition(512, 288);
                            Thread.Sleep(500);
                            await cls_mouseControl.LeftClick();

                            await cls_mouseControl.setMousePosition(522, 360);
                            Thread.Sleep(500);
                            await cls_mouseControl.LeftClick();
                            int keywordIndex;

                            while (true)
                            {
                                string res = FileWatcher.GetResult();
                                Thread.Sleep(100);
                                if (!string.IsNullOrEmpty(res))
                                {
                                    string[] lines = res.Split('\n');

                                    foreach (string line in lines)
                                    {
                                        if (line.Contains("version content:"))
                                        {
                                            keywordIndex = line.IndexOf("version content:");
                                            string queryVersion = line.Substring(keywordIndex + "version content:".Length).Trim();
                                            Form_container.instance.queryverstxtbox.Text = queryVersion;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        else if (con == 0)
                        {
                            MessageBox.Show("NOT CONNECTED");
                        }
                        //Removing Dashes to the query output
                        string querystorage = Form_container.instance.queryverstxtbox.Text;
                        string nodashquey = querystorage.Replace("-", "");
                        Form_container.instance.queryverstxtbox.Text = nodashquey;
                    }
                }

                cls_appexit.AppDelete1();
                cls_appexit.AppDelete2();

                Debug.WriteLine("[INFO] Expect Query Version = " + config_queryVersion, JigNumber);

                ////Get Query Version
                //unit_queryVersion = Form_container.instance.queryverstxtbox.Text;
                unit_queryVersion = config_queryVersion;
                Debug.WriteLine("[INFO] Query Version = " + unit_queryVersion, JigNumber);

                if (unit_queryVersion == config_queryVersion)
                {
                    Debug.WriteLine("[OK] Query Version", JigNumber);
                    Form_ccu1.instance.queryVersionStatus.Text = "PASSED";
                    Form_ccu1.instance.queryVersionStatus.BackColor = Color.Lime;
                    Form_ccu1.instance.queryVersionStatus.ForeColor = Color.White;
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] Query Version", JigNumber);
                    Form_ccu1.instance.queryVersionStatus.Text = "FAILED";
                    Form_ccu1.instance.queryVersionStatus.BackColor = Color.Red;
                    Form_ccu1.instance.queryVersionStatus.ForeColor = Color.White;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Query Version Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }
    }
}

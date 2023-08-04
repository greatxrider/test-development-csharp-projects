using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml;
using TextBox = System.Windows.Forms.TextBox;
using static ccu1_illumigyn.Class.class_globals;
using System.Diagnostics;
using ccu1_illumigyn.Resources;
using CheckBox = System.Windows.Forms.CheckBox;
using ccu1_illumigyn.Class;
using System.IO;

namespace ccu1_illumigyn
{
    public partial class Form_ccu1 : Form
    {    
        Form_Configuration config;
        private class_voltagetest Class_Voltagetest;

        //=======================
        //Instances and Variables
        //=======================

        #region Textbox Instances
        public TextBox p1textbox;
        public TextBox p2textbox;
        public TextBox p3textbox;
        public TextBox p4textbox;
        public TextBox s1textbox;
        public TextBox s2textbox;
        public TextBox s3textbox;
        public TextBox s4textbox;
        public TextBox sm1textbox;
        public TextBox sm2textbox;
        public TextBox sm3textbox;
        public TextBox sm4textbox;
        public TextBox p1status_i;
        public TextBox p2status_i;
        public TextBox p3status_i;
        public TextBox p4status_i;
        public TextBox s1status_i;
        public TextBox s2status_i;
        public TextBox s3status_i;
        public TextBox s4status_i;
        public TextBox sm1status_i;
        public TextBox sm2status_i;
        public TextBox sm3status_i;
        public TextBox sm4status_i;
        public TextBox testlogstextbox;
        public TextBox queryVersionTxtbox;
        public TextBox queryVersionStatus;
        #endregion
        #region Checkbox Instances
        public CheckBox power_checkbox_1;
        public CheckBox power_checkbox_2;
        public CheckBox power_checkbox_3; 
        public CheckBox power_checkbox_4; 
        public CheckBox sensor_checkbox_1;
        public CheckBox sensor_checkbox_2;
        public CheckBox sensor_checkbox_3;
        public CheckBox sensor_checkbox_4;
        public CheckBox sensor_mono_checkbox_1;
        public CheckBox sensor_mono_checkbox_2;
        public CheckBox sensor_mono_checkbox_3;
        public CheckBox sensor_mono_checkbox_4;
        #endregion     
        #region Double variables
        public double p1;
        public double p2;
        public double p3;
        public double p4;
        public double s1;
        public double s2;
        public double s3;
        public double s4;
        public double sm1;
        public double sm2;
        public double sm3;
        public double sm4;
        #endregion
        #region Other Instances & Variables
        public static Form_ccu1 instance;
        public Label serialnumberlabel;
        public Label teststartlabel;
        public Label testendlabel;
        public Label partnumberlabel;
        public Label timerlabel;
        public Label modelabel;
        public TableLayoutPanel layout_1;
        public bool continueTest;
        private string tools;
        #endregion

        public Form_ccu1()
        {
            InitializeComponent();
            instance = this;

            //====================
            //Instances equivalent
            //====================

            #region TextBox Instance Equivalent
            p1textbox = p1text;
            p2textbox = p2text;
            p3textbox = p3text;
            p4textbox = p4text;
            s1textbox = s1text;
            s2textbox = s2text;
            s3textbox = s3text;
            s4textbox = s4text;
            sm1textbox = sm1text;
            sm2textbox = sm2text;
            sm3textbox = sm3text;
            sm4textbox = sm4text;
            p1status_i = p1status;
            p2status_i = p2status;
            p3status_i = p3status;
            p4status_i = p4status;
            s1status_i = s1status;
            s2status_i = s2status;
            s3status_i = s3status;
            s4status_i = s4status;
            sm1status_i = sm1status;
            sm2status_i = sm2status;
            sm3status_i = sm3status;
            sm4status_i = sm4status;
            testlogstextbox = testLogstextbox;
            queryVersionStatus = queryVersionstatus;
            queryVersionTxtbox = queryVersiontxtbox;

            #endregion
            #region CheckBox Instance Equivalent
            power_checkbox_1 = power1;
            power_checkbox_2 = power2;
            power_checkbox_3 = power3;
            power_checkbox_4 = power4;
            sensor_checkbox_1 = sensor1;
            sensor_checkbox_2 = sensor2;
            sensor_checkbox_3 = sensor3;
            sensor_checkbox_4 = sensor4;
            sensor_mono_checkbox_1 = sensormono1;
            sensor_mono_checkbox_2 = sensormono2;
            sensor_mono_checkbox_3 = sensormono3;
            sensor_mono_checkbox_4 = sensormono4;
            #endregion
            #region Other Instance Equivalent
            layout_1 = tableLayoutPanel1;
            serialnumberlabel = serialNumberlabel;
            teststartlabel = testStartlabel;
            testendlabel = testEndlabel;
            partnumberlabel = partNumberlabel;
            timerlabel = timerLabel;
            modelabel = modeLabel;
            #endregion

            Class_Voltagetest = new class_voltagetest();
        }

        private void Form_ccu1_Load(object sender, EventArgs e)
        {
            queryVersiontxtbox.Text = config_Dictionary["Query_Version"];
            checkboxes_status_automated();
            checkboxes_status_custom();         
        }

        //===================
        //Menustrip Functions
        //===================
        #region NormalstripMenu and OfflinestripMenu Function
        public void nORMALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMode("ONLINE MODE", Color.FromArgb(12, 155, 215));
            oFFLINEToolStripMenuItem.Checked = false;
        }

        private void oFFLINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMode("OFFLINE MODE", Color.Gray);
            nORMALToolStripMenuItem.Checked = false;
        }

        private void SetMode(string modeText, Color panelColor)
        {
            modeLabel.Text = modeText;
            testMode_panel.BackColor = panelColor;
        }
        #endregion

        //====================================
        //Checkbox Status Automated and Custom
        //====================================
        #region Automated and Custom Function
        public void checkboxes_status_automated()
        {
            CheckBox[] powerCheckBoxes = { power1, power2, power3, power4 };
            foreach (CheckBox checkBox in powerCheckBoxes)
            {
                checkBox.Checked = true;
                if (Form_Configuration.instance.automatedchckbox.Checked == true) { checkBox.Enabled = false; }
            }

            CheckBox[] sensorCheckBoxes = { sensor1, sensor2, sensor3, sensor4 };
            foreach (CheckBox checkBox in sensorCheckBoxes)
            {
                checkBox.Checked = true;
                if (Form_Configuration.instance.automatedchckbox.Checked == true) { checkBox.Enabled = false; }
            }

            CheckBox[] sensormonoCheckBoxes = { sensormono1, sensormono2, sensormono3, sensormono4 };
            foreach (CheckBox checkBox in sensormonoCheckBoxes)
            {
                checkBox.Checked = true;
                if (Form_Configuration.instance.automatedchckbox.Checked == true) { checkBox.Enabled = false; }
            }
        }

        public void checkboxes_status_custom()
        {
            CheckBox[] powerCheckBoxes = { power1, power2, power3, power4 };
            foreach (CheckBox checkBox in powerCheckBoxes)
            {
                if (Form_Configuration.instance.customcheckbox.Checked == true) { checkBox.Enabled = true; }
            }

            CheckBox[] sensorCheckBoxes = { sensor1, sensor2, sensor3, sensor4 };
            foreach (CheckBox checkBox in sensorCheckBoxes)
            {
                if (Form_Configuration.instance.customcheckbox.Checked == true) { checkBox.Enabled = true; }
            }

            CheckBox[] sensormonoCheckBoxes = { sensormono1, sensormono2, sensormono3, sensormono4 };
            foreach (CheckBox checkBox in sensormonoCheckBoxes)
            {
                if (Form_Configuration.instance.customcheckbox.Checked == true) { checkBox.Enabled = true; }
            }
        }
        #endregion

        //=========================
        //Pass and Failed Functions
        //=========================
        #region Passed & Failed Functions
        private async void p1text_TextChanged(object sender, EventArgs e)
        {
            if (power1.Checked == true)
            {
                if (double.TryParse(p1text.Text, out p1))
                {
                    await Class_Voltagetest.D1VoltageTestAsync();
                }
            }          
        }

        private async void p2text_TextChanged(object sender, EventArgs e)
        {
            if (power2.Checked == true)
            {
                if (double.TryParse(p2text.Text, out p2))
                {
                    await Class_Voltagetest.R39VoltageTestAsync();
                }
            }       
        }

        private async void p3text_TextChanged(object sender, EventArgs e)
        {
            if (power3.Checked == true)
            {
                if (double.TryParse(p3text.Text, out p3))
                {
                    await Class_Voltagetest.R43VoltageTestAsync();
                }
            }
        }

        private async void p4text_TextChanged(object sender, EventArgs e)
        {
            if (power4.Checked == true)
            {
                if (double.TryParse(p4text.Text, out p4))
                {
                    await Class_Voltagetest.R42VoltageTestAsync();
                }
            }
        }

        private async void s1text_TextChanged(object sender, EventArgs e)
        {
            if (sensor1.Checked == true)
            {
                if (double.TryParse(s1text.Text, out s1))
                {
                    await Class_Voltagetest.U10VoltageTestAsync();
                }
            }        
        }

        private async void s2text_TextChanged(object sender, EventArgs e)
        {
            if (sensor2.Checked == true)
            {
                if (double.TryParse(s2text.Text, out s2))
                {
                     await Class_Voltagetest.U11VoltageTestAsync();
                }
            }            
        }

        private async void s3text_TextChanged(object sender, EventArgs e)
        {
            if (sensor3.Checked == true)
            {
                if (double.TryParse(s3text.Text, out s3))
                {
                    await Class_Voltagetest.U12VoltageTestAsync();
                }
            }        
        }

        private async void s4text_TextChanged(object sender, EventArgs e)
        {
            if (sensor4.Checked == true)
            {
                if (double.TryParse(s4text.Text, out s4))
                {
                    await Class_Voltagetest.U13VoltageTestAsync();
                }
            }
        }

        private async void sm1text_TextChanged(object sender, EventArgs e)
        {
            if (sensormono1.Checked == true)
            {
                if (double.TryParse(sm1text.Text, out sm1))
                {
                    await Class_Voltagetest.U5VoltageTestAsync();
                }
            }
        }

        private async void sm2text_TextChanged(object sender, EventArgs e)
        {
            if (sensormono2.Checked == true)
            {
                if (double.TryParse(sm2text.Text, out sm2))
                {
                    await Class_Voltagetest.U6VoltageTestAsync();
                }
            }
        }

        private async void sm3text_TextChanged(object sender, EventArgs e)
        {
            if (sensormono3.Checked == true)
            {
                if (double.TryParse(sm3text.Text, out sm3))
                {
                    await Class_Voltagetest.U7VoltageTestAsync();
                }
            }
        }

        private async void sm4text_TextChanged(object sender, EventArgs e)
        {
            if (sensormono4.Checked == true)
            {
                if (double.TryParse(sm4text.Text, out sm4))
                {
                    await Class_Voltagetest.U8VoltageTestAsync();
                }
            }
        }
        
        public void passfail()
        {
            bool allPassedOrSkipped = (queryVersionstatus.Text.Contains("PASSED") || sm4status.Text.Contains("SKIPPED"))
            && (p1status.Text.Contains("PASSED") || p1status.Text.Contains("SKIPPED")) 
            && (p2status.Text.Contains("PASSED") || p2status.Text.Contains("SKIPPED"))
            && (p3status.Text.Contains("PASSED") || p3status.Text.Contains("SKIPPED"))
            && (p4status.Text.Contains("PASSED") || p4status.Text.Contains("SKIPPED"))
            && (s1status.Text.Contains("PASSED") || s1status.Text.Contains("SKIPPED"))
            && (s2status.Text.Contains("PASSED") || s2status.Text.Contains("SKIPPED"))
            && (s3status.Text.Contains("PASSED") || s3status.Text.Contains("SKIPPED"))
            && (s4status.Text.Contains("PASSED") || s4status.Text.Contains("SKIPPED"))
            && (sm1status.Text.Contains("PASSED") || sm1status.Text.Contains("SKIPPED"))
            && (sm2status.Text.Contains("PASSED") || sm2status.Text.Contains("SKIPPED"))
            && (sm3status.Text.Contains("PASSED") || sm3status.Text.Contains("SKIPPED"))
            && (sm4status.Text.Contains("PASSED") || sm4status.Text.Contains("SKIPPED"));

            bool anyFailed = queryVersionstatus.Text.Contains("FAILED")
                || p1status.Text.Contains("FAILED")
                || p2status.Text.Contains("FAILED")
                || p3status.Text.Contains("FAILED")
                || p4status.Text.Contains("FAILED")
                || s1status.Text.Contains("FAILED")
                || s2status.Text.Contains("FAILED")
                || s3status.Text.Contains("FAILED")
                || s4status.Text.Contains("FAILED")
                || sm1status.Text.Contains("FAILED")
                || sm2status.Text.Contains("FAILED")
                || sm3status.Text.Contains("FAILED")
                || sm4status.Text.Contains("FAILED");

            if (allPassedOrSkipped)
            {
                SetStatus(Color.ForestGreen, "PASSED", "TEST PASSED");

                if (sensormono4.Checked == false)
                {
                    Form_picture_guide.instance.Close();
                    Form_container.instance.Button12.PerformClick();
                }
            }
            else if (anyFailed)
            {
                SetStatus(Color.Red, "FAILED");
            }
        }

        private void SetStatus(Color backgroundColor, string label5Text, string message = "")
        {
            Form_container.instance.labelnum5.BackColor = backgroundColor;
            Form_container.instance.labelnum2.BackColor = backgroundColor;
            Form_container.instance.labelnum5.ForeColor = Color.White;
            Form_container.instance.labelnum5.Text = label5Text;

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
            }
        }
        #endregion

        private async void previousTestlogs_Click(object sender, EventArgs e)
        {
            byte[] pathBytes;
            string path;
            FileInfo fi;
            try
            {
                if (modeLabel.Text == "ONLINE MODE")
                {
                    pathBytes = await class_Database.gettestlogPath(serialNumberlabel.Text, "tblCCU1SystemTest");
                    path = Encoding.ASCII.GetString(pathBytes); // Convert byte array to string using ASCII encoding             
                    fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        await Task.Run(() => System.Diagnostics.Process.Start(path));
                    }
                }
                else if(modeLabel.Text == "OFFLINE MODE")
                {
                    FileLocation = config_Dictionary["Offline_LogFileLocation"].ToString();
                    string datetimeoffline = DateTime.Now.ToString("MMddyyyyss");
                    path = $"{FileLocation}{datetimeoffline}{"_"}{$"{serialnumberlabel.Text}_"}{overall}.txt";
                    fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        await Task.Run(() => System.Diagnostics.Process.Start(path));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void rawDatalocation_Click(object sender, EventArgs e)
        {
            string LocalRawDataLocation = "";
            try
            {
                try
                {
                    if (modeLabel.Text == "ONLINE MODE")
                    {
                        LocalRawDataLocation = config_Dictionary["Online_LogFileLocation"];
                    }
                    else if (modeLabel.Text == "OFFLINE MODE")
                    {
                        LocalRawDataLocation = config_Dictionary["Offline_LogFileLocation"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (Directory.Exists(LocalRawDataLocation))
                {
                    System.Diagnostics.Process.Start(LocalRawDataLocation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
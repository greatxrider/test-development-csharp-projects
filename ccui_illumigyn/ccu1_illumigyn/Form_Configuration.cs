using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ccu1_illumigyn.Class;
using static ccu1_illumigyn.Class.class_globals;

namespace ccu1_illumigyn
{
    public partial class Form_Configuration : Form
    {
        public static Form_Configuration instance;  
        private Control[] config_ParameterValues;

        #region TextBox Instances
        public TextBox D1_limitsL;
        public TextBox D1_limitsU;
        public TextBox R39_limitsL;
        public TextBox R39_limitsU;
        public TextBox R43_limitsL;
        public TextBox R43_limitsU;
        public TextBox R42_limitsL;
        public TextBox R42_limitsU;
        public TextBox U10_limitsL;
        public TextBox U10_limitsU;
        public TextBox U11_limitsL;
        public TextBox U11_limitsU;
        public TextBox U12_limitsL;
        public TextBox U12_limitsU;
        public TextBox U13_limitsL;
        public TextBox U13_limitsU;
        public TextBox U5_limitsL;
        public TextBox U5_limitsU;
        public TextBox U6_limitsL;
        public TextBox U6_limitsU;
        public TextBox U7_limitsL;
        public TextBox U7_limitsU;
        public TextBox U8_limitsL;
        public TextBox U8_limitsU;
        public TextBox queryVersiontxtbox;
        public TextBox componentTestertxtbox;
        #endregion
        #region CheckBox Instances
        public CheckBox automatedchckbox;
        public CheckBox customcheckbox;
        #endregion

        public Form_Configuration()
        {
            InitializeComponent();
            instance = this;

            #region TextBox Instances Equivalent
            D1_limitsL = D1_LLtextBox;
            D1_limitsU = D1_ULtextBox;
            R39_limitsL = R39_LLtextBox;
            R39_limitsU = R39_ULtextBox;
            R43_limitsL = R43_LLtextBox;
            R43_limitsU = R43_ULtextBox;
            R42_limitsL = R42_ULtextBox;
            R42_limitsU = R42_ULtextBox;
            U10_limitsL = U10_LLtextBox;
            U10_limitsU = U10_ULtextBox;
            U11_limitsL = U11_LLtextBox;
            U11_limitsU = U11_ULtextBox;
            U12_limitsL = U12_LLtextBox;
            U12_limitsU = U12_ULtextBox;
            U13_limitsL = U13_LLtextBox;
            U13_limitsU = U13_ULtextBox;
            U5_limitsL = U5_LLtextBox;
            U5_limitsU = U5_ULtextBox;
            U6_limitsL = U6_LLtextBox;
            U6_limitsU = U6_ULtextBox;
            U7_limitsL = U7_LLtextBox;
            U7_limitsU = U7_ULtextBox;
            U8_limitsL = U8_LLtextBox;
            U8_limitsU = U8_ULtextBox;
            queryVersiontxtbox = query_versiontextBox;
            componentTestertxtbox = componentTester_locationtextBox;
            #endregion
            #region CheckBox Instances Equivalent
            automatedchckbox = automated_chckbox;
            customcheckbox = custom_chckbox;
            #endregion
        }

        private async void Form_Configuration_Load(object sender, EventArgs e)
        {
            //=================
            //Config Parameters
            //=================
            #region Config Parameters
            config_ParameterValues = new Control[] { db_sourcetextBox, db_nametextBox, db_usernametextBox, db_passwordtextBox, offline_TestLogs_LocationtextBox, online_TestLogs_LocationtextBox, 
            unique_serialIDtextBox, unique_serialLengthtextBox, retest_counttextBox, part_numbertextBox, 
            model_numbertextBox, software_versiontextBox, ionics_FixtureSerialtextBox,
            D1_LLtextBox, D1_ULtextBox, R39_LLtextBox, R39_ULtextBox, R43_LLtextBox, 
            R43_ULtextBox, R42_LLtextBox, R42_ULtextBox, U10_LLtextBox, U10_ULtextBox, U11_LLtextBox, U11_ULtextBox, U12_LLtextBox, U12_ULtextBox,
            U13_LLtextBox, U13_ULtextBox, U5_LLtextBox, U5_ULtextBox, U6_LLtextBox, U6_ULtextBox, U7_LLtextBox, U7_ULtextBox,
            U8_LLtextBox, U8_ULtextBox, query_versiontextBox, componentTester_locationtextBox};

            class_Configuration = new class_configuration(config_MainLocation, config_DefaultName, config_ParameterNames, config_ParameterValues, ref config_Dictionary);
            #endregion

            //==============================
            //Call Load Configuration Method
            //==============================       
            Load_Configuration();
            await LoadConfiguration();

            //=========================
            //Config Values Designation
            //=========================
            #region Designated Values
            db_sourcetextBox.Text = config_Dictionary["Database_Source"];
            db_nametextBox.Text = config_Dictionary["Database_Name"];
            db_usernametextBox.Text = config_Dictionary["Database_Username"];
            db_passwordtextBox.Text = config_Dictionary["Database_Password"];
            offline_TestLogs_LocationtextBox.Text = config_Dictionary["Offline_LogFileLocation"];
            online_TestLogs_LocationtextBox.Text = config_Dictionary["Online_LogFileLocation"];
            software_versiontextBox.Text = config_Dictionary["SoftwareVersion"];
            unique_serialIDtextBox.Text = config_Dictionary["Unique_SerialID"];
            unique_serialLengthtextBox.Text = config_Dictionary["Unique_SerialIDLength"];
            retest_counttextBox.Text = config_Dictionary["RetestCount"];
            part_numbertextBox.Text = config_Dictionary["PartNumber"];
            model_numbertextBox.Text = config_Dictionary["ModelNumber"];
            ionics_FixtureSerialtextBox.Text = config_Dictionary["IonicsFixtureSerial"];

            D1_LLtextBox.Text = config_Dictionary["D1LL"];
            D1_ULtextBox.Text = config_Dictionary["D1UL"];
            R39_LLtextBox.Text = config_Dictionary["R39LL"];
            R39_ULtextBox.Text = config_Dictionary["R39UL"];
            R43_LLtextBox.Text = config_Dictionary["R43LL"];
            R43_ULtextBox.Text = config_Dictionary["R43UL"];
            R42_LLtextBox.Text = config_Dictionary["R42LL"];
            R42_ULtextBox.Text = config_Dictionary["R42UL"];
            U10_LLtextBox.Text = config_Dictionary["U10LL"];
            U10_ULtextBox.Text = config_Dictionary["U10UL"];
            U11_LLtextBox.Text = config_Dictionary["U11LL"];
            U11_ULtextBox.Text = config_Dictionary["U11UL"];
            U12_LLtextBox.Text = config_Dictionary["U12LL"];
            U12_ULtextBox.Text = config_Dictionary["U12UL"];
            U13_LLtextBox.Text = config_Dictionary["U13LL"];
            U13_ULtextBox.Text = config_Dictionary["U13UL"];
            U5_LLtextBox.Text = config_Dictionary["U5LL"];
            U5_ULtextBox.Text = config_Dictionary["U5UL"];
            U6_LLtextBox.Text = config_Dictionary["U6LL"];
            U6_ULtextBox.Text = config_Dictionary["U6UL"];
            U7_LLtextBox.Text = config_Dictionary["U7LL"];
            U7_ULtextBox.Text = config_Dictionary["U7UL"];
            U8_LLtextBox.Text = config_Dictionary["U8LL"];
            U8_ULtextBox.Text = config_Dictionary["U8UL"];
            query_versiontextBox.Text = config_Dictionary["Query_Version"];
            componentTester_locationtextBox.Text = config_Dictionary["ComponentTester_location"];           
            #endregion
        }

        private async void save_button_Click(object sender, EventArgs e)
        {
            //====================
            //Save Configuration
            //====================
            #region Save Configuration
            try
            {
                if (MessageBox.Show("Save Configuration?", "Save Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Form_container.instance.Restart();
                    Form_container.instance.statstext.Clear();

                    for (int i = 0; i < config_ParameterValues.Length; i++)
                    {
                        class_Configuration.WriteIni(config_DefaultName, config_ParameterNames[i], config_ParameterValues[i].Text);
                    }
                    if (class_Configuration.writeConfiginUse("Config in Use", "configInUse", config_DefaultName))
                    {
                        if (class_Configuration.setDictionary(config_DefaultName))
                        {
                            MessageBox.Show("Configuration Saved Successfully!", "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);                         
                        }
                    }

                    else
                    {
                        MessageBox.Show("Configuration Save Unsuccessfull!", "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Configuration Save Unsuccessfull!" + Environment.NewLine + ex.Message, "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void Load_Configuration()
        {
            //====================
            //Clear Configuration
            //====================
            #region Clear Configuration

            for (int i = 0; i <= config_ParameterValues.Length - 1; i++)
            {
                config_ParameterValues[i].Text = string.Empty;
            }

            //====================
            //Load Configuration
            //====================

            for (int i = 0; i < config_ParameterValues.Length; i++)
            {
                if (i < config_ParameterNames.Length)
                {
                    config_ParameterValues[i].Text = class_Configuration.ReadIni(config_DefaultName, config_ParameterNames[i]);
                }
                else
                {
                    // Handle the error, such as displaying a message or logging it
                    MessageBox.Show("Index out of range: i is not within the valid range of indices.", "Load Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
        }

        public async Task<bool> LoadConfiguration()
        {
            //============================
            //Configuration Initialization
            //============================
            #region Initialization of Configuration
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
            #endregion
        }
     
        //=========================
        //Automated and Custom Mode
        //=========================
        #region Automated & Custom Mode
        private void automated_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (automated_chckbox.Checked)
            {
                Form_ccu1.instance.checkboxes_status_automated();
                custom_chckbox.Enabled = false;
            }
            else
            {
                custom_chckbox.Enabled = true;
                custom_chckbox.Checked = true;
            }
        }

        private void custom_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (custom_chckbox.Checked)
            {
                Form_ccu1.instance.checkboxes_status_custom();
                automated_chckbox.Enabled = false;
            }
            else
            {
                automated_chckbox.Enabled = true;
                automatedchckbox.Checked = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (Form_ccu1.instance.power_checkbox_1.Enabled == true)
            { Form_Configuration.instance.customcheckbox.Checked = true; }

            if (Form_ccu1.instance.power_checkbox_1.Enabled == false)
            { Form_Configuration.instance.automatedchckbox.Checked = true; }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                save_button.Hide();
            }
            else
            {
                save_button.Show();
            }
        }
        #endregion

        //=============
        //Show Password
        //=============
        #region Check/Uncheck Show/Hide Password
        private void show_passwordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_passwordcheckBox.Checked)
            {
                db_passwordtextBox.UseSystemPasswordChar = false;
            }
            else
            {
                db_passwordtextBox.UseSystemPasswordChar = true;
            }
        }
        #endregion

        private void closeconfig_Click(object sender, EventArgs e)
        {
            this.Hide();
        }     
    }
}
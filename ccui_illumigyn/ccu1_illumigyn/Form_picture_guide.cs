using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ccu1_illumigyn.Class.class_globals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace ccu1_illumigyn.Resources
{
    public partial class Form_picture_guide : Form
    {
        public static Form_picture_guide instance;

        #region Picture Box Instances        
        public PictureBox d1pin1guide;
        public PictureBox R39guide;
        #endregion

        #region Textbox Instances
        public TextBox errorcodetext;
        #endregion

        #region Button Instances
        public Button button_1;
        #endregion

        #region Label Instances
        public Label testguidelabel;
        #endregion

        public Form_picture_guide()
        {
            InitializeComponent();
            instance = this;

            this.CenterToScreen();
            this.BringToFront();
            
            #region Instances Equivalent
            d1pin1guide = D1_PIN1_GUIDE;
            R39guide = R39_PIN1_GUIDE;
            testguidelabel = Label_Guide;
            button_1 = Test_button;
            errorcodetext = errorcodebox;
            #endregion
        }

        //============================
        //Configuration Initialization
        //============================
        #region Close Guide when Failed
        private void closeiffailed()
        {
            if (Form_container.instance.labelnum5.Text == "FAILED")
            {
                this.Hide();
                Form_container.instance.Button12.PerformClick();
                MessageBox.Show("TEST FAILED");
                continueTest = false;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            #region Pass Voltage Values Towards CCU1 Form for Test
            if (Measured_voltage_txtbox.Text != "")
            {
                Label_Guide.Text.ToString();
                continueTest = true;

                while (continueTest)
                {
                    testStep = 0;

                    #region D1 PIN 1 TEST
                    if (Form_ccu1.instance.power_checkbox_1.Checked == true && Label_Guide.Text == "D1 PIN 1 TEST")
                    {
                        Form_ccu1.instance.p1textbox.Text = Measured_voltage_txtbox.Text;

                        closeiffailed();

                        if (!continueTest)
                        {
                            errorcodebox.Text = "D1 PIN 1 VOLTAGE TEST ERROR";
                            return;
                        }

                        Measured_voltage_txtbox.Clear();

                        if (Form_ccu1.instance.p2status_i.Text != "SKIPPED")
                        {
                            Form_picture_guide.instance.testguidelabel.Text = "R39 PIN 1 TEST";
                            Form_picture_guide.instance.R39guide.BringToFront();

                            Form_ccu1.instance.p2status_i.Text = "ONGOING";
                            Form_ccu1.instance.p2status_i.BackColor = Color.Yellow;
                            Form_ccu1.instance.p2status_i.ForeColor = Color.Black;
                            return;
                        }
                        else
                        {
                            updatestats();
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region R39 PIN 1 TEST
                    if (Form_ccu1.instance.power_checkbox_2.Checked == true || testStep == 1)
                    {
                        if (Label_Guide.Text == "R39 PIN 1 TEST")
                        {                         
                            Form_ccu1.instance.p2textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "R39 PIN 1 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.p3status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "R43 PIN 1 TEST";
                                R43_PIN1_GUIDE.BringToFront();

                                Form_ccu1.instance.p3status_i.Text = "ONGOING";
                                Form_ccu1.instance.p3status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.p3status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region R43 PIN 1 TEST
                    if (Form_ccu1.instance.power_checkbox_3.Checked == true || testStep == 2)
                    {
                        if (Label_Guide.Text == "R43 PIN 1 TEST" )
                        {                     
                            Form_ccu1.instance.p3textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "R43 PIN 1 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.p4status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "R42 PIN 1 TEST";
                                R42_PIN1_GUIDE.BringToFront();

                                Form_ccu1.instance.p4status_i.Text = "ONGOING";
                                Form_ccu1.instance.p4status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.p4status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region R42 PIN 1 TEST
                    if (Form_ccu1.instance.power_checkbox_4.Checked == true || testStep == 3)
                    {
                        if (Label_Guide.Text == "R42 PIN 1 TEST")
                        {                       
                            Form_ccu1.instance.p4textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "R42 PIN 1 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.s1status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U10 PIN 5 TEST";
                                U10_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.s1status_i.Text = "ONGOING";
                                Form_ccu1.instance.s1status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.s1status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U10 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_checkbox_1.Checked == true || testStep == 4)
                    {
                        if (Label_Guide.Text == "U10 PIN 5 TEST")
                        {                          
                            Form_ccu1.instance.s1textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "U10 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.s2status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U11 PIN 5 TEST";
                                U11_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.s2status_i.Text = "ONGOING";
                                Form_ccu1.instance.s2status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.s2status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U11 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_checkbox_2.Checked == true || testStep == 5)
                    {
                        if (Label_Guide.Text == "U11 PIN 5 TEST")
                        {                           
                            Form_ccu1.instance.s2textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "U11 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.s3status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U12 PIN 5 TEST";
                                U12_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.s3status_i.Text = "ONGOING";
                                Form_ccu1.instance.s3status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.s3status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U12 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_checkbox_3.Checked == true || testStep == 6)
                    {
                        if (Label_Guide.Text == "U12 PIN 5 TEST")
                        {                           
                            Form_ccu1.instance.s3textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "U12 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.s4status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U13 PIN 5 TEST";
                                U13_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.s4status_i.Text = "ONGOING";
                                Form_ccu1.instance.s4status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.s4status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U13 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_checkbox_4.Checked == true || testStep == 7)
                    {
                        if (Label_Guide.Text == "U13 PIN 5 TEST" )
                        {                          
                            Form_ccu1.instance.s4textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "U13 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.sm1status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U5 PIN 5 TEST";
                                U5_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.sm1status_i.Text = "ONGOING";
                                Form_ccu1.instance.sm1status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.sm1status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U5 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_mono_checkbox_1.Checked == true || testStep == 8)
                    {
                        if (Label_Guide.Text == "U5 PIN 5 TEST")
                        {                     
                            Form_ccu1.instance.sm1textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();
                            if (!continueTest)
                            {
                                errorcodebox.Text = "U5 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.sm2status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U6 PIN 5 TEST";
                                U6_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.sm2status_i.Text = "ONGOING";
                                Form_ccu1.instance.sm2status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.sm2status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U6 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_mono_checkbox_2.Checked == true || testStep == 9)
                    {
                        if (Label_Guide.Text == "U6 PIN 5 TEST")
                        {                      
                            Form_ccu1.instance.sm2textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();

                            if (!continueTest)
                            {
                                errorcodebox.Text = "U6 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.sm3status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U7 PIN 5 TEST";
                                U7_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.sm3status_i.Text = "ONGOING";
                                Form_ccu1.instance.sm3status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.sm3status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U7 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_mono_checkbox_3.Checked == true || testStep == 10)
                    {
                        if (Label_Guide.Text == "U7 PIN 5 TEST" )
                        {                           
                            Form_ccu1.instance.sm3textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();

                            if (!continueTest)
                            {
                                errorcodebox.Text = "U7 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }
                            Measured_voltage_txtbox.Clear();

                            if (Form_ccu1.instance.sm4status_i.Text != "SKIPPED")
                            {
                                Form_picture_guide.instance.testguidelabel.Text = "U8 PIN 5 TEST";
                                U8_PIN5_GUIDE.BringToFront();

                                Form_ccu1.instance.sm4status_i.Text = "ONGOING";
                                Form_ccu1.instance.sm4status_i.BackColor = Color.Yellow;
                                Form_ccu1.instance.sm4status_i.ForeColor = Color.Black;
                            }
                            else
                            {
                                updatestats();
                                return;
                            }           
                            return;
                        }
                    }
                    else { testStep++; }
                    #endregion

                    #region U8 PIN 5 TEST
                    if (Form_ccu1.instance.sensor_mono_checkbox_4.Checked == true || testStep == 11)
                    {
                        if (Label_Guide.Text == "U8 PIN 5 TEST")
                        {
                            Form_ccu1.instance.sm4textbox.Text = Measured_voltage_txtbox.Text;
                            closeiffailed();

                            if (!continueTest)
                            {
                                errorcodebox.Text = "U8 PIN 5 VOLTAGE TEST ERROR";
                                return;
                            }

                            Measured_voltage_txtbox.Clear();
                            this.Close();
                            Form_container.instance.Button12.PerformClick();
                        }
                    }
                    else
                    {
                        break;
                    }
                    break;
                    #endregion
                }        
            }
            else
            {
                MessageBox.Show("PLEASE INSERT A VALUE","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
        }

        //=====================================
        //Commands Controls Keypress on TextBox
        //=====================================
        #region Keypress Functions on TextBox
        private void Measured_voltage_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && Measured_voltage_txtbox.Text.Contains('.'))
            {
                e.Handled = true; 
                return;
            }

            if (e.KeyChar == '.' && Measured_voltage_txtbox.SelectionStart == 0)
            {
                Measured_voltage_txtbox.Text = "0" + Measured_voltage_txtbox.Text + "0";
                Measured_voltage_txtbox.SelectionStart = 1;
            }

            if (Measured_voltage_txtbox.Text.Contains('.'))
            {
                int decimalIndex = Measured_voltage_txtbox.Text.IndexOf('.');
                int maxDigitsAfterDecimal = 6;

                if (Measured_voltage_txtbox.Text.Length - decimalIndex > maxDigitsAfterDecimal + 1)
                {
                    e.Handled = true; 
                    return;
                }
            }
        }

        private void Measured_voltage_txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Test_button.PerformClick();
            }         
        }
        #endregion

        //=================================
        //Determines if the test is Skipped
        //=================================
        #region Skipped Test
        private void Form_picture_guide_Shown(object sender, EventArgs e)
        {
            Measured_voltage_txtbox.Focus();
            UpdateLabelStatus(Form_ccu1.instance.sensor_mono_checkbox_4, "U8 PIN 5 TEST", Form_ccu1.instance.sm4status_i, U8_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_mono_checkbox_3, "U7 PIN 5 TEST", Form_ccu1.instance.sm3status_i, U7_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_mono_checkbox_2, "U6 PIN 5 TEST", Form_ccu1.instance.sm2status_i, U6_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_mono_checkbox_1, "U5 PIN 5 TEST", Form_ccu1.instance.sm1status_i, U5_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_checkbox_4, "U13 PIN 5 TEST", Form_ccu1.instance.s4status_i, U13_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_checkbox_3, "U12 PIN 5 TEST", Form_ccu1.instance.s3status_i, U12_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_checkbox_2, "U11 PIN 5 TEST", Form_ccu1.instance.s2status_i, U11_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.sensor_checkbox_1, "U10 PIN 5 TEST", Form_ccu1.instance.s1status_i, U10_PIN5_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.power_checkbox_4, "R42 PIN 1 TEST", Form_ccu1.instance.p4status_i, R42_PIN1_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.power_checkbox_3, "R43 PIN 1 TEST", Form_ccu1.instance.p3status_i, R43_PIN1_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.power_checkbox_2, "R39 PIN 1 TEST", Form_ccu1.instance.p2status_i, R39_PIN1_GUIDE);
            UpdateLabelStatus(Form_ccu1.instance.power_checkbox_1, "D1 PIN 1 TEST", Form_ccu1.instance.p1status_i, D1_PIN1_GUIDE);
            Form_serialnumber.instance.Ongoing();          
        }

        private void UpdateLabelStatus(CheckBox checkBox, string labelText, TextBox statusTextBox, PictureBox pictureGuide)
        {
            if (checkBox.Checked)
            {
                Form_picture_guide.instance.testguidelabel.Text = labelText;
                pictureGuide.BringToFront();
            }
            else
            {
                statusTextBox.Text = "SKIPPED";
                statusTextBox.ForeColor = Color.White;
                statusTextBox.BackColor = Color.Blue;
            }
        }
        #endregion

        //===================================
        //Determines Which will be Test First 
        //===================================
        #region Determine Which Test is First
        private void updatestats()
        {
            bool test = true;
            while (test)
            {
                #region D1 PIN 1 TEST
                if (Form_ccu1.instance.p1textbox.Text == "" && Form_ccu1.instance.p1status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "D1 PIN 1 TEST";
                    Form_picture_guide.instance.d1pin1guide.BringToFront();
                    Form_ccu1.instance.p1status_i.Text = "ONGOING";
                    Form_ccu1.instance.p1status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.p1status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region R39 PIN 1 TEST
                if (Form_ccu1.instance.p2textbox.Text == "" && Form_ccu1.instance.p2status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "R39 PIN 1 TEST";
                    Form_picture_guide.instance.R39guide.BringToFront();
                    Form_ccu1.instance.p2status_i.Text = "ONGOING";
                    Form_ccu1.instance.p2status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.p2status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region R43 PIN 1 TEST
                if (Form_ccu1.instance.p3textbox.Text == "" && Form_ccu1.instance.p3status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "R43 PIN 1 TEST";
                    R43_PIN1_GUIDE.BringToFront();
                    Form_ccu1.instance.p3status_i.Text = "ONGOING";
                    Form_ccu1.instance.p3status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.p3status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region R42 PIN 1 TEST
                if (Form_ccu1.instance.p4textbox.Text == "" && Form_ccu1.instance.p4status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "R42 PIN 1 TEST";
                    R42_PIN1_GUIDE.BringToFront();
                    Form_ccu1.instance.p4status_i.Text = "ONGOING";
                    Form_ccu1.instance.p4status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.p4status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U10 PIN 5 TEST
                if (Form_ccu1.instance.s1textbox.Text == "" && Form_ccu1.instance.s1status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U10 PIN 5 TEST";
                    U10_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.s1status_i.Text = "ONGOING";
                    Form_ccu1.instance.s1status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.s1status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U11 PIN 5 TEST
                if (Form_ccu1.instance.s2textbox.Text == "" && Form_ccu1.instance.s2status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U11 PIN 5 TEST";
                    U11_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.s2status_i.Text = "ONGOING";
                    Form_ccu1.instance.s2status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.s2status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U12 PIN 5 TEST
                if (Form_ccu1.instance.s3textbox.Text == "" && Form_ccu1.instance.s3status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U12 PIN 5 TEST";
                    U12_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.s3status_i.Text = "ONGOING";
                    Form_ccu1.instance.s3status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.s3status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U13 PIN 5 TEST
                if (Form_ccu1.instance.s4textbox.Text == "" && Form_ccu1.instance.s4status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U13 PIN 5 TEST";
                    U13_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.s4status_i.Text = "ONGOING";
                    Form_ccu1.instance.s4status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.s4status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U5 PIN 5 TEST
                if (Form_ccu1.instance.sm1textbox.Text == "" && Form_ccu1.instance.sm1status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U5 PIN 5 TEST";
                    U5_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.sm1status_i.Text = "ONGOING";
                    Form_ccu1.instance.sm1status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.sm1status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U6 PIN 5 TEST
                if (Form_ccu1.instance.sm2textbox.Text == "" && Form_ccu1.instance.sm2status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U6 PIN 5 TEST";
                    U6_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.sm2status_i.Text = "ONGOING";
                    Form_ccu1.instance.sm2status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.sm2status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U7 PIN 5 TEST
                if (Form_ccu1.instance.sm3textbox.Text == "" && Form_ccu1.instance.sm3status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U7 PIN 5 TEST";
                    U7_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.sm3status_i.Text = "ONGOING";
                    Form_ccu1.instance.sm3status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.sm3status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion

                #region U8 PIN 5 TEST
                if (Form_ccu1.instance.sm4textbox.Text == "" && Form_ccu1.instance.sm4status_i.Text != "SKIPPED")
                {
                    Label_Guide.Text = "U8 PIN 5 TEST";
                    U8_PIN5_GUIDE.BringToFront();
                    Form_ccu1.instance.sm4status_i.Text = "ONGOING";
                    Form_ccu1.instance.sm4status_i.BackColor = Color.Yellow;
                    Form_ccu1.instance.sm4status_i.ForeColor = Color.Black;
                    break;
                }
                else
                {
                }
                #endregion
                break;
            }
        }
        #endregion
    }
}

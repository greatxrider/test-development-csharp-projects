using DAQ970A_Software.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DAQ970A_Software.Class.Class_DAQ970A;
using static DAQ970A_Software.Class.Class_Globals;
using static DAQ970A_Software.Class.Class_SerialPort;
using static DAQ970A_Software.Class.Class_SerialPort2;

namespace DAQ970A_Software
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        private Class_SerialPort class_serialport;
        private Class_SerialPort2 class_serialport2;
        private Class_DAQ970A class_daq970a;    
        public ProgressBar progressbar;
        public ProgressBar progressbar_relay_1;
        public ProgressBar progressbar_relay_2;
        public TextBox getid_1;
        public Button open_connection;
        public Button open_connection_relay1;
        public Button open_connection_relay2;

        #region Relay 1 Textbox Instances
        public TextBox relay1read;
        public TextBox relay2read;
        public TextBox relay3read;
        public TextBox relay4read;
        public TextBox relay5read;
        public TextBox relay6read;
        public TextBox relay7read;
        public TextBox relay8read;
        public TextBox relay9read;
        public TextBox relay10read;
        public TextBox relay11read;
        public TextBox relay12read;
        public TextBox relay13read;
        public TextBox relay14read;
        public TextBox relay15read;
        public TextBox relay16read;
        public TextBox relay17read;
        public TextBox relay18read;
        public TextBox relay19read;
        public TextBox relay20read;
        #endregion
        #region Relay 2 Textbox Instances
        public TextBox relay1read_2;
        public TextBox relay2read_2;
        public TextBox relay3read_2;
        public TextBox relay4read_2;
        public TextBox relay5read_2;
        public TextBox relay6read_2;
        public TextBox relay7read_2;
        public TextBox relay8read_2;
        public TextBox relay9read_2;
        public TextBox relay10read_2;
        public TextBox relay11read_2;
        public TextBox relay12read_2;
        public TextBox relay13read_2;
        public TextBox relay14read_2;
        public TextBox relay15read_2;
        public TextBox relay16read_2;
        public TextBox relay17read_2;
        public TextBox relay18read_2;
        public TextBox relay19read_2;
        public TextBox relay20read_2;
        #endregion

        public Form1()
        {
            InitializeComponent();

            instance = this; //get access to all controls on another form

            #region Buttons & Progressbar
            open_connection = open_connect_button;
            progressbar = progressbar_connection;
            getid_1 = getid_textbox_1;
            open_connection_relay1 = open_connection_relay_1;
            open_connection_relay2 = open_connection_relay_2;
            progressbar_relay_1 = progressbar_relay1;
            progressbar_relay_2 = progressbar_relay2;
            #endregion
            #region Instances Relay Reading 1 Textboxes
            relay1read = relay1_read_textbox1;
            relay2read = relay1_read_textbox2;
            relay3read = relay1_read_textbox3;
            relay4read = relay1_read_textbox4;
            relay5read = relay1_read_textbox5;
            relay6read = relay1_read_textbox6;
            relay7read = relay1_read_textbox7;
            relay8read = relay1_read_textbox8;
            relay9read = relay1_read_textbox9;
            relay10read = relay1_read_textbox10;
            relay11read = relay1_read_textbox11;
            relay12read = relay1_read_textbox12;
            relay13read = relay1_read_textbox13;
            relay14read = relay1_read_textbox14;
            relay15read = relay1_read_textbox15;
            relay16read = relay1_read_textbox16;
            relay17read = relay1_read_textbox17;
            relay18read = relay1_read_textbox18;
            relay19read = relay1_read_textbox19;
            relay20read = relay1_read_textbox20;
            #endregion
            #region Instances Relay Reading 2 Textboxes
            relay1read_2 = relay2_read_textbox1;
            relay2read_2 = relay2_read_textbox2;
            relay3read_2 = relay2_read_textbox3;
            relay4read_2 = relay2_read_textbox4;
            relay5read_2 = relay2_read_textbox5;
            relay6read_2 = relay2_read_textbox6;
            relay7read_2 = relay2_read_textbox7;
            relay8read_2 = relay2_read_textbox8;
            relay9read_2 = relay2_read_textbox9;
            relay10read_2 = relay2_read_textbox10;
            relay11read_2 = relay2_read_textbox11;
            relay12read_2 = relay2_read_textbox12;
            relay13read_2 = relay2_read_textbox13;
            relay14read_2 = relay2_read_textbox14;
            relay15read_2 = relay2_read_textbox15;
            relay16read_2 = relay2_read_textbox16;
            relay17read_2 = relay2_read_textbox17;
            relay18read_2 = relay2_read_textbox18;
            relay19read_2 = relay2_read_textbox19;
            relay20read_2 = relay2_read_textbox20;
            #endregion         
        }

        private void Form1_Load(object sender, EventArgs e)
        {                    
            isRelayOn = new bool[20];
            #region Getting Port Names Functions
            Getport1();
            com_port_1.Items.AddRange(ports);

            Getport2();
            com_port_2.Items.AddRange(ports2);

            #endregion  
        }

        //==============
        //DAQ Connection
        //==============

        private void open_connect_button_Click(object sender, EventArgs e)
        {
            progressbar_connection.Value = 25;
            class_daq970a = new Class_DAQ970A(usb_address_txtbox.Text);        
        }

        //=====================
        //Serial1 Communication
        //=====================

        #region Serial 1 Communication

        public void Getport1()
        {
            class_serialport = new Class_SerialPort(com_port_1.Text, Convert.ToInt32(baud_rate_1.Text)); ;
            class_serialport.GetPortName();
        }
       
        private void open_connection_relay_1_Click(object sender, EventArgs e)
        {         
            if (open_connection_relay_1.Text == "OPEN")
            {
                Getport1();
                class_serialport.OpenConnection();
                read_all_button_1.PerformClick();

                checkthestatus1();
                read_reset_button_1.PerformClick();
            }
            else
            {
                class_serialport.OpenConnection();
            }
        }

        private void checkthestatus1()
        {
            for (int i = 1; i <= 20; i++)
            {
                string relayReadTextBoxName = "relay1_read_textbox" + i;
                string relayOpenButtonName = "relay1" + "button" + i;

                TextBox relayReadTextBox = Controls.Find(relayReadTextBoxName, true).FirstOrDefault() as TextBox;
                Button relayOpenButton = Controls.Find(relayOpenButtonName, true).FirstOrDefault() as Button;

                if (relayReadTextBox != null && relayReadTextBox.Text.Contains("on") && relayOpenButton != null)
                {
                    relayOpenButton.PerformClick();
                }
            }
        }

        #endregion

        //=====================
        //Serial2 Communication
        //=====================

        #region Serial 2 Communication

        public void Getport2()
        {
            class_serialport2 = new Class_SerialPort2(com_port_2.Text, Convert.ToInt32(baud_rate_2.Text));
            class_serialport2.GetPortName();
        }

        private void open_connection_relay_2_Click(object sender, EventArgs e)
        {            
            if (open_connection_relay_2.Text == "OPEN")
            {
                Getport2();
                class_serialport2.OpenConnection();
                read_all_button_2.PerformClick();

                checkthestatus2();
                read_reset_button_2.PerformClick();
            }
            else
            {
                class_serialport2.OpenConnection();
            }
        }
        
        private void checkthestatus2()
        {
            for (int i = 1; i <= 20; i++)
            {
                string relayReadTextBoxName = "relay2_read_textbox" + i;
                string relayOpenButtonName = "relay2" + "button" + i;

                TextBox relayReadTextBox = Controls.Find(relayReadTextBoxName, true).FirstOrDefault() as TextBox;
                Button relayOpenButton = Controls.Find(relayOpenButtonName, true).FirstOrDefault() as Button;

                if (relayReadTextBox != null && relayReadTextBox.Text.Contains("on") && relayOpenButton != null)
                {
                    relayOpenButton.PerformClick();
                }
            }
        }

        #endregion

        //=====================
        //Channels Functions
        //=====================

        #region Channel_1
        private async void measure_voltage_button_1_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "101");
        }
        private async void measure_current_button_1_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1,"101");
        }
        private async void measure_resistance_button_1_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "101");
        }
        private async void measure_temperature_button_1_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("101");
        }       
        private async void selftest_button_Click(object sender, EventArgs e)
        {
            await class_daq970a.selfTest();
        }
        private async void getid_button_Click(object sender, EventArgs e)
        {
            getid_1.Text = class_daq970a.getId().ToString();
        }
        #endregion

        #region Channel_2
        private async void measure_voltage_button_2_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "102");
        }

        private async void measure_current_button_2_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "102");
        }

        private async void measure_resistance_button_2_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "102");
        }

        private async void measure_temperature_button_2_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("102");
        }
        #endregion

        #region Channel_3
        private async void measure_voltage_button_3_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "103");
        }

        private async void measure_current_button_3_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "103");
        }

        private async void measure_resistance_button_3_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "103");
        }

        private async void measure_temperature_button_3_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("103");
        }
        #endregion

        #region Channel_4
        private async void measure_voltage_button_4_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "104");
        }

        private async void measure_current_button_4_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "104");
        }

        private async void measure_resistance_button_4_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "104");
        }

        private async void measure_temperature_button_4_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("104");
        }
        #endregion

        #region Channel_5
        private async void measure_voltage_button_5_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "105");
        }

        private async void measure_current_button_5_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "105");
        }

        private async void measure_resistance_button_5_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "105");
        }

        private async void measure_temperature_button_5_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("105");
        }
        #endregion

        #region Channel_6
        private async void measure_voltage_button_6_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "106");
        }

        private async void measure_current_button_6_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "106");
        }

        private async void measure_resistance_button_6_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "106");
        }

        private async void measure_temperature_button_6_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("106");
        }
        #endregion

        #region Channel_7
        private async void measure_voltage_button_7_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "107");
        }

        private async void measure_current_button_7_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "107");
        }

        private async void measure_resistance_button_7_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "107");
        }

        private async void measure_temperature_button_7_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("107");
        }
        #endregion

        #region Channel_8
        private async void measure_voltage_button_8_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "108");
        }

        private async void measure_current_button_8_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "108");
        }

        private async void measure_resistance_button_8_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "108");
        }

        private async void measure_temperature_button_8_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("108");
        }
        #endregion

        #region Channel_9
        private async void measure_voltage_button_9_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "109");
        }

        private async void measure_current_button_9_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "109");
        }

        private async void measure_resistance_button_9_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "109");
        }

        private async void measure_temperature_button_9_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("109");
        }
        #endregion

        #region Channel_10
        private async void measure_voltage_button_10_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "110");
        }

        private async void measure_current_button_10_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "110");
        }

        private async void measure_resistance_button_10_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "110");
        }

        private async void measure_temperature_button_10_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("110");
        }
        #endregion

        #region Channel_11
        private async void measure_voltage_button_11_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "111");
        }

        private async void measure_current_button_11_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "111");
        }

        private async void measure_resistance_button_11_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "111");
        }

        private async void measure_temperature_button_11_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("111");
        }
        #endregion

        #region Channel_12
        private async void measure_voltage_button_12_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "112");
        }

        private async void measure_current_button_12_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "112");
        }

        private async void measure_resistance_button_12_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "112");
        }

        private async void measure_temperature_button_12_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("112");
        }
        #endregion

        #region Channel_13
        private async void measure_voltage_button_13_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "113");
        }

        private async void measure_current_button_13_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "113");
        }

        private async void measure_resistance_button_13_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "113");
        }

        private async void measure_temperature_button_13_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("113");
        }
        #endregion

        #region Channel_14
        private async void measure_voltage_button_14_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "114");
        }

        private async void measure_current_button_14_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "114");
        }

        private async void measure_resistance_button_14_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "114");
        }

        private async void measure_temperature_button_14_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("114");
        }
        #endregion

        #region Channel_15
        private async void measure_voltage_button_15_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "115");
        }

        private async void measure_current_button_15_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "115");
        }

        private async void measure_resistance_button_15_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "115");
        }

        private async void measure_temperature_button_15_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("115");
        }
        #endregion

        #region Channel_16
        private async void measure_voltage_button_16_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "116");
        }

        private async void measure_current_button_16_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "116");
        }

        private async void measure_resistance_button_16_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "116");
        }

        private async void measure_temperature_button_16_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("116");
        }
        #endregion

        #region Channel_17
        private async void measure_voltage_button_17_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "117");
        }

        private async void measure_current_button_17_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "117");
        }

        private async void measure_resistance_button_17_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "117");
        }

        private async void measure_temperature_button_17_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("117");
        }
        #endregion

        #region Channel_18
        private async void measure_voltage_button_18_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "118");
        }

        private async void measure_current_button_18_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "118");
        }

        private async void measure_resistance_button_18_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "118");
        }

        private async void measure_temperature_button_18_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("118");
        }
        #endregion

        #region Channel_19
        private async void measure_voltage_button_19_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "119");
        }

        private async void measure_current_button_19_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "119");
        }

        private async void measure_resistance_button_19_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "119");
        }

        private async void measure_temperature_button_19_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("119");
        }
        #endregion

        #region Channel_20
        private async void measure_voltage_button_20_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureVoltage(300, "120");
        }

        private async void measure_current_button_20_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(1, "120");
        }

        private async void measure_resistance_button_20_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureCurrent(100000, "120");
        }

        private async void measure_temperature_button_20_Click(object sender, EventArgs e)
        {
            await class_daq970a.measureTemp("120");
        }
        #endregion

        //=====================
        //Relay 1 Functions
        //=====================

        #region Relay 1 ON/OFF Buttons Functions
        private void relay1button1_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[0])
                {
                    class_serialport.turnOffRelay("0");
                    isRelayOn[0] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("0");
                    isRelayOn[0] = true;
                }

                relay1button1.Text = isRelayOn[0] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button2_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[1])
                {
                    class_serialport.turnOffRelay("1");
                    isRelayOn[1] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("1");
                    isRelayOn[1] = true;
                }

                relay1button2.Text = isRelayOn[1] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button3_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[2])
                {
                    class_serialport.turnOffRelay("2");
                    isRelayOn[2] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("2");
                    isRelayOn[2] = true;
                }

                relay1button3.Text = isRelayOn[2] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button4_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[3])
                {
                    class_serialport.turnOffRelay("3");
                    isRelayOn[3] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("3");
                    isRelayOn[3] = true;
                }

                relay1button4.Text = isRelayOn[3] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button5_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[4])
                {
                    class_serialport.turnOffRelay("4");
                    isRelayOn[4] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("4");
                    isRelayOn[4] = true;
                }

                relay1button5.Text = isRelayOn[4] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button6_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[5])
                {
                    class_serialport.turnOffRelay("5");
                    isRelayOn[5] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("5");
                    isRelayOn[5] = true;
                }

                relay1button6.Text = isRelayOn[5] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relay1button7_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[6])
                {
                    class_serialport.turnOffRelay("6");
                    isRelayOn[6] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("6");
                    isRelayOn[6] = true;
                }

                relay1button7.Text = isRelayOn[6] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button8_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[7])
                {
                    class_serialport.turnOffRelay("7");
                    isRelayOn[7] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("7");
                    isRelayOn[7] = true;
                }

                relay1button8.Text = isRelayOn[7] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button9_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[8])
                {
                    class_serialport.turnOffRelay("8");
                    isRelayOn[8] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("8");
                    isRelayOn[8] = true;
                }

                relay1button9.Text = isRelayOn[8] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button10_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[9])
                {
                    class_serialport.turnOffRelay("9");
                    isRelayOn[9] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("9");
                    isRelayOn[9] = true;
                }

                relay1button10.Text = isRelayOn[9] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button11_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[10])
                {
                    class_serialport.turnOffRelay("A");
                    isRelayOn[10] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("A");
                    isRelayOn[10] = true;
                }

                relay1button11.Text = isRelayOn[10] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button12_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[11])
                {
                    class_serialport.turnOffRelay("B");
                    isRelayOn[11] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("B");
                    isRelayOn[11] = true;
                }

                relay1button12.Text = isRelayOn[11] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button13_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[12])
                {
                    class_serialport.turnOffRelay("C");
                    isRelayOn[12] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("C");
                    isRelayOn[12] = true;
                }

                relay1button13.Text = isRelayOn[12] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button14_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[13])
                {
                    class_serialport.turnOffRelay("D");
                    isRelayOn[13] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("D");
                    isRelayOn[13] = true;
                }

                relay1button14.Text = isRelayOn[13] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button15_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[14])
                {
                    class_serialport.turnOffRelay("E");
                    isRelayOn[14] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("E");
                    isRelayOn[14] = true;
                }

                relay1button15.Text = isRelayOn[14] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button16_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[15])
                {
                    class_serialport.turnOffRelay("F");
                    isRelayOn[15] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("F");
                    isRelayOn[15] = true;
                }

                relay1button16.Text = isRelayOn[15] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button17_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[16])
                {
                    class_serialport.turnOffRelay("G");
                    isRelayOn[16] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("G");
                    isRelayOn[16] = true;
                }

                relay1button17.Text = isRelayOn[16] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button18_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[17])
                {
                    class_serialport.turnOffRelay("H");
                    isRelayOn[17] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("H");
                    isRelayOn[17] = true;
                }

                relay1button18.Text = isRelayOn[17] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button19_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[18])
                {
                    class_serialport.turnOffRelay("I");
                    isRelayOn[18] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("I");
                    isRelayOn[18] = true;
                }

                relay1button19.Text = isRelayOn[18] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay1button20_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[19])
                {
                    class_serialport.turnOffRelay("J");
                    isRelayOn[19] = false;
                }
                else
                {
                    class_serialport.turnOnRelay("J");
                    isRelayOn[19] = true;
                }

                relay1button20.Text = isRelayOn[19] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Relay 1 Read Buttons Functions
        private void relay1read_button1_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("0");
        }

        private void relay1read_button2_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("1");
        }

        private void relay1read_button3_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("2");
        }

        private void relay1read_button4_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("3");
        }

        private void relay1read_button5_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("4");
        }

        private void relay1read_button6_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("5");
        }

        private void relay1read_button7_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("6");
        }

        private void relay1read_button8_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("7");
        }

        private void relay1read_button9_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("8");
        }

        private void relay1read_button10_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("9");
        }

        private void relay1read_button11_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("A");
        }

        private void relay1read_button12_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("B");
        }

        private void relay1read_button13_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("C");
        }

        private void relay1read_button14_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("D");
        }

        private void relay1read_button15_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("E");
        }

        private void relay1read_button16_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("F");
        }

        private void relay1read_button17_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("G");
        }

        private void relay1read_button18_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("H");
        }

        private void relay1read_button19_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("I");
        }

        private void relay1read_button20_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("J");
        }
        #endregion

        #region Relay 1 All On, Off
        private void all_on_button_1_Click(object sender, EventArgs e)
        {
            class_serialport.turnOnAllRelay();
            Button[] ButtonsRelay1 = new Button[] {
                relay1button1,
                relay1button2,
                relay1button3,
                relay1button4,
                relay1button5,
                relay1button6,
                relay1button7,
                relay1button8,
                relay1button9,
                relay1button10,
                relay1button11,
                relay1button12,
                relay1button13,
                relay1button14,
                relay1button15,
                relay1button16,
                relay1button17,
                relay1button18,
                relay1button19,
                relay1button20
            };

            foreach (Button button in ButtonsRelay1)
            {
                button.Text = "OFF";
            }
        }

        private void all_off_button_1_Click(object sender, EventArgs e)
        {
            class_serialport.turnOffAllRelay();
            Button[] ButtonsRelay1 = new Button[] {
                relay1button1,
                relay1button2,
                relay1button3,
                relay1button4,
                relay1button5,
                relay1button6,
                relay1button7,
                relay1button8,
                relay1button9,
                relay1button10,
                relay1button11,
                relay1button12,
                relay1button13,
                relay1button14,
                relay1button15,
                relay1button16,
                relay1button17,
                relay1button18,
                relay1button19,
                relay1button20
            };

            foreach (Button button in ButtonsRelay1)
            {
                button.Text = "ON";
            }
        }
        #endregion

        #region Relay 1 ReadAll Button Function
        private void read_all_button_1_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                Button[] Buttons = new Button[] {
                relay1read_button1,
                relay1read_button2,
                relay1read_button3,
                relay1read_button4,
                relay1read_button5,
                relay1read_button6,
                relay1read_button7,
                relay1read_button8,
                relay1read_button9,
                relay1read_button10,
                relay1read_button11,
                relay1read_button12,
                relay1read_button13,
                relay1read_button14,
                relay1read_button15,
                relay1read_button16,
                relay1read_button17,
                relay1read_button18,
                relay1read_button19,
                relay1read_button20,
            };

                foreach (Button button in Buttons)
                {
                    button.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Relay 1 Read Reset Button Function
        private void read_reset_button_1_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = new TextBox[] {
            relay1read,
            relay2read,
            relay3read,
            relay4read,
            relay5read,
            relay6read,
            relay7read,
            relay8read,
            relay9read,
            relay10read,
            relay11read,
            relay12read,
            relay13read,
            relay14read,
            relay15read,
            relay16read,
            relay17read,
            relay18read,
            relay19read,
            relay20read,
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
        #endregion

        //=====================
        //Relay 2 Functions
        //=====================

        #region Relay 2 ON/OFF Button Functions

        private void relay2button1_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[0])
                {
                    class_serialport2.turnOffRelay("0");
                    isRelayOn[0] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("0");
                    isRelayOn[0] = true;
                }

                relay2button1.Text = isRelayOn[0] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button2_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[1])
                {
                    class_serialport2.turnOffRelay("1");
                    isRelayOn[1] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("1");
                    isRelayOn[1] = true;
                }

                relay2button2.Text = isRelayOn[1] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button3_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[2])
                {
                    class_serialport2.turnOffRelay("2");
                    isRelayOn[2] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("2");
                    isRelayOn[2] = true;
                }

                relay2button3.Text = isRelayOn[2] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button4_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[3])
                {
                    class_serialport2.turnOffRelay("3");
                    isRelayOn[3] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("3");
                    isRelayOn[3] = true;
                }

                relay2button4.Text = isRelayOn[3] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button5_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[4])
                {
                    class_serialport2.turnOffRelay("4");
                    isRelayOn[4] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("4");
                    isRelayOn[4] = true;
                }

                relay2button5.Text = isRelayOn[4] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button6_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[5])
                {
                    class_serialport2.turnOffRelay("5");
                    isRelayOn[5] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("5");
                    isRelayOn[5] = true;
                }

                relay2button6.Text = isRelayOn[5] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button7_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[6])
                {
                    class_serialport2.turnOffRelay("6");
                    isRelayOn[6] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("6");
                    isRelayOn[6] = true;
                }

                relay2button7.Text = isRelayOn[6] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button8_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[7])
                {
                    class_serialport2.turnOffRelay("7");
                    isRelayOn[7] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("7");
                    isRelayOn[7] = true;
                }

                relay2button8.Text = isRelayOn[7] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button9_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[8])
                {
                    class_serialport2.turnOffRelay("8");
                    isRelayOn[8] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("8");
                    isRelayOn[8] = true;
                }

                relay2button9.Text = isRelayOn[8] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button10_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[9])
                {
                    class_serialport2.turnOffRelay("9");
                    isRelayOn[9] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("9");
                    isRelayOn[9] = true;
                }

                relay2button10.Text = isRelayOn[9] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button11_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[10])
                {
                    class_serialport2.turnOffRelay("A");
                    isRelayOn[10] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("A");
                    isRelayOn[10] = true;
                }

                relay2button11.Text = isRelayOn[10] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button12_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[11])
                {
                    class_serialport2.turnOffRelay("B");
                    isRelayOn[11] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("B");
                    isRelayOn[11] = true;
                }

                relay2button12.Text = isRelayOn[11] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button13_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[12])
                {
                    class_serialport2.turnOffRelay("C");
                    isRelayOn[12] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("C");
                    isRelayOn[12] = true;
                }

                relay2button13.Text = isRelayOn[12] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button14_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[13])
                {
                    class_serialport2.turnOffRelay("D");
                    isRelayOn[13] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("D");
                    isRelayOn[13] = true;
                }

                relay2button14.Text = isRelayOn[13] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button15_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[14])
                {
                    class_serialport2.turnOffRelay("E");
                    isRelayOn[14] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("E");
                    isRelayOn[14] = true;
                }

                relay2button15.Text = isRelayOn[14] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button16_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[15])
                {
                    class_serialport2.turnOffRelay("F");
                    isRelayOn[15] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("F");
                    isRelayOn[15] = true;
                }

                relay2button16.Text = isRelayOn[15] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button17_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[16])
                {
                    class_serialport2.turnOffRelay("G");
                    isRelayOn[16] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("G");
                    isRelayOn[16] = true;
                }

                relay2button17.Text = isRelayOn[16] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button18_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[17])
                {
                    class_serialport2.turnOffRelay("H");
                    isRelayOn[17] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("H");
                    isRelayOn[17] = true;
                }

                relay2button18.Text = isRelayOn[17] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button19_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[18])
                {
                    class_serialport2.turnOffRelay("I");
                    isRelayOn[18] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("I");
                    isRelayOn[18] = true;
                }

                relay2button19.Text = isRelayOn[18] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relay2button20_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                if (isRelayOn[19])
                {
                    class_serialport2.turnOffRelay("J");
                    isRelayOn[19] = false;
                }
                else
                {
                    class_serialport2.turnOnRelay("J");
                    isRelayOn[19] = true;
                }

                relay2button20.Text = isRelayOn[19] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Relay 2 Read Buttons Functions

        private void relay2read_button1_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("0");
        }

        private void relay2read_button2_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("1");
        }

        private void relay2read_button3_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("2");
        }

        private void relay2read_button4_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("3");
        }

        private void relay2read_button5_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("4");
        }

        private void relay2read_button6_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("5");
        }

        private void relay2read_button7_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("6");
        }

        private void relay2read_button8_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("7");
        }

        private void relay2read_button9_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("8");
        }

        private void relay2read_button10_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("9");
        }

        private void relay2read_button11_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("A");
        }

        private void relay2read_button12_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("B");
        }

        private void relay2read_button13_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("C");
        }

        private void relay2read_button14_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("D");
        }

        private void relay2read_button15_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("E");
        }

        private void relay2read_button16_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("F");
        }

        private void relay2read_button17_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("G");
        }

        private void relay2read_button18_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("H");
        }

        private void relay2read_button19_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("I");
        }

        private void relay2read_button20_Click(object sender, EventArgs e)
        {
            class_serialport2.readrelay("J");
        }

        #endregion

        #region Relay 2 All On, Off
        private void all_on_button_2_Click(object sender, EventArgs e)
        {
            class_serialport2.turnOnAllRelay();
            Button[] Buttons = new Button[] {
                relay2button1,
                relay2button2,
                relay2button3,
                relay2button4,
                relay2button5,
                relay2button6,
                relay2button7,
                relay2button8,
                relay2button9,
                relay2button10,
                relay2button11,
                relay2button12,
                relay2button13,
                relay2button14,
                relay2button15,
                relay2button16,
                relay2button17,
                relay2button18,
                relay2button19,
                relay2button20
            };

            foreach (Button button in Buttons)
            {
                button.Text = "OFF";
            }
        }

        private void all_off_button_2_Click(object sender, EventArgs e)
        {
            class_serialport2.turnOffAllRelay();

            Button[] Buttons = new Button[] {
                relay2button1,
                relay2button2,
                relay2button3,
                relay2button4,
                relay2button5,
                relay2button6,
                relay2button7,
                relay2button8,
                relay2button9,
                relay2button10,
                relay2button11,
                relay2button12,
                relay2button13,
                relay2button14,
                relay2button15,
                relay2button16,
                relay2button17,
                relay2button18,
                relay2button19,
                relay2button20
            };

            foreach (Button button in Buttons)
            {
                button.Text = "ON";
            }
        }
        #endregion

        #region Relay 2 ReadAll Button Function
        private void read_all_button_2_Click(object sender, EventArgs e)
        {
            if (class_serialport2.serialComm2.IsOpen)
            {
                Button[] Buttons = new Button[] {
                relay2read_button1,
                relay2read_button2,
                relay2read_button3,
                relay2read_button4,
                relay2read_button5,
                relay2read_button6,
                relay2read_button7,
                relay2read_button8,
                relay2read_button9,
                relay2read_button10,
                relay2read_button11,
                relay2read_button12,
                relay2read_button13,
                relay2read_button14,
                relay2read_button15,
                relay2read_button16,
                relay2read_button17,
                relay2read_button18,
                relay2read_button19,
                relay2read_button20,
            };

                foreach (Button button in Buttons)
                {
                    button.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Relay 1 Read Reset Button Function
        private void read_reset_button_2_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = new TextBox[] {
            relay1read_2,
            relay2read_2,
            relay3read_2,
            relay4read_2,
            relay5read_2,
            relay6read_2,
            relay7read_2,
            relay8read_2,
            relay9read_2,
            relay10read_2,
            relay11read_2,
            relay12read_2,
            relay13read_2,
            relay14read_2,
            relay15read_2,
            relay16read_2,
            relay17read_2,
            relay18read_2,
            relay19read_2,
            relay20read_2,
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
        #endregion
    }
}
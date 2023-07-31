using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Numato_USB_Relay_Software.Class.Class_SerialPort;
using static Numato_USB_Relay_Software.Class.Class_Globals;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Numato_USB_Relay_Software.Class;
using System.Security.Policy;

namespace Numato_USB_Relay_Software
{
    public partial class Form1 : Form
    {
        private Class_SerialPort class_serialport;
        public string channels;
        public static Form1 instance;
        public ComboBox comport;
        public ComboBox baudrate;
        public Button openbutton;
        public ProgressBar progressbar;

        #region TextBox Control
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
        #endregion

        public Form1()
        {
            InitializeComponent();
            instance = this;

            #region Other Instances
            comport = comport_box;
            baudrate = baudrate_box;
            openbutton = Open_button;
            progressbar = progressBar;
            #endregion 
            #region TextBox Instances 
            relay1read = relayread_textbox1;
            relay2read = relayread_textbox2;
            relay3read = relayread_textbox3;
            relay4read = relayread_textbox4;
            relay5read = relayread_textbox5;
            relay6read = relayread_textbox6;
            relay7read = relayread_textbox7;
            relay8read = relayread_textbox8;
            relay9read = relayread_textbox9;
            relay10read = relayread_textbox10;
            relay11read = relayread_textbox11;
            relay12read = relayread_textbox12;
            relay13read = relayread_textbox13;
            relay14read = relayread_textbox14;
            relay15read = relayread_textbox15;
            relay16read = relayread_textbox16;
            #endregion
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "NUMATO USBRELAY32 SOFTWARE";
            Getport();           
            comport_box.Items.AddRange(ports);
            isRelayOn = new bool[16];
        }

        #region Relay 1 Connection
        private void RelayOpenButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int relayIndex = (int)button.Tag;

            if (class_serialport.serialComm.IsOpen)
            {
                if (isRelayOn[relayIndex])
                {
                    class_serialport.turnOffRelay(relayIndex.ToString("X"));
                    isRelayOn[relayIndex] = false;
                }
                else
                {
                    class_serialport.turnOnRelay(relayIndex.ToString("X"));
                    isRelayOn[relayIndex] = true;
                }

                button.Text = isRelayOn[relayIndex] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Open_button_Click(object sender, EventArgs e)
        {
            if (Open_button.Text == "OPEN")
            {
                Getport();
                class_serialport.OpenConnection();
                readall_button.PerformClick();

                checkthestatus();
                reset_button.PerformClick();
            }
            else
            {
                class_serialport.OpenConnection();
            }
        }

        public void Getport()
        {
            class_serialport = new Class_SerialPort(comport_box.Text, Convert.ToInt32(baudrate_box.Text));
            class_serialport.GetPortName();
        }

        private void checkthestatus()
        {
            for (int i = 1; i <= 16; i++)
            {
                string relayReadTextBoxName = "relayread_textbox" + i;
                string relayOpenButtonName = "relayopen" + i + "_button";

                TextBox relayReadTextBox = Controls.Find(relayReadTextBoxName, true).FirstOrDefault() as TextBox;
                Button relayOpenButton = Controls.Find(relayOpenButtonName, true).FirstOrDefault() as Button;

                if (relayReadTextBox != null && relayReadTextBox.Text.Contains("on") && relayOpenButton != null)
                {
                    relayOpenButton.PerformClick();
                }
            }
        }
        #endregion
        #region Relay Buttons Functions
        public void relayopen1_button_Click(object sender, EventArgs e)
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

                relayopen1_button.Text = isRelayOn[0] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void relayopen2_button_Click(object sender, EventArgs e)
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

                relayopen2_button.Text = isRelayOn[1] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen3_button_Click(object sender, EventArgs e)
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

                relayopen3_button.Text = isRelayOn[2] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relayopen4_button_Click(object sender, EventArgs e)
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

                relayopen4_button.Text = isRelayOn[3] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relayopen5_button_Click(object sender, EventArgs e)
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

                relayopen5_button.Text = isRelayOn[4] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relayopen6_button_Click(object sender, EventArgs e)
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

                relayopen6_button.Text = isRelayOn[5] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relayopen7_button_Click(object sender, EventArgs e)
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

                relayopen7_button.Text = isRelayOn[6] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relayopen8_button_Click(object sender, EventArgs e)
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

                relayopen8_button.Text = isRelayOn[7] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen9_button_Click(object sender, EventArgs e)
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

                relayopen9_button.Text = isRelayOn[8] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen10_button_Click(object sender, EventArgs e)
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

                relayopen10_button.Text = isRelayOn[9] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen11_button_Click(object sender, EventArgs e)
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

                relayopen11_button.Text = isRelayOn[10] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen12_button_Click(object sender, EventArgs e)
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

                relayopen12_button.Text = isRelayOn[11] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen13_button_Click(object sender, EventArgs e)
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

                relayopen13_button.Text = isRelayOn[12] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen14_button_Click(object sender, EventArgs e)
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

                relayopen14_button.Text = isRelayOn[13] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen15_button_Click(object sender, EventArgs e)
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

                relayopen15_button.Text = isRelayOn[14] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void relayopen16_button_Click(object sender, EventArgs e)
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

                relayopen16_button.Text = isRelayOn[15] ? "OFF" : "ON";
            }
            else
            {
                MessageBox.Show("Error: " + "The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region Relay Read Buttons Functions
        private void relayread1_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("0");
        }

        private void relayread2_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("1");
        }

        private void relayread3_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("2");
        }

        private void relayread4_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("3");
        }

        private void relayread5_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("4");
        }

        private void relayread6_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("5");
        }

        private void relayread7_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("6");
        }

        private void relayread8_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("7");
        }

        private void relayread9_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("8");
        }

        private void relayread10_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("9");
        }

        private void relayread11_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("A");
        }

        private void relayread12_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("B");
        }

        private void relayread13_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("C");
        }

        private void relayread14_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("D");
        }

        private void relayread15_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("E");
        }

        private void relayread16_button_Click(object sender, EventArgs e)
        {
            class_serialport.readrelay("F");
        }
        #endregion
        #region Reset, All ON/OFF and ReadAll functions
        private void reset_button_Click(object sender, EventArgs e)
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
            };

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        private void AllrelayOn_button_Click(object sender, EventArgs e)
        {
            class_serialport.turnOnAllRelay();

            Button[] ButtonsRelay1 = new Button[] {
                relayopen1_button,
                relayopen2_button,
                relayopen3_button,
                relayopen4_button,
                relayopen5_button,
                relayopen6_button,
                relayopen7_button,
                relayopen8_button,
                relayopen9_button,
                relayopen10_button,
                relayopen11_button,
                relayopen12_button,
                relayopen13_button,
                relayopen14_button,
                relayopen15_button,
                relayopen16_button,
            };

            foreach (Button button in ButtonsRelay1)
            {
                button.Text = "OFF";
            }
        }

        private void AllrelayOff_button_Click(object sender, EventArgs e)
        {
            class_serialport.turnOffAllRelay();

            Button[] ButtonsRelay1 = new Button[] {
                relayopen1_button,
                relayopen2_button,
                relayopen3_button,
                relayopen4_button,
                relayopen5_button,
                relayopen6_button,
                relayopen7_button,
                relayopen8_button,
                relayopen9_button,
                relayopen10_button,
                relayopen11_button,
                relayopen12_button,
                relayopen13_button,
                relayopen14_button,
                relayopen15_button,
                relayopen16_button,
            };

            foreach (Button button in ButtonsRelay1)
            {
                button.Text = "ON";
            }

        }

        private void readall_button_Click(object sender, EventArgs e)
        {
            if (class_serialport.serialComm.IsOpen)
            {
                Button[] Buttons = new Button[] {
                relayread1_button,
                relayread2_button,
                relayread3_button,
                relayread4_button,
                relayread5_button,
                relayread6_button,
                relayread7_button,
                relayread8_button,
                relayread9_button,
                relayread10_button,
                relayread11_button,
                relayread12_button,
                relayread13_button,
                relayread14_button,
                relayread15_button,
                relayread16_button,
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
    }
}

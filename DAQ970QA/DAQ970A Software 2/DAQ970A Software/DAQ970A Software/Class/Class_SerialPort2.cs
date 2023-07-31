using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using static DAQ970A_Software.Class.Class_Globals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static DAQ970A_Software.Form1;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace DAQ970A_Software.Class
{
    public class Class_SerialPort2
    {
        public static Form1 form_numato;
        public SerialPort serialComm2;
        public static string[] ports2;

        public Class_SerialPort2(string portName, int baudRate)
        {
            serialComm2 = new SerialPort(portName, baudRate);
        }

        public async void GetPortName()
        {
            ports2 = SerialPort.GetPortNames();
        }

        public async void OpenConnection()
        {
            try
            {
                if (Form1.instance.open_connection_relay2.Text == "CLOSE" || serialComm2.IsOpen == true)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to Close?", "Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        while (serialComm2.IsOpen == true)
                        {
                            serialComm2.Close();
                            Form1.instance.open_connection_relay2.Text = "OPEN";
                            Form1.instance.progressbar_relay_2.Value = 0;
                            if (serialComm2.IsOpen == false)
                            {
                                MessageBox.Show("Disconnected", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    serialComm2.Open();
                    Form1.instance.open_connection_relay2.Text = "CLOSE";
                    Form1.instance.progressbar_relay_2.Value = 100;
                    MessageBox.Show("Connected", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Please select port", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void turnOnRelay(string channel)
        {
            try
            {
                serialComm2.DiscardInBuffer();
                if (!serialComm2.IsOpen)
                    serialComm2.Open();
                {
                    try
                    {
                        serialComm2.DiscardInBuffer();
                        serialComm2.Write("relay on " + channel + "\r");
                        System.Threading.Thread.Sleep(10);
                        serialComm2.DiscardOutBuffer();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception examination)
            {
                MessageBox.Show("Error: " + examination.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void turnOffRelay(string channel)
        {
            serialComm2.DiscardInBuffer();
            if (!serialComm2.IsOpen)
                serialComm2.Open();
            {
                try
                {
                    serialComm2.DiscardInBuffer();
                    serialComm2.Write("relay off " + channel + "\r");
                    System.Threading.Thread.Sleep(10);
                    serialComm2.DiscardOutBuffer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async void turnOnAllRelay()
        {
            try
            {
                serialComm2.DiscardInBuffer();
                if (!serialComm2.IsOpen)
                    serialComm2.Open();
                {
                    try
                    {
                        serialComm2.DiscardInBuffer();
                        serialComm2.Write("relay writeall 000fffff" + "\r");
                        System.Threading.Thread.Sleep(10);
                        serialComm2.DiscardOutBuffer();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception examination)
            {
                MessageBox.Show("Error: " + examination.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void turnOffAllRelay()
        {
            try
            {
                serialComm2.DiscardInBuffer();
                if (!serialComm2.IsOpen)
                    serialComm2.Open();
                {
                    try
                    {
                        serialComm2.DiscardInBuffer();
                        serialComm2.Write("relay writeall 00000000" + "\r");
                        System.Threading.Thread.Sleep(10);
                        serialComm2.DiscardOutBuffer();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception examination)
            {
                MessageBox.Show("Error: " + examination.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void readrelay(string channel)
        {
            TextBox[] textBoxes = new TextBox[] {
            Form1.instance.relay1read_2,
            Form1.instance.relay2read_2,
            Form1.instance.relay3read_2,
            Form1.instance.relay4read_2,
            Form1.instance.relay5read_2,
            Form1.instance.relay6read_2,
            Form1.instance.relay7read_2,
            Form1.instance.relay8read_2,
            Form1.instance.relay9read_2,
            Form1.instance.relay10read_2,
            Form1.instance.relay11read_2,
            Form1.instance.relay12read_2,
            Form1.instance.relay13read_2,
            Form1.instance.relay14read_2,
            Form1.instance.relay15read_2,
            Form1.instance.relay16read_2,
            Form1.instance.relay17read_2,
            Form1.instance.relay18read_2,
            Form1.instance.relay19read_2,
            Form1.instance.relay20read_2,
            };

            try
            {
                serialComm2.DiscardInBuffer();
                if (!serialComm2.IsOpen)
                    serialComm2.Open();
                {
                    try
                    {
                        serialComm2.DiscardInBuffer();
                        serialComm2.Write("relay read " + channel + "\r");
                        System.Threading.Thread.Sleep(10);
                        string response = serialComm2.ReadExisting();
                        switch (channel)
                        {
                            case "A":
                                channel = "10";
                                break;
                            case "B":
                                channel = "11";
                                break;
                            case "C":
                                channel = "12";
                                break;
                            case "D":
                                channel = "13";
                                break;
                            case "E":
                                channel = "14";
                                break;
                            case "F":
                                channel = "15";
                                break;
                            case "G":
                                channel = "16";
                                break;
                            case "H":
                                channel = "17";
                                break;
                            case "I":
                                channel = "18";
                                break;
                            case "J":
                                channel = "19";
                                break;
                        }
                        textBoxes[Convert.ToInt32(channel)].Text = response.Substring(13, 4);
                        serialComm2.DiscardOutBuffer();
                    }
                    catch (Exception examination)
                    {
                        MessageBox.Show("Error: " + examination.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception examination)
            {
                MessageBox.Show("Error: " + examination.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            string data = serialPort.ReadExisting();
        }
    }
}

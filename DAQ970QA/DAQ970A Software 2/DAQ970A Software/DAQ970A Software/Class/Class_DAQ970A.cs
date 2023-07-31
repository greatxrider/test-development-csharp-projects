using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ivi.Visa;
using Ivi.Visa.FormattedIO;
using DAQ970A_Software;
using static DAQ970A_Software.Class.Class_Globals;
using System.Drawing;

namespace DAQ970A_Software.Class
{
    public class Class_DAQ970A : IDisposable
    {
        public static Form1 form1;
        public Class_Globals class_globals;
        string Address;
        public bool DAQ970A_State { get; set; } = false;
        public string equipmentError { get; set; } = "";
        public bool isOpen { get; set; } = false;
        MessageBasedFormattedIO formattedIO;
        IMessageBasedSession session;

        public Class_DAQ970A(string VisaAddress)
        {
            Address = VisaAddress;
            if (Address == "")
            {
                DAQ970A_State = false;
                equipmentError = "VisaAddress of DAQ970A is Empty!!!";
                isOpen = false;               
                MessageBox.Show("Error: " + equipmentError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1.instance.progressbar.Value = 0;
            }
            else
            {
                Form1.instance.progressbar.Value = 50;
                DAQ970A_State = connect();
            }   
        }
        public async Task<string> getId()
        {
            string dataGet = "";          
            string[] splitData = { };
            await serialWrite("*IDN?");
            dataGet = await serialRead();
            splitData = dataGet.Split(',');
            dataGet = splitData[2];
            return dataGet;
        }
        public async Task<string> selfTest()
        {
            string dataGet = "";
            string[] splitData = { };
            await serialWrite("*TST?");
            dataGet = await serialRead();
            splitData = dataGet.Split(',');
            dataGet = splitData[2];
            return dataGet;
        }
        public async Task reset()
        {
            await serialWrite("*RST");
        }

        public bool connect()
        {
            try
            {
                session = GlobalResourceManager.Open(Address) as IMessageBasedSession;
                session.TerminationCharacterEnabled = true;

                //ISerialSession serial = session as ISerialSession;
                //serial.BaudRate = 9600;
                //serial.DataBits = 8;
                //serial.Parity = SerialParity.None;
                //serial.FlowControl = SerialFlowControlModes.DtrDsr;

                formattedIO = new MessageBasedFormattedIO(session);
                equipmentError = "";
                isOpen = true;
                return true;
                Form1.instance.progressbar.Value = 100;
                Form1.instance.open_connection.Text = "DISCONNECT";
                Form1.instance.open_connection.ForeColor = Color.Red;
            }
            catch (Exception e)
            {
                isOpen = false;
                equipmentError += e.ToString();
                MessageBox.Show(e.ToString());
                Form1.instance.progressbar.Value = 0;
                return false;               
            }
        }
        public async Task serialWrite(string Command)
        {
            formattedIO.WriteLine(Command);
            Task.Delay(50);
        }
        public async Task<string> serialRead()
        {
            return formattedIO.ReadLine();
            Task.Delay(50);
        }
        
        #region DAQM901A
        public async Task<string> measureVoltage(int voltRange,string channel)
        {
            //Sample Chanel
            //@101 - Single Channel
            //@101:103 - channel range
            string dataMeasured = "";
            await serialWrite($"MEAS:VOLT:DC? {voltRange},(@{channel})");
            dataMeasured = await serialRead();            
            return dataMeasured;
        }
        public async Task<string> measureCurrent(int currRange, string channel)
        {
            //FOR CURRENT MEASUREMENT YOU CAN USE ONLY CHANNEL
            //21 AND 22 THIS IS BASED ON THE SPEC OF DAQ970A
            string dataMeasured = "";
            await serialWrite($"MEAS:CURR:DC? {currRange},(@{channel})");
            dataMeasured = await serialRead();
            return dataMeasured;
        }
        public async Task<string> measureResistance(int resRange, string channel)
        {
            //+9.90000000E+37 = +OVERLOAD....
            await serialWrite($"MEAS:RES? {resRange},(@{channel})");
            return await serialRead();  
            //string dataMeasured = "";
            //dataMeasured = await serialRead();           
            //return dataMeasured;
            
        }
        public async Task<string> measureTemp(string channel)
        {
            await serialWrite($"MEAS:TEMP? (@{channel})");
            //return Math.Round(Convert.ToDouble(await serialRead()), 3).ToString();
            return await serialRead();
        }

        public async Task closeConnection()
        {
            isOpen = false;
            session.Dispose();
        }

        void IDisposable.Dispose()
        {
            closeConnection();
        }
        private string dataMeasureManipulation(string stringData)
        {

            if (stringData != "")
            {
                if (stringData.Contains(","))
                {
                    string[] splitDataMeasured = stringData.Split(',');
                    for (int i = 0; i < splitDataMeasured.Count(); i++)
                    {
                        try
                        {
                            stringData += Math.Round(Convert.ToDouble(splitDataMeasured[i]), 3);
                            if (i < splitDataMeasured.Count()-1)
                            {
                                stringData += ",";
                            }
                        }
                        catch (Exception ex)
                        {

                            stringData = "ERROR ON FOR LOOP MEASURE VOLTAGE";
                        }
                    }
                }

            }
            else
            {
                stringData = "ERROR!";
            }
            return stringData;
        }
        #endregion

        #region DAQM903A ACTUATOR SWITCH
        public async Task turnOnRelay(string channel)
        {
            await serialWrite($"ROUT:OPEN (@{channel})");
        }
        public async Task turnOfRelay(string channel)
        {
            await serialWrite($"ROUT:CLOSE (@{channel})");
        }
        #endregion

        //public async Task<List<int>> measure(List<string> Channel)
        //{
        //    List<int> result = new List<int>();            
        //}
    }
}

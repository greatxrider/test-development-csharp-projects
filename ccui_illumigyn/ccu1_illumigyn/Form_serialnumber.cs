using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;
using static ccu1_illumigyn.Class.class_globals;
using ccu1_illumigyn.Class;
using ccu1_illumigyn.Resources;
using System.Reflection.Emit;

namespace ccu1_illumigyn
{
    public partial class Form_serialnumber : Form
    {
        private class_uniqeserialnumber class_UniqueSerialNumber;
        private class_QueryVersion class_queryversion;
        public static Form_serialnumber instance;
        public TextBox serialnumbers;
        
        public Form_serialnumber()
        {
            InitializeComponent();           
            instance = this;
            serialnumbers = serialnumberscan;
        }

        private bool isCancelled = false;

        private void cancel_butt_Click(object sender, EventArgs e)
        {
            isCancelled = true;
            serialnumberscan.Text = "#######";
            this.Close();
        }

        private void SerialNumberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isCancelled)
            {
                return;
            }
        }

        private void serialnumberscan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                proceed_butt.PerformClick();
            }
        }

        //======================
        //First Test and Ongoing 
        //====================== //Program will run when custom mode test, controls what test pin will be tested first
        #region Guidelabel & Ongoing      
        public async void Ongoing()
        {
            var testGuidelabelText = Form_picture_guide.instance.testguidelabel.Text;
            var ccu1 = Form_ccu1.instance;

            if (testGuidelabelText.Contains("D1 PIN 1"))
                SetStatusAndBackColor(ccu1.p1status_i);
            else if (testGuidelabelText.Contains("R39 PIN 1"))
                SetStatusAndBackColor(ccu1.p2status_i);
            else if (testGuidelabelText.Contains("R43 PIN 1"))
                SetStatusAndBackColor(ccu1.p3status_i);
            else if (testGuidelabelText.Contains("R42 PIN 1"))
                SetStatusAndBackColor(ccu1.p4status_i);
            else if (testGuidelabelText.Contains("U10 PIN 5"))
                SetStatusAndBackColor(ccu1.s1status_i);
            else if (testGuidelabelText.Contains("U11 PIN 5"))
                SetStatusAndBackColor(ccu1.s2status_i);
            else if (testGuidelabelText.Contains("U12 PIN 5"))
                SetStatusAndBackColor(ccu1.s3status_i);
            else if (testGuidelabelText.Contains("U13 PIN 5"))
                SetStatusAndBackColor(ccu1.s4status_i);
            else if (testGuidelabelText.Contains("U5 PIN 5"))
                SetStatusAndBackColor(ccu1.sm1status_i);
            else if (testGuidelabelText.Contains("U6 PIN 5"))
                SetStatusAndBackColor(ccu1.sm2status_i);
            else if (testGuidelabelText.Contains("U7 PIN 5"))
                SetStatusAndBackColor(ccu1.sm3status_i);
            else if (testGuidelabelText.Contains("U8 PIN 5"))
                SetStatusAndBackColor(ccu1.sm4status_i);
        }

        private void SetStatusAndBackColor(TextBox statusTextBox)
        {
            statusTextBox.Text = "ONGOING";
            statusTextBox.BackColor = Color.Yellow;
            statusTextBox.ForeColor = Color.Black;
        }     
        #endregion  

        //==================
        //Unique Serial Test
        //==================
        #region Unique Serial Test
        private async void proceed_butt_Click(object sender, EventArgs e)
        {    
            //==============
            //Reset Controls 
            //==============

            Form_ccu1.instance.testlogstextbox.Clear();
            Form_container.instance.cleartextboxes();
            Form_container.instance.resetoverallbox();
            Form_ccu1.instance.teststartlabel.Text = "#######";
            Form_ccu1.instance.testendlabel.Text = "#######";
            Form_ccu1.instance.timerlabel.Text = "0";
            Form_ccu1.instance.queryVersionTxtbox.Text = config_Dictionary["Query_Version"];

            string serialnumber = serialnumberscan.Text.Trim();

            if (string.IsNullOrEmpty(serialnumber))
            {
                MessageBox.Show("Serial number not detected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JigNumber = "J1";
            await serialnums();

            DateTime serialscan = DateTime.Now;
            string scanSerial = serialscan.ToString("F");

            Form_container.instance.Button12.Text = "STOP";
            Form_container.instance.Button12.BackColor = Color.Red;
            Form_container.instance.Button12.ForeColor = Color.White;
         
            if (Form_container.instance.Button12.Text == "STOP")
            {
                Form_container.instance.ControlBox = false;
            }        

            this.Close();
        }

        public async Task serialnums()
        {
            try
            {
                class_UniqueSerialNumber = new class_uniqeserialnumber();
                string uniqueSerial = await class_UniqueSerialNumber.CheckUniqueSerialNumber();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unique Serial Number Test Error." + Environment.NewLine + ex.Message, JigNumber);
            }
        }
        #endregion
    }
}

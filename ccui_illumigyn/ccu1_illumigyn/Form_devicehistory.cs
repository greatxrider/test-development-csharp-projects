using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ccu1_illumigyn.Class;
using static ccu1_illumigyn.Class.class_globals;
using System.IO;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using TextBox = System.Windows.Forms.TextBox;
using Label = System.Windows.Forms.Label;
using System.Security.Cryptography.X509Certificates;

namespace ccu1_illumigyn
{
    public partial class Form_devicehistory : Form
    {
        public static Form_devicehistory instance;
        public static myDB myDb;
        string overall = string.Empty;

        #region TextBox Instances
        public TextBox serialnumb_details;
        #endregion

        #region RadioButton Instances
        public RadioButton passed;
        public RadioButton failed;
        public RadioButton both;
        public RadioButton aborted;
        #endregion
     
        #region Datagridview Instances
        public DataGridView datagrid1;
        public DataGridView datagridsummary;
        public DataGridView datagridmultiple;
        #endregion
      
        public Form_devicehistory()
        {
            InitializeComponent();
            savelogs = new class_saveLogs();
            instance = this;
            #region Instances Equivalent
            passed = passedradioButton1;
            failed = failedradioButton2;
            both = bothradioButton3;
            aborted = abortedButton;
            serialnumb_details = tb_Details_Serial;
            datagrid1 = dataGridView1;
            datagridsummary = dgv_Summary;
            #endregion
        }

        #region Search the Database
        private async void btn_Select_Click(object sender, EventArgs e)
        {
            overall_failed = "FAILED";
            overall_passed = "PASSED";
            overall_aborted = "ABORTED";

            dateStart = $"{dateTimePicker1.Text} {dateTimePicker2.Text}";
            dateEnd = $"{dateTimePicker4.Text} {dateTimePicker3.Text}";
       
            await class_Database.SearchDeviceHistory_Single("tblCCU1SystemTest", dateStart, dateEnd, overall_passed, overall_failed, overall_aborted, tb_Details_Serial.Text);
            await class_Database.SearchDeviceHist_SummaryView("tblCCU1SystemTest", dateStart, dateEnd, overall_passed, overall_failed, overall_aborted, tb_Details_Serial.Text);
            dataGridView1.Columns["TEST_START"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
            dataGridView1.Columns["TEST_END"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
            dgv_Summary.Columns["TEST_START"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";

            startcountingtest();
        }
        #endregion

        public async void startcountingtest()
        {
            passedoverall = await class_Database.countAllperResult("tblCCU1SystemTest", "PASSED");
            failedoverall = await class_Database.countAllperResult("tblCCU1SystemTest", "FAILED");
            abortedoverall = await class_Database.countAllperResult("tblCCU1SystemTest", "ABORTED");
            totaloverall = passedoverall + failedoverall + abortedoverall;

            passedOveralltextBox.Text = passedoverall.ToString();
            failedOveralltextBox.Text = failedoverall.ToString();
            abortedOveralltextBox.Text = abortedoverall.ToString();
            totalOveralltextBox.Text = totaloverall.ToString(); 
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private async void printcsv_Click(object sender, EventArgs e)
        {
            await savelogs.ExportData();
        }
    }
}
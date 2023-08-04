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

namespace ccu1_illumigyn.Instructions
{
    public partial class Form_test_guide_5 : Form
    {
        public Form_test_guide_5()
        {
            InitializeComponent();
        }

        private void test_guide5_ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
            starttest = false;
        }

        private void test_guide5_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
            starttest = true;
        }

        public async Task<bool> cancel_test()
        {
            return starttest;
        }
    }
}

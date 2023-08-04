using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ccu1_illumigyn.Class.class_globals;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ccu1_illumigyn
{
    public partial class Form_configuration_authentication : Form
    {
        
        public Form_configuration_authentication()
        {
            InitializeComponent();        
        }

        private void access_Click(object sender, EventArgs e)
        {
            form_Configuration = new Form_Configuration();
            account = usernametxtbox.Text;
            password = passwordtxtbox.Text;

            if (account == "admin" && password == "password")
            {
                this.Close();
                form_Configuration.ShowDialog();          
            }
            else
            {

                MessageBox.Show("Access denied!");
                return;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            return;
        }

        private void usernametxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; 
                passwordtxtbox.Focus();
            }
        }

        private void passwordtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                access.PerformClick();
            }
        }
    }
}

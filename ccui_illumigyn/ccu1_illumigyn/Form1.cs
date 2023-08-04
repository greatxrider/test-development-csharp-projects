using System;
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
using System.Diagnostics;
using System.Threading;
using System.Data.SqlTypes;

namespace ccu1_illumigyn
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public TextBox username_login;
        private string usernames;
        private string passwords;     

        public Form1()
        {
            InitializeComponent();         
            instance = this;
            username_login = username;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        //=====================
        //Login Button Function
        //=====================
        #region Login Function
        private void login_Click(object sender, EventArgs e)
        {  
            _Login();        
        }

        private void _Login()
        {     
            string usernameInput = username.Text.Trim();
            string passwordInput = Password.Text;
        
            if (string.IsNullOrEmpty(usernameInput))
            {
                MessageBox.Show("Please Input Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Please Input Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passwordInput == "S@")
            {
                container = new Form_container();
                container.Show();
                Form_container.instance.operatorname.Text = usernameInput;
                ClearTB();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid account!");
                Password.Clear();
                return;
            }
        }

        private void ClearTB()
        {
            username.Text = "";
            Password.Text = "";
        }
        #endregion

        //====================
        //Enter Key on Textbox
        //====================
        #region Textbox Focus (Keydown)
        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleKeyPress(e, () => Password.Focus()))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleKeyPress(e, () => login.PerformClick()))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private bool HandleKeyPress(KeyEventArgs e, Action action)
        {
            if (e.KeyCode == Keys.Enter)
            {
                action.Invoke();
                return true;
            }
            return false;
        }
        #endregion 
    }
}
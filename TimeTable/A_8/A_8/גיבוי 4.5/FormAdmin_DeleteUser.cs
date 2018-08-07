﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{
    public partial class FormAdmin_DeleteUser : Form
    {
        public FormAdmin_DeleteUser()
        {
            InitializeComponent();
            textBox_UserID.MaxLength = 9;
            this.AcceptButton = button_Accept;
        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {
            if (textBox_UserID.TextLength > 8)
            {
                checkBox_Accept.Visible = true;
            }
            else
            {
                checkBox_Accept.Visible = false;
                checkBox_Accept.Checked = false;
                button_Accept.Enabled = false;
            }
        }

        private void checkBox_Accept_Click(object sender, EventArgs e)
        {
            if(checkBox_Accept.Checked)
            {
                button_Accept.Enabled = true;
            }
            else
            {
                button_Accept.Enabled = false;
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if(SQLFunctions.checkExistsUsers(Convert.ToInt32(textBox_UserID.Text))==true)
            {
                SQLFunctions.deleteUser(Convert.ToInt32(textBox_UserID.Text));
                MessageBox.Show("User with ID: "+textBox_UserID.Text+" was deleted!");
                this.Hide();
                FormMenuAdmin adminForm = new FormMenuAdmin();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("User ID could not be located in the database");
            }
       
        }

        private void textBox_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FormAdminDeleteUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }
    }
}

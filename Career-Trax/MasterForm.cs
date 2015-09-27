using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InternshipManagementSystem
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            String userName = Properties.Settings.Default.user, pass = Properties.Settings.Default.pwd;

            if (userName.Trim() == textBox1.Text.Trim() && pass.Trim() == textBox2.Text.Trim())
            {
                this.Hide();
                new FormSelection().Show();
            }
            else {
                MessageBox.Show("Invalid Username or Password","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string newPass = Microsoft.VisualBasic.Interaction.InputBox("Enter New Password:", "New Password");

            Properties.Settings.Default.pwd = newPass;
        }

        private void forgotPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

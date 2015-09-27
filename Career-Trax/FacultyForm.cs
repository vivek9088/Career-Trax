using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace InternshipManagementSystem
{
    public partial class FacultyForm : Form
    {

        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
        MySqlDataReader dr;

        public FacultyForm()
        {
            InitializeComponent();
        }

        private void FacultyForm_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("mailto:"+textBox8.Text);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (facid.Text == "" || fname.Text == "" || lname.Text == "" || desig.Text == "" || mobile.Text == "" || email.Text == "" || dept.SelectedIndex == -1 || number.Text == "")
            {
                MessageBox.Show("Please fill in all the required fields marked in red.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (mobile.Text.Length < 10)
            {
                MessageBox.Show("Please enter 10-digit mobile number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                 try
                 {
                con.Open();

                cmdnewdb = new MySqlCommand("select * from faculty where facid =@fid",con);
                cmdnewdb.Parameters.AddWithValue("fid", int.Parse(facid.Text.Trim()));
                dr = cmdnewdb.ExecuteReader();
                dr.Read();
                if (dr.HasRows)  // if the id is already in database then return true
                {
                    MessageBox.Show("Duplicate Faculty ID. Please give another ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    facid.SelectAll();
                    facid.Focus();
                    dr.Close();
                }
                else
                {
                    dr.Close();    
                    cmdnewdb = new MySqlCommand("insert into faculty(fname,lname,number,desig,dept,extn,mobile,email,notes,facid) values(@name1,@name2,@num,@des,@dpt,@ext,@mob,@mail,@note,@id)", con);
                    cmdnewdb.Parameters.AddWithValue("id", int.Parse(facid.Text.Trim()));
                    cmdnewdb.Parameters.AddWithValue("name1", fname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name2", lname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("des", desig.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("dpt", dept.SelectedItem.ToString());
                    cmdnewdb.Parameters.AddWithValue("num", number.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("ext", extn.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("mob", mobile.Text);
                    cmdnewdb.Parameters.AddWithValue("mail", email.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("note", notes.Text.Trim());

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Faculty Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();
                    
                    clearControls(sender, e);
                }
                con.Close();
            }
                 catch (Exception err)
                 {
                     MessageBox.Show("There must be a Database Connection Problem. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     CreateLogFile Err = new CreateLogFile();
                     Err.ErrorLog("ErrorLog", "Save method of Faculty Page :" + err.Message);
                 }//End of Catch
            }//End of Outer If-Else
        }

        private void clearControls(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
            dept.Text = "";
        }
        
        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (facid.Text == "")
            {
                MessageBox.Show("Please enter an Faculty ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                facid.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    cmdnewdb = new MySqlCommand("select * from faculty where facid=@fid", con);
                    cmdnewdb.Parameters.AddWithValue("fid", int.Parse(facid.Text.Trim()));
                    dr = cmdnewdb.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cmdnewdb = new MySqlCommand("update faculty set fname=@name1,lname=@name2,number=@num,desig=@des,dept=@dpt,extn=@ext,mobile=@mob,email=@mail,notes=@note where facid=@id", con);
                        cmdnewdb.Parameters.AddWithValue("id", int.Parse(facid.Text.Trim()));
                        cmdnewdb.Parameters.AddWithValue("name1", fname.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("name2", lname.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("des", desig.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("dpt", dept.SelectedItem.ToString());
                        cmdnewdb.Parameters.AddWithValue("num", number.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("ext", extn.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("mob", mobile.Text);
                        cmdnewdb.Parameters.AddWithValue("mail", email.Text.Trim());
                        cmdnewdb.Parameters.AddWithValue("note", notes.Text.Trim());

                        cmdnewdb.ExecuteNonQuery();
                        MessageBox.Show("Faculty Details Updated Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmdnewdb.Parameters.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        facid.SelectAll();
                        facid.Focus();
                        dr.Close();
                    }
                    con.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem may be due to incorrect ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Update method of Faculty Page :" + err.Message);
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int status;

            if (facid.Text == "")
            {
                MessageBox.Show("Please enter an Faculty ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                facid.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    cmdnewdb = new MySqlCommand("delete from faculty where facid=@fid", con);
                    cmdnewdb.Parameters.AddWithValue("fid", int.Parse(facid.Text.Trim()));
                    status = cmdnewdb.ExecuteNonQuery();
                    
                    if(status > 0)
                    {
                        MessageBox.Show("Faculty Details Deleted Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmdnewdb.Parameters.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        facid.SelectAll();
                        facid.Focus();
                        dr.Close();
                    }
                    con.Close();
                    clearControls(sender, e);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem may be: Database Connection doe not exist. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Delete method of Faculty Page :" + err.Message);
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (facid.Text == "")
            {
                MessageBox.Show("Please enter an Faculty ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                facid.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    cmdnewdb = new MySqlCommand("select * from faculty where facid=@fid", con);
                    cmdnewdb.Parameters.AddWithValue("fid", int.Parse(facid.Text.Trim()));
                    dr = cmdnewdb.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        fname.Text = dr.GetString("fname");
                        lname.Text = dr.GetString("lname");
                        number.Text = dr.GetString("number");
                        desig.Text = dr.GetString("desig");
                        extn.Text = dr.GetString("extn");
                        mobile.Text = dr.GetString("mobile");
                        email.Text = dr.GetString("email");
                        notes.Text = dr.GetString("notes");
                        dept.Text = dr.GetString("dept");
                       
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        facid.SelectAll();
                        facid.Focus();
                        dr.Close();
                    }
                    con.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem may be due to incorrect ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Search method of Faculty Page :" + err.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSelection().Show();
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void desig_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));

        }

        private void extn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(email.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    email.Focus();
                }
            }
        }

        private void number_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }
    }
}

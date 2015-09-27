using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace InternshipManagementSystem
{
    public partial class StudentInternship : Form
    {
        int sid;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
              
        public StudentInternship(int studid)
        {
            InitializeComponent();
            sid = studid;
        }

        private void StudentInternship_Load(object sender, EventArgs e)
        {
            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (studstat.Text == "" || tfname.Text == "" || tmname.Text == "" || size.Text == "" || pdesc.Text == "" || tcname.Text == "" || istatus.Text == "" || title.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               try
                {
                    con.Open();

                    cmdnewdb = new MySqlCommand("insert into internship(studid,status,cname,mgrname,facname,title,size,istatus,pdesc) values(@sid,@st,@name,@mgr,@fac,@head,@tot,@istat,@desc)", con);

                    cmdnewdb.Parameters.AddWithValue("sid", sid);
                    cmdnewdb.Parameters.AddWithValue("st", studstat.SelectedItem.ToString());
                    cmdnewdb.Parameters.AddWithValue("name", tcname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("mgr", tmname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("fac", tfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("head", title.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("tot",int.Parse(size.Text));
                    cmdnewdb.Parameters.AddWithValue("istat", istatus.SelectedItem.ToString());
                    cmdnewdb.Parameters.AddWithValue("desc", pdesc.Text.Trim());
                    
                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Student Internship Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();
                    this.Hide();
                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add Student method of StudentInternship Page :" + err.Message);
                }//End of Catch
            }//End of Outer If-Else
        }

        private void tcname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void tmname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void tfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void title_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void size_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (studstat.Text == "" || tfname.Text == "" || tmname.Text == "" || size.Text == "" || pdesc.Text == "" || tcname.Text == "" || istatus.Text == "" || title.Text == "")
            {
                MessageBox.Show("Please fill in all the fields before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                   
                    cmdnewdb = new MySqlCommand("update internship set status=@st,cname=@name,mgrname=@mgr,facname=@fac,title=@head,size=@tot,istatus=@istat,pdesc=@desc where studid=@sd", con);
                    cmdnewdb.Parameters.AddWithValue("sd", sid);
                    cmdnewdb.Parameters.AddWithValue("st", studstat.SelectedItem.ToString());
                    cmdnewdb.Parameters.AddWithValue("name", tcname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("mgr", tmname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("fac", tfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("head", title.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("tot", int.Parse(size.Text));
                    cmdnewdb.Parameters.AddWithValue("istat", istatus.SelectedItem.ToString());
                    cmdnewdb.Parameters.AddWithValue("desc", pdesc.Text.Trim());

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Internship Details Updated Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();
                    con.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem may be due to incorrect ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Update method of Student Internship Page :" + err.Message);
                }
            }
        }

        private void bArchive_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
                
            
            StreamWriter sw = new StreamWriter(save.FileName);
            

        }
    }
}

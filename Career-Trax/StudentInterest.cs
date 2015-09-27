using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InternshipManagementSystem
{
    public partial class StudentInterest : Form
    {
        int sid=0;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
        MySqlDataReader dr;

        public StudentInterest(int studid)
        {
            InitializeComponent();
            sid = studid;
        }

        private void StudentInterest_Load(object sender, EventArgs e)
        {

        }

        private void educationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StudentEducation(sid).Show();
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StudentKwSkills(sid).Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSelection().Show();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            String flist ="", llist= "";

            if (locList.Items.Count == 0 || fieldList.Items.Count == 0)
            {
                MessageBox.Show("Please fill in all the fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (locname.SelectedIndex == locname.Items.Count - 1 && others.Text == "")
            {
                MessageBox.Show("Please enter Other Location.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Adding all items of fieldlist to one string variable
                    for (int fcnt = 0; fcnt < fieldList.Items.Count; fcnt++)
                    {
                        flist += fieldList.Items[fcnt].ToString() + ",";
                    }

                    //Adding all items of loclist to one string variable
                    for (int lcnt = 0; lcnt < locList.Items.Count; lcnt++)
                    {
                        llist += locList.Items[lcnt].ToString() + ",";
                    }

                    con.Open();

                    cmdnewdb = new MySqlCommand("insert into interest(studid,fieldlist,loclist,comments) values(@sid,@field,@loc,@comm)", con);

                    cmdnewdb.Parameters.AddWithValue("sid", sid);
                    cmdnewdb.Parameters.AddWithValue("field", flist);
                    cmdnewdb.Parameters.AddWithValue("loc", locList.Items);
                    cmdnewdb.Parameters.AddWithValue("comm", comments.Text.Trim());
                    
                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Student Interest Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();
                    
                    clearControls(sender, e);

                }
                catch (Exception err)
                {
                    MessageBox.Show("Student Id does not exist. Please provide valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add method of StudentInterest Page :" + err.Message);
                }//End of Catch
            }//End of Outer If-Else
        }

        private void clearControls(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(ListBox))
                {
                    ((ListBox)(c)).Items.Clear();
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)(c)).Text = string.Empty;
                }
            }
            others.Text = "";
            comments.Text = "";
        }
        private void others_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void addField_Click(object sender, EventArgs e)
        {
            if (sklevel.SelectedIndex == -1 || skname.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from Skill level or Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fieldList.Items.Add(sklevel.Items[sklevel.SelectedIndex].ToString().Trim() + " - " + skname.Items[skname.SelectedIndex].ToString().Trim());
            }
        }

        private void addLoc_Click(object sender, EventArgs e)
        {
            if (locname.SelectedIndex == -1 || locpref.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from Location Name or Preference.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (locname.SelectedIndex == locname.Items.Count - 1 && others.Text != "")
            {
                locList.Items.Add(others.Text.Trim() + " - " + locpref.Items[locpref.SelectedIndex].ToString().Trim());
            }
            else if (locname.SelectedIndex == locname.Items.Count - 1 && others.Text == "")
            {
                MessageBox.Show("Please enter Other location.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                locList.Items.Add(locname.Items[locname.SelectedIndex].ToString().Trim() + " - " + locpref.Items[locpref.SelectedIndex].ToString().Trim());
            }
            
        }

        private void locname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locname.SelectedIndex == locname.Items.Count -1 )
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("delete from interest where studid=@id", con);
                cmdnewdb.Parameters.AddWithValue("id", sid);
                status = cmdnewdb.ExecuteNonQuery();

                if (status > 0)
                {
                    MessageBox.Show("Interest Details Deleted Succesfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmdnewdb.Parameters.Clear();
                con.Close();
                clearControls(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show("Problem may be: Database Connection doe not exist. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "Delete method of Student Interest Page :" + err.Message);
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string[] flist,llist;

            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("select * from interest where studid=@fid", con);
                cmdnewdb.Parameters.AddWithValue("fid", sid);
                dr = cmdnewdb.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    flist = dr.GetString("fieldlist").Split(',');
                    llist = dr.GetString("loclist").Split(',');

                    foreach(String s in flist)
                    {
                    fieldList.Items.Add(s);
                    }
                    foreach (String s in llist)
                    {
                        locList.Items.Add(s);
                    }
                    comments.Text = dr.GetString("comments");
                    
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dr.Close();
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Problem may be due to incorrect ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "Search method of Student Interest Page :" + err.Message);
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("update interest set fieldlist=@flst,loclist=@llst,comments=@com where studid=@id", con);
                cmdnewdb.Parameters.AddWithValue("id", sid);
                cmdnewdb.Parameters.AddWithValue("flst", fieldList.Text);
                cmdnewdb.Parameters.AddWithValue("llst", locList.Text);
                cmdnewdb.Parameters.AddWithValue("com", comments.Text);

                status = cmdnewdb.ExecuteNonQuery();

                if (status > 0)
                {
                    MessageBox.Show("Interest Details Updated Succesfully", "Updated Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmdnewdb.Parameters.Clear();
                con.Close();
                clearControls(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show("Problem may be: Database Connection doe not exist. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "Update method of Student Interest Page :" + err.Message);
            }
        }

        private void delfield_Click(object sender, EventArgs e)
        {
            fieldList.Items.Remove(fieldList.SelectedItem);
        }

        private void delloc_Click(object sender, EventArgs e)
        {
            locList.Items.Remove(locList.SelectedItem);
        }
    }
}

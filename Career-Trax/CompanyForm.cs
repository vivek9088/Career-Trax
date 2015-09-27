using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace InternshipManagementSystem
{
    public partial class CompanyForm : Form
    {

        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
        MySqlDataReader dr;

        public CompanyForm()
        {
            InitializeComponent();
        }
       
        private void chooseFile_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    cdesc.Text = File.ReadAllText(openFileDialog1.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSelection().Show();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // int comp_id =int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter Company ID:", "Company Id"));
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (cid.Text == "" || cfname.Text == "" || clname.Text == "" || cemail.Text == "" || cnum.Text == "" || cpos.Text == "" || ccity.Text == "" || ccntry.Text == "" || cnpos.Text =="" || caddr.Text == "")
            {
                MessageBox.Show("Please fill in the required fields marked in red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    cmdnewdb = new MySqlCommand("insert into company(cpyname,spocfname,spoclname,position,number,email,fax,city,country,zipcode,address,jobsavail,jobresp,jobreq,jobdesc,cmpid) values(@name,@sf,@sl,@pos,@num,@mail,@fx,@cty,@ctry,@zcode,@addr,@tot,@resp,@req,@desc,@id)", con);

                    cmdnewdb.Parameters.AddWithValue("id", int.Parse(cid.Text));
                    cmdnewdb.Parameters.AddWithValue("name", cname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("sf", cfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("sl", clname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("pos", cpos.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("num", cnum.Text);
                    cmdnewdb.Parameters.AddWithValue("mail", cemail.Text);
                    cmdnewdb.Parameters.AddWithValue("fx", cfax.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("cty", ccity.Text);
                    cmdnewdb.Parameters.AddWithValue("ctry", ccntry.Text);
                    cmdnewdb.Parameters.AddWithValue("zcode", cpostal.Text == "" ? 0 : int.Parse(cpostal.Text));
                    cmdnewdb.Parameters.AddWithValue("addr", caddr.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("tot", int.Parse(cnpos.Text));
                    cmdnewdb.Parameters.AddWithValue("resp", cresp.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("req", creq.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("desc", cdesc.Text.Trim());

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Company Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    clearControls(sender, e);

                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem can be due to following reasons: \n\n1.Company ID already Exists\n2. Problem with Database Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add method of CompanyForm Page :" + err.Message);
                }//End of Catch
                finally
                {
                    con.Close();
                }

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
            
        }

        private void cid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void cnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));

        }

        private void cfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void cpostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void caddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void cresp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void creq_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void cdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void ccntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void ccity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void cemail_Validating(object sender, CancelEventArgs e)
        {
            Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (cemail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(cemail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cemail.Focus();
                }
            }
        }

        private void cpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void clname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void cfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void cname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar));
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (cid.Text == "" || cfname.Text == "" || clname.Text == "" || cemail.Text == "" || cnum.Text == "" || cpos.Text == "" || ccity.Text == "" || ccntry.Text == "" || cnpos.Text == "" || caddr.Text == "")
            {
                MessageBox.Show("Please fill in the required fields marked in red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    cmdnewdb = new MySqlCommand("update company set cpyname=@name,spocfname=@sf,spoclname=@sl,position=@pos,number=@num,email=@mail,fax=@fx,city=@cty,country=@ctry,zipcode=@zcode,address=@addr,jobsavail=@tot,jobresp=@resp,jobreq=@req,jobdesc=@desc where cmpid=@cid", con);

                    cmdnewdb.Parameters.AddWithValue("id", cid.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name", cname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("sf", cfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("sl", clname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("pos", cpos.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("num", cnum.Text);
                    cmdnewdb.Parameters.AddWithValue("mail", cemail.Text);
                    cmdnewdb.Parameters.AddWithValue("fx", cfax.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("cty", ccity.Text);
                    cmdnewdb.Parameters.AddWithValue("ctry", ccntry.Text);
                cmdnewdb.Parameters.AddWithValue("zcode",cpostal.Text==""?0:int.Parse(cpostal.Text));
                    cmdnewdb.Parameters.AddWithValue("addr", caddr.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("tot", int.Parse(cnpos.Text));
                    cmdnewdb.Parameters.AddWithValue("resp", cresp.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("req", creq.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("desc", cdesc.Text.Trim());

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Company Details Updated Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();

                    clearControls(sender, e);

                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Update method of CompanyForm Page :" + err.Message);
                }//End of Catch
                finally
                {
                    con.Close();
                }
            }//End of Outer If-Else
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int status;

            if (cid.Text != "")
            {
                try
                {
                    con.Open();
                    cmdnewdb = new MySqlCommand("delete from company where cmpid=@id", con);
                    cmdnewdb.Parameters.AddWithValue("id", cid.Text.Trim());
                    status = cmdnewdb.ExecuteNonQuery();

                    if (status > 0)
                    {
                        MessageBox.Show("Company Details Deleted Succesfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cmdnewdb.Parameters.Clear();
                    clearControls(sender, e);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Problem may be: Database Connection doe not exist. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Delete method of Student Skills Page :" + err.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid company ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cid.SelectAll();
                cid.Focus();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (cid.Text != "")
            {
              try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("select * from company where cmpid=@fid", con);
                cmdnewdb.Parameters.AddWithValue("fid", cid.Text.Trim());
                dr = cmdnewdb.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    cname.Text = dr.GetString("cpyname");
                    cfname.Text = dr.GetString("spocfname");
                    clname.Text = dr.GetString("spoclname");
                    cnum.Text = dr.GetString("number");
                    cpos.Text = dr.GetString("position");
                    cemail.Text = dr.GetString("email");
                    cpostal.Text = dr.GetString("zipcode");
                    ccity.Text = dr.GetString("city");
                    ccntry.Text = dr.GetString("country");
                    cfax.Text = dr.GetString("fax");
                    caddr.Text = dr.GetString("address");
                    cnpos.Text = dr.GetString("jobsavail");
                    cresp.Text = dr.GetString("jobresp");
                    creq.Text = dr.GetString("jobreq");
                    cdesc.Text = dr.GetString("jobdesc");
                }
                else
                {
                    MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dr.Close();
                }
               
            }
             catch (Exception err)
              {
                 MessageBox.Show("Problem may be due to incorrect ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 CreateLogFile Err = new CreateLogFile();
                 Err.ErrorLog("ErrorLog", "Search method of Student Skills Page :" + err.Message);
              }
              finally
              {
                  con.Close();
              }
            }
            else
            {
                MessageBox.Show("Please enter valid company ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cid.SelectAll();
                cid.Focus();
            }
        }
    }
}

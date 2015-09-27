using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace InternshipManagementSystem
{
    public partial class StudentEducation : Form
    {

        int stud_id = 0,flag=0;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
        MySqlDataReader dr;

        public StudentEducation()
        {
            InitializeComponent();
        }

        public StudentEducation(int stid)
        {
            InitializeComponent();
            stud_id = stid;
            flag = 1;
            //call a function here to fetch student details specific to stud_id given above and display
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            optfall.Checked = false;
            optwinter.Checked = false;

            if (flag == 1)
                bSearch_Click(sender, e);
        }

      

        private void interestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sid.Text == "")
            {
                MessageBox.Show("Please Enter Student Id and the select a Form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sid.Focus();
            }
            else {
                stud_id = int.Parse(sid.Text.Trim());
                this.Hide();
                new StudentInterest(stud_id).Show();
            }
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sid.Text == "")
            {
                MessageBox.Show("Please Enter Student Id and the select a Form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sid.Focus();
            }
            else
            {
                stud_id = int.Parse(sid.Text.Trim());
                this.Hide();
                new StudentKwSkills(stud_id).Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSelection().Show();
        }

        private void internshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sid.Text == "")
            {
                MessageBox.Show("Please Enter Student Id and the select a Form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sid.Focus();
            }
            else
            {
                stud_id = int.Parse(sid.Text.Trim());
                new StudentInternship(stud_id).Show();
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            String degree = "", fromDate = "", todate = "";
           

            if (sid.Text == ""  || sfname.Text =="" || slname.Text=="" || semail.Text=="" || snum.Text == "")
            {
                MessageBox.Show("Please fill in the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
            
                    cmdnewdb = new MySqlCommand("insert into education(semreg,studid,fname,lname,mname,email,number,status,degree,major,gpa,college,place,year,compname,fromdate,todate,desig,duties,semyr) values(@reg,@id,@name1,@name2,@name3,@mail,@num,@stat,@deg,@maj,@mark,@coll,@loc,@yr,@cname,@fdate,@tdate,@desg,@duty,@semyr)", con);

                    if (optfall.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("reg", optfall.Text);
                    }
                    else if (optwinter.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("reg", optwinter.Text);
                    }

                    cmdnewdb.Parameters.AddWithValue("id", int.Parse(sid.Text));
                    cmdnewdb.Parameters.AddWithValue("name1", sfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name2", slname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name3", smname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("mail", semail.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("num", int.Parse(snum.Text));

                    if (status1.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("stat", status1.Text);
                    }
                    else if (status2.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("stat", status2.Text);
                    }
                    else
                    {
                        cmdnewdb.Parameters.AddWithValue("stat","");
                    }

                    degree = cDegree1.SelectedValue + "/" + cDegree2.SelectedValue + "/" + cDegree3.SelectedValue + "/" + cDegree4.SelectedValue;
                    cmdnewdb.Parameters.AddWithValue("deg", degree);

                    cmdnewdb.Parameters.AddWithValue("maj", Major1.Text + "/" + Major2.Text + "/" + Major3.Text + "/" + Major4.Text);
                    cmdnewdb.Parameters.AddWithValue("mark", GPA1.Text + "/" + GPA2.Text + "/" + GPA3.Text + "/" + GPA4.Text);
                    cmdnewdb.Parameters.AddWithValue("coll", College1.Text + "/" + College2.Text + "/" + College3.Text + "/" + College4.Text);
                    cmdnewdb.Parameters.AddWithValue("loc", Place1.Text + "/" + Place2.Text + "/" + Place3.Text + "/" + Place4.Text);
                    cmdnewdb.Parameters.AddWithValue("yr", year1.Text + "/" + year2.Text + "/" + year3.Text + "/" + year4.Text);
                    cmdnewdb.Parameters.AddWithValue("cname", tComp1.Text + "/" + tComp2.Text + "/" + tComp3.Text);

                    fromDate = cFrmDt1.SelectedValue + "-" + cFrmYr1.SelectedText + "/"
                             + cFrmDt2.SelectedValue + "-" + cFrmYr2.SelectedText + "/"
                             + cFrmDt3.SelectedValue + "-" + cFrmYr3.SelectedText; 
                    cmdnewdb.Parameters.AddWithValue("fdate",fromDate);

                    todate = cToDt1.SelectedValue + "-" + cToYr1.SelectedText + "/"
                             + cToDt2.SelectedValue + "-" + cToYr2.SelectedText + "/"
                             + cToDt3.SelectedValue + "-" + cToYr3.SelectedText;
                    cmdnewdb.Parameters.AddWithValue("tdate", todate);
                    cmdnewdb.Parameters.AddWithValue("desg", tDesig1.Text + "/" + tDesig2.Text + "/" + tDesig3.Text);
                    cmdnewdb.Parameters.AddWithValue("duty", tDuty1.Text + "/" + tDuty2.Text + "/" + tDuty3.Text);
                    cmdnewdb.Parameters.AddWithValue("semyr",int.Parse(regyr.Text));

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Student Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();
                  
                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add Student method of StudentEducation Page :" + err.Message);
                }//End of Catch
            }//End of Outer If-Else
        }

        private void clearSem(object sender, EventArgs e)
        {
            regyr.Text ="";
            optfall.Checked=false;
            optwinter.Checked=false;
        }
        
        private void clearPersonal(object sender, EventArgs e)
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
                status1.Checked = false;
                status2.Checked = false;
            }
        }

        private void clearEducation(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)(c)).Text = string.Empty;
                }
            }
        }

        private void clearWork(object sender, EventArgs e)
        {
          foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
          cFrmDt1.Text = "";
          cFrmDt2.Text = "";
          cFrmDt3.Text = "";
          cToDt1.Text = "" ;
          cToDt2.Text = "";
          cToDt3.Text = "";
          cFrmYr1.Text = "";
          cFrmYr2.Text = "";
          cFrmYr3.Text = "";
          cToYr1.Text = "";
          cToYr2.Text = "";
          cToYr3.Text = "";

        }

        private void regyr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void sid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void snum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void semail_Validating(object sender, CancelEventArgs e)
        {
            Regex rEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (semail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(semail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    semail.Focus();
                }
            }
        }

        private void sfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void smname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void slname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void GPA1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void GPA2_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void GPA3_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        
        }

        private void GPA4_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        
        }

        private void Major1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Major2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Major3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Major4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void College1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void College2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void College3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void College4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Place1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Place2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Place3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void Place4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void year1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void year2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void year3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void year4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void tDesig1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void tDesig2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void tDesig3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cFrmYr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cToYr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cFrmYr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cToYr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cFrmYr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void cToYr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            String[] dlst,mlst,glst,clst,plst,ylst,cname,fdt,tdt,desg,dut;

              try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("select * from education where studid=@fid", con);
                cmdnewdb.Parameters.AddWithValue("fid", sid.Text.Trim());
                dr = cmdnewdb.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr.GetString("semreg") == "Fall")
                        optfall.Checked = true;
                    else
                        optwinter.Checked = true;

                    regyr.Text = dr.GetString("semyr");
                    sfname.Text = dr.GetString("fname");
                    slname.Text = dr.GetString("lname");
                    smname.Text = dr.GetString("mname");
                    semail.Text = dr.GetString("email");
                    snum.Text = dr.GetString("number");

                    if (dr.GetString("status") == "International")
                        status1.Checked = true;
                    else
                        status2.Checked = true;

                    dlst = dr.GetString("degree").Split('/');
                        
                    cDegree1.Text = dr.GetString(dlst[0]);
                    cDegree2.Text = dr.GetString(dlst[1]);
                    cDegree3.Text = dr.GetString(dlst[2]);
                    cDegree4.Text = dr.GetString(dlst[3]);

                    mlst = dr.GetString("major").Split('/');

                    Major1.Text = dr.GetString(mlst[0]);
                    Major2.Text = dr.GetString(mlst[1]);
                    Major3.Text = dr.GetString(mlst[2]);
                    Major4.Text = dr.GetString(mlst[3]);

                    glst = dr.GetString("gpa").Split('/');

                    GPA1.Text = dr.GetString(glst[0]);
                    GPA2.Text = dr.GetString(glst[1]);
                    GPA3.Text = dr.GetString(glst[2]);
                    GPA4.Text = dr.GetString(glst[3]);

                    clst = dr.GetString("college").Split('/');

                    College1.Text = dr.GetString(clst[0]);
                    College2.Text = dr.GetString(clst[1]);
                    College3.Text = dr.GetString(clst[2]);
                    College4.Text = dr.GetString(clst[3]);

                    plst = dr.GetString("place").Split('/');

                    Place1.Text = dr.GetString(plst[0]);
                    Place2.Text = dr.GetString(plst[1]);
                    Place3.Text = dr.GetString(plst[2]);
                    Place4.Text = dr.GetString(plst[3]);

                    ylst = dr.GetString("year").Split('/');

                    year1.Text = dr.GetString(ylst[0]);
                    year2.Text = dr.GetString(ylst[1]);
                    year3.Text = dr.GetString(ylst[2]);
                    year4.Text = dr.GetString(ylst[3]);

                    cname = dr.GetString("compname").Split('/');

                    tComp1.Text = dr.GetString(cname[0]);
                    tComp2.Text = dr.GetString(cname[1]);
                    tComp3.Text = dr.GetString(cname[2]);
                    
                    fdt = dr.GetString("fromdate").Split('/');
                    
                    cFrmDt1.Text = dr.GetString(fdt[0].Substring(0,fdt[0].IndexOf('-')));
                    cFrmDt2.Text = dr.GetString(fdt[1].Substring(0, fdt[1].IndexOf('-')));
                    cFrmDt3.Text = dr.GetString(fdt[2].Substring(0, fdt[2].IndexOf('-')));
                    cFrmYr1.Text = dr.GetString(fdt[0].Substring(fdt[0].IndexOf('-'))+1);
                    cFrmYr2.Text = dr.GetString(fdt[1].Substring(fdt[1].IndexOf('-'))+1);
                    cFrmYr3.Text = dr.GetString(fdt[2].Substring(fdt[2].IndexOf('-'))+1);
                   
                    tdt = dr.GetString("todate").Split('/');

                    cToDt1.Text = dr.GetString(tdt[0].Substring(0, tdt[0].IndexOf('-')));
                    cToDt2.Text = dr.GetString(tdt[1].Substring(0, tdt[1].IndexOf('-')));
                    cToDt3.Text = dr.GetString(tdt[2].Substring(0, tdt[2].IndexOf('-')));
                    cToYr1.Text = dr.GetString(tdt[0].Substring(tdt[0].IndexOf('-')) + 1);
                    cToYr2.Text = dr.GetString(tdt[1].Substring(tdt[1].IndexOf('-')) + 1);
                    cToYr3.Text = dr.GetString(tdt[2].Substring(tdt[2].IndexOf('-')) + 1);
                    
                    desg = dr.GetString("desig").Split('/');

                    tDesig1.Text = dr.GetString(desg[0]);
                    tDesig2.Text = dr.GetString(desg[1]);
                    tDesig3.Text = dr.GetString(desg[2]);
                  
                    dut = dr.GetString("duties").Split('/');

                    tDuty1.Text = dr.GetString(dut[0]);
                    tDuty2.Text = dr.GetString(dut[1]);
                    tDuty3.Text = dr.GetString(dut[2]);
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
                  Err.ErrorLog("ErrorLog", "Search method of Student Skills Page :" + err.Message);
              }
        }

        private void clrSem_Click(object sender, EventArgs e)
        {
            clearSem(sender, e);
        }

        private void clrWork_Click(object sender, EventArgs e)
        {
            clearWork(sender, e);
        }

        private void clrPer_Click(object sender, EventArgs e)
        {
            clearPersonal(sender, e);
        }

        private void clrEdu_Click(object sender, EventArgs e)
        {
            clearEducation(sender, e);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            String degree = "", fromDate = "", todate = "";


            if (sid.Text == "" || sfname.Text == "" || slname.Text == "" || semail.Text == "" || snum.Text == "")
            {
                MessageBox.Show("Please fill in the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    cmdnewdb = new MySqlCommand("update education set semreg=@reg,fname=@name1,lname=@name2,mname=@name3,email=@mail,number=@num,status=@stat,degree=@deg,major=@maj,gpa=@tot,college=@coll,place=@loc,year=@yr,compname=@cname,fromdate=@fdate,todate=@tdate,desig=@desg,duties=@duty,semyr=@syr where studid=@id", con);

                    if (optfall.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("reg", optfall.Text);
                    }
                    else if (optwinter.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("reg", optwinter.Text);
                    }

                    cmdnewdb.Parameters.AddWithValue("name1", sfname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name2", slname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("name3", smname.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("mail", semail.Text.Trim());
                    cmdnewdb.Parameters.AddWithValue("num", int.Parse(snum.Text));

                    if (status1.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("stat", status1.Text);
                    }
                    else if (status2.Checked == true)
                    {
                        cmdnewdb.Parameters.AddWithValue("stat", status2.Text);
                    }
                    else
                    {
                        cmdnewdb.Parameters.AddWithValue("stat", "");
                    }

                    degree = cDegree1.SelectedValue + "/" + cDegree2.SelectedValue + "/" + cDegree3.SelectedValue + "/" + cDegree4.SelectedValue;
                    cmdnewdb.Parameters.AddWithValue("deg", degree);

                    cmdnewdb.Parameters.AddWithValue("maj", Major1.Text + "/" + Major2.Text + "/" + Major3.Text + "/" + Major4.Text);
                    cmdnewdb.Parameters.AddWithValue("tot", GPA1.Text + "/" + GPA2.Text + "/" + GPA3.Text + "/" + GPA4.Text);
                    cmdnewdb.Parameters.AddWithValue("coll", College1.Text + "/" + College2.Text + "/" + College3.Text + "/" + College4.Text);
                    cmdnewdb.Parameters.AddWithValue("loc", Place1.Text + "/" + Place2.Text + "/" + Place3.Text + "/" + Place4.Text);
                    cmdnewdb.Parameters.AddWithValue("yr", year1.Text + "/" + year2.Text + "/" + year3.Text + "/" + year4.Text);
                    cmdnewdb.Parameters.AddWithValue("cname", tComp1.Text + "/" + tComp2.Text + "/" + tComp3.Text);

                    fromDate = cFrmDt1.SelectedValue + "-" + cFrmYr1.SelectedText + "/"
                             + cFrmDt2.SelectedValue + "-" + cFrmYr2.SelectedText + "/"
                             + cFrmDt3.SelectedValue + "-" + cFrmYr3.SelectedText;
                    cmdnewdb.Parameters.AddWithValue("fdate", fromDate);

                    todate = cToDt1.SelectedValue + "-" + cToYr1.SelectedText + "/"
                             + cToDt2.SelectedValue + "-" + cToYr2.SelectedText + "/"
                             + cToDt3.SelectedValue + "-" + cToYr3.SelectedText;
                    cmdnewdb.Parameters.AddWithValue("tdate", todate);
                    cmdnewdb.Parameters.AddWithValue("desg", tDesig1.Text + "/" + tDesig2.Text + "/" + tDesig3.Text);
                    cmdnewdb.Parameters.AddWithValue("duty", tDuty1.Text + "/" + tDuty2.Text + "/" + tDuty3.Text);
                    cmdnewdb.Parameters.AddWithValue("syr", int.Parse(regyr.Text));

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Student Details Updated Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add Student method of StudentEducation Page :" + err.Message);
                }//End of Catch
            }//End of Outer If-Else
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int status;

           if(sid.Text!="")
           {
            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("delete from education where studid=@id", con);
                cmdnewdb.Parameters.AddWithValue("id", sid.Text.Trim());
                status = cmdnewdb.ExecuteNonQuery();

                if (status > 0)
                {
                    MessageBox.Show("Student Education Details Deleted Succesfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmdnewdb.Parameters.Clear();
                con.Close();
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Problem may be: Database Connection doe not exist or Invalid Student ID. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "Delete method of Student Education Page :" + err.Message);
            }
           }
           else
           {
            MessageBox.Show("Please enter a student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               sid.SelectAll();
               sid.Focus();
           }
        }

    }
}

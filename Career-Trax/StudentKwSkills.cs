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
    public partial class StudentKwSkills : Form
    {
        int sid=0;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmdnewdb;
        MySqlDataReader dr;

        public StudentKwSkills(int studid)
        {
            InitializeComponent();
            sid = studid;
        }

        private void StudentKwSkills_Load(object sender, EventArgs e)
        {

        }

        private void educationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StudentEducation(sid).Show();
        }

        private void interestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new StudentInterest(sid).Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSelection().Show();
        }

        private void addLang_Click(object sender, EventArgs e)
        {
            if (lang.SelectedIndex == -1 || lvl.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from Programming Language or Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lang.SelectedIndex == lang.Items.Count - 1 && pothers.Text != "")
            {
                plangList.Items.Add(pothers.Text.Trim() + " - " + lvl.Items[lvl.SelectedIndex].ToString().Trim());
            }
            else if (lang.SelectedIndex == lang.Items.Count - 1 && pothers.Text == "")
            {
                MessageBox.Show("Please enter Other Programming Language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                plangList.Items.Add(lang.Items[lang.SelectedIndex].ToString().Trim() + " - " + lvl.Items[lvl.SelectedIndex].ToString().Trim());
            }
        }

        private void addCMS_Click(object sender, EventArgs e)
        {
            if (ccms.SelectedIndex == -1 || cmslvl.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from CMS Name or Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ccms.SelectedIndex == ccms.Items.Count - 1 && cmsother.Text != "")
            {
                cmsList.Items.Add(cmsother.Text.Trim() + " - " + cmslvl.Items[cmslvl.SelectedIndex].ToString().Trim());
            }
            else if (ccms.SelectedIndex == ccms.Items.Count - 1 && cmsother.Text == "")
            {
                MessageBox.Show("Please enter Other CMS name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmsList.Items.Add(ccms.Items[ccms.SelectedIndex].ToString().Trim() + " - " + cmslvl.Items[cmslvl.SelectedIndex].ToString().Trim());
            }
        }

        private void addOS_Click(object sender, EventArgs e)
        {
            if (cos.SelectedIndex == -1 || oslvl.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from OS Name or Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cos.SelectedIndex == cos.Items.Count - 1 && osother.Text != "")
            {
                osList.Items.Add(osother.Text.Trim() + " - " + oslvl.Items[oslvl.SelectedIndex].ToString().Trim());
            }
            else if (cos.SelectedIndex == cos.Items.Count - 1 && osother.Text == "")
            {
                MessageBox.Show("Please enter Other OS Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                osList.Items.Add(cos.Items[cos.SelectedIndex].ToString().Trim() + " - " + oslvl.Items[oslvl.SelectedIndex].ToString().Trim());
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            String flist = "", llist = "", plist ="", olist ="", clist = "";

            if (lang.Items.Count == 0 || langList.Items.Count == 0 || fieldList.Items.Count == 0 || cmsList.Items.Count == 0 || osList.Items.Count == 0)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lang.SelectedIndex == lang.Items.Count - 1 && pothers.Text == "")
            {
                MessageBox.Show("Please Other Programming Language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ccms.SelectedIndex == ccms.Items.Count - 1 && cmsother.Text == "")
            {
                MessageBox.Show("Please Other CMS Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cos.SelectedIndex == cos.Items.Count - 1 && osother.Text == "")
            {
                MessageBox.Show("Please Other OS Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clang.SelectedIndex == clang.Items.Count - 1 && langother.Text == "")
            {
                MessageBox.Show("Please Other Language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Concatenating all items of programming language list
                    for (int pcnt = 0; pcnt < plangList.Items.Count; pcnt++)
                    {
                        if(plist == "")
                            plist += plangList.Items[pcnt].ToString();
                        else
                            plist += "," + plangList.Items[pcnt].ToString();
                    }

                    //Concatenating all items of cms list
                    for (int ccnt = 0; ccnt < cmsList.Items.Count; ccnt++)
                    {
                        if (clist == "")
                            clist += cmsList.Items[ccnt].ToString();
                        else
                            clist += "," + cmsList.Items[ccnt].ToString();
                    }

                    //Concatenating all items of os list
                    for (int ocnt = 0; ocnt < osList.Items.Count; ocnt++)
                    {
                        if (olist == "")
                            olist += osList.Items[ocnt].ToString();
                        else
                            olist += "," + osList.Items[ocnt].ToString();
                    }

                    //Concatenating all items of field list
                    for (int fcnt = 0; fcnt < fieldList.Items.Count; fcnt++)
                    {
                        if (flist == "")
                            flist += fieldList.Items[fcnt].ToString();
                        else
                            flist += "," + fieldList.Items[fcnt].ToString();
                    }

                    //Concatenating all items of lang list
                    for (int gcnt = 0; gcnt < langList.Items.Count; gcnt++)
                    {
                        if (llist == "")
                            llist += langList.Items[gcnt].ToString();
                        else
                            llist += "," + langList.Items[gcnt].ToString();
                    }

                    con.Open();

                    cmdnewdb = new MySqlCommand("insert into skills(studid,proglist,cmslist,oslist,fieldlist,langlist) values(@sid,@plst,@clst,@olst,@flst,@llst)", con);

                    cmdnewdb.Parameters.AddWithValue("sid", sid);
                    cmdnewdb.Parameters.AddWithValue("plst", plist);
                    cmdnewdb.Parameters.AddWithValue("clst", clist);
                    cmdnewdb.Parameters.AddWithValue("olst", olist);
                    cmdnewdb.Parameters.AddWithValue("flst", flist);
                    cmdnewdb.Parameters.AddWithValue("llst", llist);
                   
                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Kwowledge and Skills Details Added Succesfully", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();

                    clearControls(sender,e);

                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Add method of StudentKwSkills Page :" + err.Message);
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
            pothers.Text = "";
            cmsother.Text = "";
            osother.Text = "";
            langother.Text = "";

           
        }

        private void addField_Click(object sender, EventArgs e)
        {
            if (cfield.SelectedIndex == -1 || fldlvl.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from Field or level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fieldList.Items.Add(cfield.Items[cfield.SelectedIndex].ToString().Trim() + " - " + fldlvl.Items[fldlvl.SelectedIndex].ToString().Trim());
            }
        }

        private void clang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clang.SelectedIndex == clang.Items.Count - 1)
                langpanel.Visible = true;
            else
                langpanel.Visible = false;
        }

        private void cos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cos.SelectedIndex == cos.Items.Count - 1)
                ospanel.Visible = true;
            else
                ospanel.Visible = false;

        }

        private void ccms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ccms.SelectedIndex == ccms.Items.Count - 1)
                cmspanel.Visible = true;
            else
                cmspanel.Visible = false;
        }

        private void lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lang.SelectedIndex == lang.Items.Count - 1)
                plangpanel.Visible = true;
            else
                plangpanel.Visible = false;
        }

        private void addMode_Click_1(object sender, EventArgs e)
        {
            if (clang.SelectedIndex == -1 || cmode.SelectedIndex == -1 || langlvl.SelectedIndex == -1)
            {
                MessageBox.Show("Please select one of the options from Languages Name or Mode or Level.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clang.SelectedIndex == clang.Items.Count - 1 && langother.Text != "")
            {
                langList.Items.Add(langother.Text.Trim() + " - " + cmode.Items[cmode.SelectedIndex].ToString().Trim() + " - " + langlvl.Items[langlvl.SelectedIndex].ToString().Trim());
            }
            else if (clang.SelectedIndex == clang.Items.Count - 1 && langother.Text == "")
            {
                MessageBox.Show("Please enter Other Language Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                langList.Items.Add(clang.Items[clang.SelectedIndex].ToString().Trim() + " - " + cmode.Items[cmode.SelectedIndex].ToString().Trim() + " - " + langlvl.Items[langlvl.SelectedIndex].ToString().Trim());
            }
        }

        private void delplang_Click(object sender, EventArgs e)
        {
            plangList.Items.Remove(plangList.SelectedItem);

        }

        private void delcms_Click(object sender, EventArgs e)
        {
            cmsList.Items.Remove(cmsList.SelectedItem);
        }

        private void delos_Click(object sender, EventArgs e)
        {
            osList.Items.Remove(osList.SelectedItem);
        }

        private void dellang_Click(object sender, EventArgs e)
        {
            langList.Items.Remove(langList.SelectedItem);
        }

        private void delfield_Click(object sender, EventArgs e)
        {
           fieldList.Items.Remove(fieldList.SelectedItem);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            String flist = "", llist = "", plist = "", olist = "", clist = "";

            if (lang.Items.Count == 0 || langList.Items.Count == 0 || fieldList.Items.Count == 0 || cmsList.Items.Count == 0 || osList.Items.Count == 0)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lang.SelectedIndex == lang.Items.Count - 1 && pothers.Text == "")
            {
                MessageBox.Show("Please Other Programming Language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ccms.SelectedIndex == ccms.Items.Count - 1 && cmsother.Text == "")
            {
                MessageBox.Show("Please Other CMS Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cos.SelectedIndex == cos.Items.Count - 1 && osother.Text == "")
            {
                MessageBox.Show("Please Other OS Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clang.SelectedIndex == clang.Items.Count - 1 && langother.Text == "")
            {
                MessageBox.Show("Please Other Language.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //Concatenating all items of programming language list
                    for (int pcnt = 0; pcnt < plangList.Items.Count; pcnt++)
                    {
                        if (plist == "")
                            plist += plangList.Items[pcnt].ToString();
                        else
                            plist += "," + plangList.Items[pcnt].ToString();
                    }

                    //Concatenating all items of cms list
                    for (int ccnt = 0; ccnt < cmsList.Items.Count; ccnt++)
                    {
                        if (clist == "")
                            clist += cmsList.Items[ccnt].ToString();
                        else
                            clist += "," + cmsList.Items[ccnt].ToString();
                    }

                    //Concatenating all items of os list
                    for (int ocnt = 0; ocnt < osList.Items.Count; ocnt++)
                    {
                        if (olist == "")
                            olist += osList.Items[ocnt].ToString();
                        else
                            olist += "," + osList.Items[ocnt].ToString();
                    }

                    //Concatenating all items of field list
                    for (int fcnt = 0; fcnt < fieldList.Items.Count; fcnt++)
                    {
                        if (flist == "")
                            flist += fieldList.Items[fcnt].ToString();
                        else
                            flist += "," + fieldList.Items[fcnt].ToString();
                    }

                    //Concatenating all items of lang list
                    for (int gcnt = 0; gcnt < langList.Items.Count; gcnt++)
                    {
                        if (llist == "")
                            llist += langList.Items[gcnt].ToString();
                        else
                            llist += "," + langList.Items[gcnt].ToString();
                    }

                    con.Open();

                    cmdnewdb = new MySqlCommand("update skills set proglist=@plst,cmslist=@clst,oslist=@olst,fieldlist=@flst,langlist=@llst where studi=@sid", con);

                    cmdnewdb.Parameters.AddWithValue("sid", sid);
                    cmdnewdb.Parameters.AddWithValue("plst", plist);
                    cmdnewdb.Parameters.AddWithValue("clst", clist);
                    cmdnewdb.Parameters.AddWithValue("olst", olist);
                    cmdnewdb.Parameters.AddWithValue("flst", flist);
                    cmdnewdb.Parameters.AddWithValue("llst", llist);

                    cmdnewdb.ExecuteNonQuery();
                    MessageBox.Show("Kwowledge and Skills Details Updated Succesfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdnewdb.Parameters.Clear();

                    con.Close();

                    clearControls(sender, e);

                }
                catch (Exception err)
                {
                    MessageBox.Show("There is a problem with input values. Please provide valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateLogFile Err = new CreateLogFile();
                    Err.ErrorLog("ErrorLog", "Update method of StudentKwSkills Page :" + err.Message);
                }//End of Catch
            }//End of Outer If-Else
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("delete from skills where studid=@id", con);
                cmdnewdb.Parameters.AddWithValue("id", sid);
                status = cmdnewdb.ExecuteNonQuery();

                if (status > 0)
                {
                    MessageBox.Show("Knowledge and Skills Details Deleted Succesfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Err.ErrorLog("ErrorLog", "Delete method of Student Skills Page :" + err.Message);
            }

        }

        private void bSearch_Click(object sender, EventArgs e)
        {

            string[] plst, llst,flst,olst,clst;

            try
            {
                con.Open();
                cmdnewdb = new MySqlCommand("select * from skills where studid=@fid", con);
                cmdnewdb.Parameters.AddWithValue("fid", sid);
                dr = cmdnewdb.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    plst = dr.GetString("proglist").Split(',');
                    clst = dr.GetString("cmslist").Split(',');
                    olst = dr.GetString("oslist").Split(',');
                    flst = dr.GetString("fieldlist").Split(',');
                    llst = dr.GetString("langlist").Split(',');

                    foreach (String s in plst)
                    {
                        plangList.Items.Add(s);
                    }
                    foreach (String s in clst)
                    {
                        cmsList.Items.Add(s);
                    }
                    foreach (String s in olst)
                    {
                        osList.Items.Add(s);
                    }
                    foreach (String s in flst)
                    {
                        fieldList.Items.Add(s);
                    }
                    foreach (String s in llst)
                    {
                        langList.Items.Add(s);
                    }

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
                Err.ErrorLog("ErrorLog", "Search method of Student Skills Page :" + err.Message);
            }

        }
    }
}

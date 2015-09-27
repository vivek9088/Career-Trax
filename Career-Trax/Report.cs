using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace InternshipManagementSystem
{
    public partial class Report : Form
    {
        String rptName;
        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.dbcon);
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
 

        public Report(string dbname)
        {
            InitializeComponent();
            rptName = dbname;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            
            if(rptName=="Faculty")
            {
                facultyToolStripMenuItem.Visible = false;
            }
            else if (rptName == "Company")
            {
                companyToolStripMenuItem.Visible = false;
            }
            else
            {
                studentToolStripMenuItem.Visible = false;
            }

            getData(rptName);
        }

        private void getData(String name)
        {
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = new MySqlCommand("select * from " + name, con);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, name);
                dt = ds.Tables[name];
                if (dt.Rows.Count < 1)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                    MessageBox.Show("No Records Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dt;
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = bSource;
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("There must be a Database Connection Problem. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "GetData method of Report Page :" + err.Message);
            }
        }
       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           new FormSelection().Show();
        }
        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Company";
            companyToolStripMenuItem.Visible = false;
            facultyToolStripMenuItem.Visible = true;
            studentToolStripMenuItem.Visible = true;
            getData("Company");
        }
        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Faculty";
            companyToolStripMenuItem.Visible = true;
            facultyToolStripMenuItem.Visible = false;
            studentToolStripMenuItem.Visible = true;
            getData("Faculty");
        }
        private void eduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Education";
            companyToolStripMenuItem.Visible = true;
            facultyToolStripMenuItem.Visible = true;
            studentToolStripMenuItem.Visible = true;
            getData("education");
        }
        private void internToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Internship";
            companyToolStripMenuItem.Visible = true;
            facultyToolStripMenuItem.Visible = true;
            studentToolStripMenuItem.Visible = true;
            getData("internship");
        }
        private void interestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Interest";
            companyToolStripMenuItem.Visible = true;
            facultyToolStripMenuItem.Visible = true;
            studentToolStripMenuItem.Visible = true;
            getData("interest");
        }
        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptName = "Knowledge & Skills";
            companyToolStripMenuItem.Visible = true;
            facultyToolStripMenuItem.Visible = true;
            studentToolStripMenuItem.Visible = true;
            getData("skills");
        }
    }
}

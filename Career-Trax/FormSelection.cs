using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InternshipManagementSystem
{
    public partial class FormSelection : Form
    {
        public FormSelection()
        {
            InitializeComponent();
        }

        private void bShowForm_Click(object sender, EventArgs e)
        {
            switch (cSelectForm.SelectedIndex)
            { 
                case 0:
                    this.Hide();
                    new CompanyForm().Show();
                    break;
                case 1:
                    this.Hide();
                    new FacultyForm().Show();
                    break;
                case 2:
                    this.Hide();
                    new StudentEducation().Show();
                    break;

            }
        }

        private void bShowReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Report(cSelectForm.Items[cSelectForm.SelectedIndex].ToString()).Show();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MasterForm().Show();
        }

        private void errorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles("Logs");
            FileInfo filename;
            
            try
            {
                var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var fullFileName = Path.Combine(desktopFolder, "Logs");

                if (!Directory.Exists(fullFileName))
                {
                    Directory.CreateDirectory(fullFileName);
                }

                for (int i = 1; i < filePaths.Length; i++)
                {
                    filename = new FileInfo(filePaths[i]);

                    File.Copy(filePaths[i], Path.Combine(fullFileName, filename.Name));
                }

                MessageBox.Show("File Export completed");
            }
            catch (Exception err)
            {
                MessageBox.Show("File or Directory Already Exists", "File Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateLogFile Err = new CreateLogFile();
                Err.ErrorLog("ErrorLog", "Export method of FormSelection:" + err.Message);
            }
        }
    }
}

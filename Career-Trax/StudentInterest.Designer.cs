namespace InternshipManagementSystem
{
    partial class StudentInterest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addField = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.locList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addLoc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comments = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.educationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sklevel = new System.Windows.Forms.ComboBox();
            this.skname = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.locname = new System.Windows.Forms.ComboBox();
            this.locpref = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.others = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.delfield = new System.Windows.Forms.Button();
            this.delloc = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldList
            // 
            this.fieldList.FormattingEnabled = true;
            this.fieldList.Location = new System.Drawing.Point(419, 106);
            this.fieldList.Name = "fieldList";
            this.fieldList.Size = new System.Drawing.Size(234, 82);
            this.fieldList.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "What is your level of interest for internship in the following fields?";
            // 
            // addField
            // 
            this.addField.Location = new System.Drawing.Point(365, 118);
            this.addField.Name = "addField";
            this.addField.Size = new System.Drawing.Size(34, 23);
            this.addField.TabIndex = 3;
            this.addField.Text = ">>";
            this.addField.UseVisualStyleBackColor = true;
            this.addField.Click += new System.EventHandler(this.addField_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Student Interest";
            // 
            // locList
            // 
            this.locList.FormattingEnabled = true;
            this.locList.Location = new System.Drawing.Point(419, 255);
            this.locList.Name = "locList";
            this.locList.Size = new System.Drawing.Size(234, 82);
            this.locList.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "What is your preferred location of internship? ";
            // 
            // addLoc
            // 
            this.addLoc.Location = new System.Drawing.Point(365, 266);
            this.addLoc.Name = "addLoc";
            this.addLoc.Size = new System.Drawing.Size(34, 23);
            this.addLoc.TabIndex = 8;
            this.addLoc.Text = ">>";
            this.addLoc.UseVisualStyleBackColor = true;
            this.addLoc.Click += new System.EventHandler(this.addLoc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Please feel free to add anything you want regarding this survey:";
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(70, 455);
            this.comments.Multiline = true;
            this.comments.Name = "comments";
            this.comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.comments.Size = new System.Drawing.Size(342, 137);
            this.comments.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bSearch);
            this.groupBox5.Controls.Add(this.bDelete);
            this.groupBox5.Controls.Add(this.bUpdate);
            this.groupBox5.Controls.Add(this.bAdd);
            this.groupBox5.Location = new System.Drawing.Point(444, 367);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(315, 73);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Student Operations";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(225, 31);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 16;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(152, 31);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 15;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(79, 31);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(75, 23);
            this.bUpdate.TabIndex = 14;
            this.bUpdate.Text = "Update";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(6, 31);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 13;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.educationToolStripMenuItem,
            this.skillsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // educationToolStripMenuItem
            // 
            this.educationToolStripMenuItem.Name = "educationToolStripMenuItem";
            this.educationToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.educationToolStripMenuItem.Text = "Education";
            this.educationToolStripMenuItem.Click += new System.EventHandler(this.educationToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.skillsToolStripMenuItem.Text = "Skills";
            this.skillsToolStripMenuItem.Click += new System.EventHandler(this.skillsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sklevel
            // 
            this.sklevel.FormattingEnabled = true;
            this.sklevel.Items.AddRange(new object[] {
            "Not at All Interested\t",
            "A Little Interested\t",
            "Moderately Interested\t",
            "Very Interested\t",
            "Extremely Interested"});
            this.sklevel.Location = new System.Drawing.Point(169, 154);
            this.sklevel.Name = "sklevel";
            this.sklevel.Size = new System.Drawing.Size(163, 21);
            this.sklevel.TabIndex = 2;
            // 
            // skname
            // 
            this.skname.FormattingEnabled = true;
            this.skname.Items.AddRange(new object[] {
            "Systems Programming",
            "Applications Programming",
            "Web Development",
            "Mobile Development",
            "Games Development",
            "Software Testing",
            "Systems Analysis",
            "Databases",
            "System Administration",
            "Networking",
            "Project Management",
            "Data Analysis / Big Data"});
            this.skname.Location = new System.Drawing.Point(169, 106);
            this.skname.Name = "skname";
            this.skname.Size = new System.Drawing.Size(163, 21);
            this.skname.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Skill Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Skill Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Location Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Preference";
            // 
            // locname
            // 
            this.locname.FormattingEnabled = true;
            this.locname.Items.AddRange(new object[] {
            "Essex/Windsor",
            "Toronto",
            "GTA",
            "Hamilton",
            "London",
            "Ottawa",
            "Waterloo/Kitchener",
            "Anywhere in Ontario",
            "Anywhere in Canada",
            "Others (Please Specify)"});
            this.locname.Location = new System.Drawing.Point(180, 266);
            this.locname.Name = "locname";
            this.locname.Size = new System.Drawing.Size(163, 21);
            this.locname.TabIndex = 6;
            this.locname.SelectedIndexChanged += new System.EventHandler(this.locname_SelectedIndexChanged);
            // 
            // locpref
            // 
            this.locpref.FormattingEnabled = true;
            this.locpref.Items.AddRange(new object[] {
            "Not at All Preferred\t",
            "A Little Preferred\t",
            "Extremely Preferred"});
            this.locpref.Location = new System.Drawing.Point(180, 316);
            this.locpref.Name = "locpref";
            this.locpref.Size = new System.Drawing.Size(163, 21);
            this.locpref.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.others);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(97, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 35);
            this.panel1.TabIndex = 49;
            this.panel1.Visible = false;
            // 
            // others
            // 
            this.others.Location = new System.Drawing.Point(73, 7);
            this.others.Name = "others";
            this.others.Size = new System.Drawing.Size(100, 20);
            this.others.TabIndex = 11;
            this.others.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.others_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Others";
            // 
            // delfield
            // 
            this.delfield.Location = new System.Drawing.Point(365, 165);
            this.delfield.Name = "delfield";
            this.delfield.Size = new System.Drawing.Size(34, 23);
            this.delfield.TabIndex = 4;
            this.delfield.Text = "<<";
            this.delfield.UseVisualStyleBackColor = true;
            this.delfield.Click += new System.EventHandler(this.delfield_Click);
            // 
            // delloc
            // 
            this.delloc.Location = new System.Drawing.Point(365, 309);
            this.delloc.Name = "delloc";
            this.delloc.Size = new System.Drawing.Size(34, 23);
            this.delloc.TabIndex = 9;
            this.delloc.Text = "<<";
            this.delloc.UseVisualStyleBackColor = true;
            this.delloc.Click += new System.EventHandler(this.delloc_Click);
            // 
            // StudentInterest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 616);
            this.Controls.Add(this.delloc);
            this.Controls.Add(this.delfield);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.locpref);
            this.Controls.Add(this.locname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.skname);
            this.Controls.Add(this.sklevel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.comments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.locList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StudentInterest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Knowledge and Skills";
            this.Load += new System.EventHandler(this.StudentInterest_Load);
            this.groupBox5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fieldList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox locList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addLoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox comments;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem educationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox sklevel;
        private System.Windows.Forms.ComboBox skname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox locname;
        private System.Windows.Forms.ComboBox locpref;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox others;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button delfield;
        private System.Windows.Forms.Button delloc;

    }
}
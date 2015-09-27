namespace InternshipManagementSystem
{
    partial class StudentInternship
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.studstat = new System.Windows.Forms.ComboBox();
            this.istatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tcname = new System.Windows.Forms.TextBox();
            this.tmname = new System.Windows.Forms.TextBox();
            this.tfname = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.TextBox();
            this.size = new System.Windows.Forms.TextBox();
            this.pdesc = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Internship Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Faculty/Mentor  Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Project Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Team Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Interview Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Project Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Student Status";
            // 
            // studstat
            // 
            this.studstat.FormattingEnabled = true;
            this.studstat.Items.AddRange(new object[] {
            "Startup Project",
            "Company Hired",
            "Graudated"});
            this.studstat.Location = new System.Drawing.Point(199, 80);
            this.studstat.Name = "studstat";
            this.studstat.Size = new System.Drawing.Size(100, 21);
            this.studstat.TabIndex = 1;
            // 
            // istatus
            // 
            this.istatus.FormattingEnabled = true;
            this.istatus.Items.AddRange(new object[] {
            "Interviewed",
            "Selected",
            "Rejected"});
            this.istatus.Location = new System.Drawing.Point(493, 80);
            this.istatus.Name = "istatus";
            this.istatus.Size = new System.Drawing.Size(121, 21);
            this.istatus.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Manager Name";
            // 
            // tcname
            // 
            this.tcname.Location = new System.Drawing.Point(201, 131);
            this.tcname.Name = "tcname";
            this.tcname.Size = new System.Drawing.Size(100, 20);
            this.tcname.TabIndex = 2;
            this.tcname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcname_KeyPress);
            // 
            // tmname
            // 
            this.tmname.Location = new System.Drawing.Point(201, 181);
            this.tmname.Name = "tmname";
            this.tmname.Size = new System.Drawing.Size(100, 20);
            this.tmname.TabIndex = 3;
            this.tmname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tmname_KeyPress);
            // 
            // tfname
            // 
            this.tfname.Location = new System.Drawing.Point(201, 231);
            this.tfname.Name = "tfname";
            this.tfname.Size = new System.Drawing.Size(100, 20);
            this.tfname.TabIndex = 4;
            this.tfname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tfname_KeyPress);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(201, 281);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(100, 20);
            this.title.TabIndex = 5;
            this.title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.title_KeyPress);
            // 
            // size
            // 
            this.size.Location = new System.Drawing.Point(201, 331);
            this.size.MaxLength = 3;
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(100, 20);
            this.size.TabIndex = 6;
            this.size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.size_KeyPress);
            // 
            // pdesc
            // 
            this.pdesc.Location = new System.Drawing.Point(493, 134);
            this.pdesc.Multiline = true;
            this.pdesc.Name = "pdesc";
            this.pdesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pdesc.Size = new System.Drawing.Size(236, 167);
            this.pdesc.TabIndex = 8;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(372, 321);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(65, 28);
            this.bAdd.TabIndex = 9;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(434, 321);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(75, 28);
            this.bUpdate.TabIndex = 10;
            this.bUpdate.Text = "Update";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bArchive
            // 
            this.bArchive.Location = new System.Drawing.Point(508, 324);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(75, 23);
            this.bArchive.TabIndex = 13;
            this.bArchive.Text = "Archive";
            this.bArchive.UseVisualStyleBackColor = true;
            this.bArchive.Click += new System.EventHandler(this.bArchive_Click);
            // 
            // StudentInternship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 374);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.pdesc);
            this.Controls.Add(this.size);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tfname);
            this.Controls.Add(this.tmname);
            this.Controls.Add(this.tcname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.istatus);
            this.Controls.Add(this.studstat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudentInternship";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentInternship";
            this.Load += new System.EventHandler(this.StudentInternship_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox studstat;
        private System.Windows.Forms.ComboBox istatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tcname;
        private System.Windows.Forms.TextBox tmname;
        private System.Windows.Forms.TextBox tfname;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox size;
        private System.Windows.Forms.TextBox pdesc;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bArchive;
    }
}
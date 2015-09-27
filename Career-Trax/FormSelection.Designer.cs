namespace InternshipManagementSystem
{
    partial class FormSelection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bExit = new System.Windows.Forms.Button();
            this.cSelectForm = new System.Windows.Forms.ComboBox();
            this.bShowReport = new System.Windows.Forms.Button();
            this.bShowForm = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.errorReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bExit);
            this.groupBox1.Controls.Add(this.cSelectForm);
            this.groupBox1.Controls.Add(this.bShowReport);
            this.groupBox1.Controls.Add(this.bShowForm);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(111, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a Form";
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(261, 87);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 36);
            this.bExit.TabIndex = 6;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // cSelectForm
            // 
            this.cSelectForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cSelectForm.FormattingEnabled = true;
            this.cSelectForm.Items.AddRange(new object[] {
            "Company",
            "Faculty",
            "Student"});
            this.cSelectForm.Location = new System.Drawing.Point(101, 43);
            this.cSelectForm.Name = "cSelectForm";
            this.cSelectForm.Size = new System.Drawing.Size(145, 28);
            this.cSelectForm.TabIndex = 5;
            this.cSelectForm.Text = "--Select a Form--";
            // 
            // bShowReport
            // 
            this.bShowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowReport.Location = new System.Drawing.Point(138, 87);
            this.bShowReport.Name = "bShowReport";
            this.bShowReport.Size = new System.Drawing.Size(117, 36);
            this.bShowReport.TabIndex = 4;
            this.bShowReport.Text = "Show Report";
            this.bShowReport.UseVisualStyleBackColor = true;
            this.bShowReport.Click += new System.EventHandler(this.bShowReport_Click);
            // 
            // bShowForm
            // 
            this.bShowForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShowForm.Location = new System.Drawing.Point(17, 87);
            this.bShowForm.Name = "bShowForm";
            this.bShowForm.Size = new System.Drawing.Size(115, 36);
            this.bShowForm.TabIndex = 3;
            this.bShowForm.Text = "Show Form";
            this.bShowForm.UseVisualStyleBackColor = true;
            this.bShowForm.Click += new System.EventHandler(this.bShowForm_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // errorReportToolStripMenuItem
            // 
            this.errorReportToolStripMenuItem.Name = "errorReportToolStripMenuItem";
            this.errorReportToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.errorReportToolStripMenuItem.Text = "Error Report";
            this.errorReportToolStripMenuItem.Click += new System.EventHandler(this.errorReportToolStripMenuItem_Click);
            // 
            // FormSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelection";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bShowReport;
        private System.Windows.Forms.Button bShowForm;
        private System.Windows.Forms.ComboBox cSelectForm;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem errorReportToolStripMenuItem;
    }
}
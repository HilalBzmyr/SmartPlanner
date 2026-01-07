namespace smartPlanner
{
    partial class FrmMain
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
            btnDashboard = new Button();
            btnCourses = new Button();
            btnAssignments = new Button();
            btnExams = new Button();
            btnExit = new Button();
            pnlHeader = new Panel();
            picLogo = new PictureBox();
            lblTitle = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnDashboard
            // 
            btnDashboard.Location = new Point(231, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(136, 59);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnCourses
            // 
            btnCourses.Location = new Point(33, 202);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(131, 55);
            btnCourses.TabIndex = 1;
            btnCourses.Text = "Courses";
            btnCourses.UseVisualStyleBackColor = true;
            btnCourses.Click += btnCourses_Click;
            // 
            // btnAssignments
            // 
            btnAssignments.Location = new Point(236, 202);
            btnAssignments.Name = "btnAssignments";
            btnAssignments.Size = new Size(131, 55);
            btnAssignments.TabIndex = 2;
            btnAssignments.Text = "Assignments";
            btnAssignments.UseVisualStyleBackColor = true;
            btnAssignments.Click += btnAssignments_Click;
            // 
            // btnExams
            // 
            btnExams.Location = new Point(449, 202);
            btnExams.Name = "btnExams";
            btnExams.Size = new Size(127, 55);
            btnExams.TabIndex = 3;
            btnExams.Text = "Exams";
            btnExams.UseVisualStyleBackColor = true;
            btnExams.Click += btnExams_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.ForeColor = SystemColors.ControlText;
            btnExit.Location = new Point(236, 314);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(131, 52);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.RosyBrown;
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(611, 61);
            pnlHeader.TabIndex = 5;
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.unnamed;
            picLogo.Location = new Point(530, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(81, 61);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(202, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(240, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SmartPlanner";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(611, 410);
            Controls.Add(pnlHeader);
            Controls.Add(btnExit);
            Controls.Add(btnExams);
            Controls.Add(btnAssignments);
            Controls.Add(btnCourses);
            Controls.Add(btnDashboard);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmartPlanner - Main Menu";
            TransparencyKey = Color.FromArgb(255, 192, 255);
            Load += FrmMain_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDashboard;
        private Button btnCourses;
        private Button btnAssignments;
        private Button btnExams;
        private Button btnExit;
        private Panel pnlHeader;
        private PictureBox picLogo;
        private Label lblTitle;
    }
}
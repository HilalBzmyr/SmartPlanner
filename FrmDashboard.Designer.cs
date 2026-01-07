namespace smartPlanner
{
    partial class FrmDashboard
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
            dgvConflicts = new DataGridView();
            dgvUpcomingExams = new DataGridView();
            dgvUpcomingAssignments = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvConflicts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingExams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingAssignments).BeginInit();
            SuspendLayout();
            // 
            // dgvConflicts
            // 
            dgvConflicts.AllowUserToAddRows = false;
            dgvConflicts.BackgroundColor = Color.MistyRose;
            dgvConflicts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConflicts.Location = new Point(300, 350);
            dgvConflicts.MultiSelect = false;
            dgvConflicts.Name = "dgvConflicts";
            dgvConflicts.ReadOnly = true;
            dgvConflicts.RowHeadersWidth = 51;
            dgvConflicts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConflicts.Size = new Size(576, 243);
            dgvConflicts.TabIndex = 0;
            // 
            // dgvUpcomingExams
            // 
            dgvUpcomingExams.AllowUserToAddRows = false;
            dgvUpcomingExams.BackgroundColor = Color.MistyRose;
            dgvUpcomingExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcomingExams.Location = new Point(691, 60);
            dgvUpcomingExams.MultiSelect = false;
            dgvUpcomingExams.Name = "dgvUpcomingExams";
            dgvUpcomingExams.ReadOnly = true;
            dgvUpcomingExams.RowHeadersWidth = 51;
            dgvUpcomingExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUpcomingExams.Size = new Size(450, 220);
            dgvUpcomingExams.TabIndex = 1;
            // 
            // dgvUpcomingAssignments
            // 
            dgvUpcomingAssignments.AllowUserToAddRows = false;
            dgvUpcomingAssignments.BackgroundColor = Color.MistyRose;
            dgvUpcomingAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpcomingAssignments.Location = new Point(23, 60);
            dgvUpcomingAssignments.MultiSelect = false;
            dgvUpcomingAssignments.Name = "dgvUpcomingAssignments";
            dgvUpcomingAssignments.ReadOnly = true;
            dgvUpcomingAssignments.RowHeadersWidth = 51;
            dgvUpcomingAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUpcomingAssignments.Size = new Size(470, 220);
            dgvUpcomingAssignments.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightCoral;
            label1.Location = new Point(98, 25);
            label1.Name = "label1";
            label1.Size = new Size(258, 20);
            label1.TabIndex = 3;
            label1.Text = "Upcoming Assignments (Next 7 Days)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightCoral;
            label2.Location = new Point(804, 25);
            label2.Name = "label2";
            label2.Size = new Size(217, 20);
            label2.TabIndex = 4;
            label2.Text = "Upcoming Exams (Next 7 Days)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightCoral;
            label3.Location = new Point(485, 318);
            label3.Name = "label3";
            label3.Size = new Size(186, 20);
            label3.TabIndex = 5;
            label3.Text = "Conflicts (Same Day/Time)";
            label3.Click += label3_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Snow;
            btnRefresh.Location = new Point(541, 201);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 605);
            Controls.Add(btnRefresh);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvUpcomingAssignments);
            Controls.Add(dgvUpcomingExams);
            Controls.Add(dgvConflicts);
            Name = "FrmDashboard";
            Text = " ";
            Load += FrmDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConflicts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingExams).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUpcomingAssignments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConflicts;
        private DataGridView dgvUpcomingExams;
        private DataGridView dgvUpcomingAssignments;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnRefresh;
    }
}
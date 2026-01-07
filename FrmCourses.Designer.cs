namespace smartPlanner
{
    partial class FrmCourses
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
            btnAddCourse = new Button();
            btnUpdateCourse = new Button();
            btnDeleteCourse = new Button();
            btnClear = new Button();
            label1 = new Label();
            txtCourseName = new TextBox();
            label2 = new Label();
            txtInstructorName = new TextBox();
            dgvCourses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(428, 60);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(94, 29);
            btnAddCourse.TabIndex = 0;
            btnAddCourse.Text = "Add";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // btnUpdateCourse
            // 
            btnUpdateCourse.Location = new Point(570, 60);
            btnUpdateCourse.Name = "btnUpdateCourse";
            btnUpdateCourse.Size = new Size(94, 29);
            btnUpdateCourse.TabIndex = 1;
            btnUpdateCourse.Text = "Update";
            btnUpdateCourse.UseVisualStyleBackColor = true;
            btnUpdateCourse.Click += btnUpdateCourse_Click;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.Location = new Point(428, 130);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(94, 29);
            btnDeleteCourse.TabIndex = 2;
            btnDeleteCourse.Text = "Delete";
            btnDeleteCourse.UseVisualStyleBackColor = true;
            btnDeleteCourse.Click += btnDeleteCourse_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(570, 130);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 46);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 4;
            label1.Text = "Course Name:";
            label1.Click += label1_Click;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(162, 46);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(125, 27);
            txtCourseName.TabIndex = 5;
            txtCourseName.TextChanged += txtCourseName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 94);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "Instructor:";
            // 
            // txtInstructorName
            // 
            txtInstructorName.Location = new Point(162, 91);
            txtInstructorName.Name = "txtInstructorName";
            txtInstructorName.Size = new Size(125, 27);
            txtInstructorName.TabIndex = 7;
            txtInstructorName.TextChanged += txtInstructorName_TextChanged;
            // 
            // dgvCourses
            // 
            dgvCourses.BackgroundColor = Color.LightCoral;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Dock = DockStyle.Bottom;
            dgvCourses.Location = new Point(0, 233);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(800, 217);
            dgvCourses.TabIndex = 8;
            dgvCourses.CellClick += dgvCourses_CellClick;
            // 
            // FrmCourses
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCourses);
            Controls.Add(txtInstructorName);
            Controls.Add(label2);
            Controls.Add(txtCourseName);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteCourse);
            Controls.Add(btnUpdateCourse);
            Controls.Add(btnAddCourse);
            Name = "FrmCourses";
            Text = "FrmCourses";
            Load += FrmCourses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddCourse;
        private Button btnUpdateCourse;
        private Button btnDeleteCourse;
        private Button btnClear;
        private Label label1;
        private TextBox txtCourseName;
        private Label label2;
        private TextBox txtInstructorName;
        private DataGridView dgvCourses;
    }
}
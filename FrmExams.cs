using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace smartPlanner
{
    public partial class FrmExams : Form
    {
        private string connStr = ConfigurationManager
            .ConnectionStrings["connStr"].ConnectionString;

        private int selectedExamId = -1;

        public FrmExams()
        {
            InitializeComponent();
        }

        private void FrmExams_Load(object sender, EventArgs e)
        {
            LoadCoursesToCombo();
            LoadExams();
            ClearInputs();
        }

        private void LoadCoursesToCombo()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = "SELECT CourseID, CourseName FROM Courses ORDER BY CourseName";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCourses.DisplayMember = "CourseName";
                cmbCourses.ValueMember = "CourseID";
                cmbCourses.DataSource = dt;
            }
        }

        private void LoadExams()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "SELECT e.ExamID, e.CourseID, c.CourseName, e.ExamType, e.ExamDateTime, e.Description " +
                    "FROM Exams e " +
                    "INNER JOIN Courses c ON c.CourseID = e.CourseID " +
                    "ORDER BY e.ExamDateTime";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvExams.DataSource = dt;
            }

            if (dgvExams.Columns.Count > 0)
            {
                dgvExams.Columns["ExamID"].HeaderText = "ID";
                dgvExams.Columns["CourseName"].HeaderText = "Course";
                dgvExams.Columns["ExamType"].HeaderText = "Exam Type";
                dgvExams.Columns["ExamDateTime"].HeaderText = "Date/Time";
                dgvExams.Columns["CourseID"].Visible = false;
            }
        }

        private void ClearInputs()
        {
            selectedExamId = -1;
            txtExamType.Clear();
            txtDescription.Clear();
            dtpExamDateTime.Value = DateTime.Now.AddDays(1);

            if (cmbCourses.Items.Count > 0)
                cmbCourses.SelectedIndex = 0;
        }

        private void AddExam()
        {
            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExamType.Text))
            {
                MessageBox.Show("Exam Type cannot be empty.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "INSERT INTO Exams (CourseID, ExamType, ExamDateTime, Description) " +
                    "VALUES (@cid, @type, @dt, @desc)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@cid", (int)cmbCourses.SelectedValue);
                cmd.Parameters.AddWithValue("@type", txtExamType.Text.Trim());
                cmd.Parameters.AddWithValue("@dt", dtpExamDateTime.Value);
                cmd.Parameters.AddWithValue("@desc",
                    string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadExams();
            ClearInputs();
        }

        private void UpdateExam()
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Select an exam from the list first.");
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExamType.Text))
            {
                MessageBox.Show("Exam Type cannot be empty.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "UPDATE Exams " +
                    "SET CourseID=@cid, ExamType=@type, ExamDateTime=@dt, Description=@desc " +
                    "WHERE ExamID=@id";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@cid", (int)cmbCourses.SelectedValue);
                cmd.Parameters.AddWithValue("@type", txtExamType.Text.Trim());
                cmd.Parameters.AddWithValue("@dt", dtpExamDateTime.Value);
                cmd.Parameters.AddWithValue("@desc",
                    string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@id", selectedExamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadExams();
            ClearInputs();
        }

        private void DeleteExam()
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Select an exam from the list first.");
                return;
            }

            var result = MessageBox.Show("Delete selected exam?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = "DELETE FROM Exams WHERE ExamID=@id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", selectedExamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadExams();
            ClearInputs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddExam();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateExam();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteExam();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvExams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            if (dgvExams.CurrentRow.IsNewRow) return;

            var row = dgvExams.CurrentRow;

            if (row.Cells["ExamID"].Value == null || row.Cells["ExamID"].Value == DBNull.Value) return;

            selectedExamId = Convert.ToInt32(row.Cells["ExamID"].Value);

            if (row.Cells["CourseID"].Value != null && row.Cells["CourseID"].Value != DBNull.Value)
                cmbCourses.SelectedValue = Convert.ToInt32(row.Cells["CourseID"].Value);

            txtExamType.Text = row.Cells["ExamType"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value == DBNull.Value ? "" : row.Cells["Description"].Value?.ToString();

            if (row.Cells["ExamDateTime"].Value != null && row.Cells["ExamDateTime"].Value != DBNull.Value)
                dtpExamDateTime.Value = Convert.ToDateTime(row.Cells["ExamDateTime"].Value);
        }
    }
}
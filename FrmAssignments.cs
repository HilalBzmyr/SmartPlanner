using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace smartPlanner
{
    public partial class FrmAssignments : Form
    {
        private string connStr = ConfigurationManager
            .ConnectionStrings["connStr"].ConnectionString;

        private int selectedAssignmentId = -1;

        public FrmAssignments()
        {
            InitializeComponent();
        }

        private void FrmAssignments_Load(object sender, EventArgs e)
        {
            LoadCoursesToCombo();
            LoadAssignments();
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

        private void LoadAssignments()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "SELECT a.AssignmentID, a.CourseID, c.CourseName, a.Title, a.Description, a.DueDate " +
                    "FROM Assignments a " +
                    "INNER JOIN Courses c ON c.CourseID = a.CourseID " +
                    "ORDER BY a.DueDate";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAssignments.DataSource = dt;
            }

            if (dgvAssignments.Columns.Count > 0)
            {
                dgvAssignments.Columns["AssignmentID"].HeaderText = "ID";
                dgvAssignments.Columns["CourseName"].HeaderText = "Course";
                dgvAssignments.Columns["DueDate"].HeaderText = "Due Date";
                dgvAssignments.Columns["CourseID"].Visible = false;
            }
        }

        private void ClearInputs()
        {
            selectedAssignmentId = -1;
            txtTitle.Clear();
            txtDescription.Clear();
            dtpDueDate.Value = DateTime.Now.AddDays(1);

            if (cmbCourses.Items.Count > 0)
                cmbCourses.SelectedIndex = 0;
        }

        private void AddAssignment()
        {
            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "INSERT INTO Assignments (CourseID, Title, Description, DueDate) " +
                    "VALUES (@cid, @title, @desc, @due)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@cid", (int)cmbCourses.SelectedValue);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@desc",
                    string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@due", dtpDueDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadAssignments();
            ClearInputs();
        }

        private void UpdateAssignment()
        {
            if (selectedAssignmentId == -1)
            {
                MessageBox.Show("Select an assignment from the list first.");
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q =
                    "UPDATE Assignments " +
                    "SET CourseID=@cid, Title=@title, Description=@desc, DueDate=@due " +
                    "WHERE AssignmentID=@id";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@cid", (int)cmbCourses.SelectedValue);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@desc",
                    string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@due", dtpDueDate.Value);
                cmd.Parameters.AddWithValue("@id", selectedAssignmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadAssignments();
            ClearInputs();
        }

        private void DeleteAssignment()
        {
            if (selectedAssignmentId == -1)
            {
                MessageBox.Show("Select an assignment from the list first.");
                return;
            }

            var result = MessageBox.Show("Delete selected assignment?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = "DELETE FROM Assignments WHERE AssignmentID=@id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@id", selectedAssignmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadAssignments();
            ClearInputs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAssignment();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAssignment();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAssignment();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvAssignments.Rows[e.RowIndex];

            // ✅ NEW ROW / NULL koruması
            if (row.IsNewRow) return;
            if (row.Cells["AssignmentID"].Value == DBNull.Value || row.Cells["AssignmentID"].Value == null) return;

            selectedAssignmentId = Convert.ToInt32(row.Cells["AssignmentID"].Value);

            int courseId = Convert.ToInt32(row.Cells["CourseID"].Value);
            cmbCourses.SelectedValue = courseId;

            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells["Description"].Value == DBNull.Value ? "" : row.Cells["Description"].Value?.ToString();

            if (row.Cells["DueDate"].Value != null && row.Cells["DueDate"].Value != DBNull.Value)
                dtpDueDate.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);
        }
    }
}
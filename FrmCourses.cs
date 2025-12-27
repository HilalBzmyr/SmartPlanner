using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace smartPlanner
{
    public partial class FrmCourses : Form
    {
        // Connection string (App.config içindeki "connStr" ile aynı isim olmalı)
        private string connStr = ConfigurationManager
            .ConnectionStrings["connStr"].ConnectionString;

        // Seçili CourseID'yi tutmak için
        private int selectedCourseId = -1;

        public FrmCourses()
        {
            InitializeComponent();
        }

        private void FrmCourses_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        // Courses tablosunu DataGridView'e yükleyen metod
        private void LoadCourses()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT CourseID, CourseName, InstructorName FROM Courses";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCourses.DataSource = dt;
            }

            // Sütun başlıkları daha okunaklı olsun
            if (dgvCourses.Columns.Count > 0)
            {
                dgvCourses.Columns["CourseID"].HeaderText = "ID";
                dgvCourses.Columns["CourseName"].HeaderText = "Course Name";
                dgvCourses.Columns["InstructorName"].HeaderText = "Instructor";
            }
        }

        // TextBox'ları temizleyen metod
        private void ClearInputs()
        {
            txtCourseName.Clear();
            txtInstructorName.Clear();
            selectedCourseId = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Basit validation: CourseName boşsa ekleme
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name cannot be empty.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Courses (CourseName, InstructorName) " +
                               "VALUES (@name, @inst)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@inst",
                    string.IsNullOrWhiteSpace(txtInstructorName.Text)
                        ? (object)DBNull.Value
                        : txtInstructorName.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadCourses();
            ClearInputs();

        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course from the list to update.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name cannot be empty.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Courses " +
                               "SET CourseName = @name, InstructorName = @inst " +
                               "WHERE CourseID = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@inst",
                    string.IsNullOrWhiteSpace(txtInstructorName.Text)
                        ? (object)DBNull.Value
                        : txtInstructorName.Text);
                cmd.Parameters.AddWithValue("@id", selectedCourseId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadCourses();
            ClearInputs();
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course from the list to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this course?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Courses WHERE CourseID = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedCourseId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadCourses();
            ClearInputs();

        }

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInstructorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header'a tıklanmışsa

            DataGridViewRow row = dgvCourses.Rows[e.RowIndex];

            selectedCourseId = Convert.ToInt32(row.Cells["CourseID"].Value);
            txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
            txtInstructorName.Text = row.Cells["InstructorName"].Value.ToString();

        }
    }
}

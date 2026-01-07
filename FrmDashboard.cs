using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace smartPlanner
{
    public partial class FrmDashboard : Form
    {
        private string connStr = ConfigurationManager
            .ConnectionStrings["connStr"].ConnectionString;

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            LoadUpcomingAssignments();
            LoadUpcomingExams();
            LoadConflicts();
            ColorizeRows();
        }

        private void LoadUpcomingAssignments()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = @"
SELECT 
    a.AssignmentID,
    c.CourseName,
    a.Title,
    a.DueDate,
    a.Description
FROM Assignments a
INNER JOIN Courses c ON c.CourseID = a.CourseID
WHERE a.DueDate >= GETDATE()
  AND a.DueDate < DATEADD(DAY, 7, GETDATE())
ORDER BY a.DueDate;";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUpcomingAssignments.DataSource = dt;
            }
        }

        private void LoadUpcomingExams()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = @"
SELECT
    e.ExamID,
    c.CourseName,
    e.ExamType,
    e.ExamDateTime,
    e.Description
FROM Exams e
INNER JOIN Courses c ON c.CourseID = e.CourseID
WHERE e.ExamDateTime >= GETDATE()
  AND e.ExamDateTime < DATEADD(DAY, 7, GETDATE())
ORDER BY e.ExamDateTime;";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUpcomingExams.DataSource = dt;
            }
        }

        // Conflict rule:
        // If an assignment DueDate is at the SAME minute as an exam ExamDateTime => conflict
        // (You can relax this later to "same day" if you want)
        private void LoadConflicts()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string q = @"
SELECT 
    c.CourseName,
    a.Title AS AssignmentTitle,
    a.DueDate,
    e.ExamType,
    e.ExamDateTime
FROM Assignments a
INNER JOIN Exams e 
    ON DATEDIFF(MINUTE, a.DueDate, e.ExamDateTime) = 0
INNER JOIN Courses c 
    ON c.CourseID = a.CourseID AND c.CourseID = e.CourseID
ORDER BY a.DueDate;";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvConflicts.DataSource = dt;
            }
        }

        // "7 days içinde olanlar kırmızı" kısmı
        // Here: if remaining days <= 3 => red-ish, <= 7 => orange-ish (we'll just use default red highlight)
        private void ColorizeRows()
        {
            ColorizeGridByDate(dgvUpcomingAssignments, "DueDate");
            ColorizeGridByDate(dgvUpcomingExams, "ExamDateTime");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // do nothing
        }

        private void ColorizeGridByDate(DataGridView grid, string dateColumnName)
        {
            if (grid.DataSource == null) return;
            if (!grid.Columns.Contains(dateColumnName)) return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                object val = row.Cells[dateColumnName].Value;
                if (val == null || val == DBNull.Value) continue;

                DateTime dt = Convert.ToDateTime(val);
                double daysLeft = (dt - DateTime.Now).TotalDays;

                // within 7 days -> highlight
                if (daysLeft <= 7)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose; // light red
                }

                // within 3 days -> stronger highlight
                if (daysLeft <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
    }
}
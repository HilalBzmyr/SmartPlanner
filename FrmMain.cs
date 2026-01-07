using System;
using System.Windows.Forms;

namespace smartPlanner
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // boş kalabilir
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            new FrmDashboard().Show();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            new FrmCourses().Show();
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            new FrmAssignments().Show();
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            new FrmExams().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
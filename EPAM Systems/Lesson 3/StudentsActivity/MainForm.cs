using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class MainForm : Form
    {
        private ActivityContext context;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            context = new ActivityContext();
            try
            {
                olympiadChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
                competitionChoice.DataSource = context.Competitions.Select(c => c.CompetitionName).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsForm studentsForm = new StudentsForm(context);
            studentsForm.ShowDialog();
        }

        private void olympiadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OlympiadsForm olympiadsForm = new OlympiadsForm(context);
            olympiadsForm.ShowDialog();
            olympiadChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
        }

        private void competitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsForm competitionsForm = new CompetitionsForm(context);
            competitionsForm.ShowDialog();
            competitionChoice.DataSource = context.Competitions.Select(c => c.CompetitionName).ToList();
        }

        private void studentsParticipationsInOlympiadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OlympiadStudentParticipationsForm olympiadStudentParticipationsForm = new OlympiadStudentParticipationsForm(context);
            olympiadStudentParticipationsForm.ShowDialog();
            olympiadChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
        }

        private void studentsParticipationsInCompetitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionStudentParticipationsForm competitionStudentParticipationsForm = new CompetitionStudentParticipationsForm(context);
            competitionStudentParticipationsForm.ShowDialog();
            competitionChoice.DataSource = context.Competitions.Select(c => c.CompetitionName).ToList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.Dispose();
            Close();
        }

        private void toolStripStudents_Click(object sender, EventArgs e)
        {
            studentsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripOlympiads_Click(object sender, EventArgs e)
        {
            olympiadsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripCompetitions_Click(object sender, EventArgs e)
        {
            competitionsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripOlympiadStudentParticipation_Click(object sender, EventArgs e)
        {
            studentsParticipationsInOlympiadsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripCompetitionStudentParticipation_Click(object sender, EventArgs e)
        {
            studentsParticipationsInCompetitionsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void olympiadChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var participations = context.OlympiadStudentParticipations.Where(o => o.Olympiad.OlympiadName == olympiadChoice.Text).Select(o => o.StudentId).ToList();
                olympiadStudentsView.DataSource = context.Students.Where(s => participations.Contains(s.StudentId)).OrderBy(s => s.StudentName).ToList();
                olympiadStudentsView.Columns[0].Visible = false;
                olympiadStudentsView.Columns[1].HeaderText = "Full name";
                olympiadStudentsView.Columns[1].Width = 150;
                olympiadStudentsView.Columns[2].HeaderText = "Birthdate";
                olympiadStudentsView.Columns[2].Width = 70;
                olympiadStudentsView.Columns[3].HeaderText = "Home address";
                olympiadStudentsView.Columns[3].Width = 270;
                olympiadStudentsView.Columns[4].HeaderText = "Telephone";
                olympiadStudentsView.Columns[4].Width = 105;
                olympiadStudentsView.Columns[5].HeaderText = "University";
                olympiadStudentsView.Columns[5].Width = 170;
                olympiadStudentsView.Columns[6].HeaderText = "Course";
                olympiadStudentsView.Columns[6].Width = 48;
                olympiadStudentsView.Columns[7].Visible = false;
                olympiadStudentsView.Columns[8].Visible = false;
                olympiadStudentsView.RowHeadersVisible = olympiadStudentsView.ColumnHeadersVisible = olympiadStudentsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void competitionChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var participations = context.CompetitionStudentParticipations.Where(c => c.Competition.CompetitionName == competitionChoice.Text).Select(c => c.StudentId).ToList();
                competitionStudentsView.DataSource = context.Students.Where(s => participations.Contains(s.StudentId)).OrderBy(s => s.StudentName).ToList();
                competitionStudentsView.Columns[0].Visible = false;
                competitionStudentsView.Columns[1].HeaderText = "Full name";
                competitionStudentsView.Columns[1].Width = 150;
                competitionStudentsView.Columns[2].HeaderText = "Birthdate";
                competitionStudentsView.Columns[2].Width = 70;
                competitionStudentsView.Columns[3].HeaderText = "Home address";
                competitionStudentsView.Columns[3].Width = 270;
                competitionStudentsView.Columns[4].HeaderText = "Telephone";
                competitionStudentsView.Columns[4].Width = 105;
                competitionStudentsView.Columns[5].HeaderText = "University";
                competitionStudentsView.Columns[5].Width = 170;
                competitionStudentsView.Columns[6].HeaderText = "Course";
                competitionStudentsView.Columns[6].Width = 48;
                competitionStudentsView.Columns[7].Visible = false;
                competitionStudentsView.Columns[8].Visible = false;
                competitionStudentsView.RowHeadersVisible = competitionStudentsView.ColumnHeadersVisible = competitionStudentsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }
    }
}
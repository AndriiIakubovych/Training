using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class AddCompetitionStudentParticipationForm : Form
    {
        private ActivityContext context;

        public AddCompetitionStudentParticipationForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void AddCompetitionStudentParticipationForm_Load(object sender, EventArgs e)
        {
            try
            {
                studentChoice.DataSource = context.Students.Select(s => s.StudentName).ToList();
                if (studentChoice.Items.Count > 0)
                    studentChoice.SelectedIndex = 0;
                else
                    studentChoiceText.Enabled = studentChoice.Enabled = false;
                competitionChoice.DataSource = context.Competitions.Select(c => c.CompetitionName).ToList();
                if (competitionChoice.Items.Count > 0)
                    competitionChoice.SelectedIndex = 0;
                else
                    competitionChoiceText.Enabled = competitionChoice.Enabled = false;
                resultsChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void place_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = studentChoice.Items.Count > 0 && competitionChoice.Items.Count > 0 && place.TextLength > 0;
        }

        public int StudentId
        {
            get { return context.Students.Where(s => s.StudentName == studentChoice.Text).Select(s => s.StudentId).SingleOrDefault(); }
        }

        public int CompetitionId
        {
            get { return context.Competitions.Where(c => c.CompetitionName == competitionChoice.Text).Select(c => c.CompetitionId).SingleOrDefault(); }
        }

        public string ParticipationDate
        {
            get { return participationDate.Text; }
        }

        public string Place
        {
            get { return place.Text; }
        }

        public string Results
        {
            get { return resultsChoice.Text; }
        }
    }
}
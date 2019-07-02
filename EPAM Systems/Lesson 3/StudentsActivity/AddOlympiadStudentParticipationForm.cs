using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class AddOlympiadStudentParticipationForm : Form
    {
        private ActivityContext context;

        public AddOlympiadStudentParticipationForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void AddOlympiadStudentParticipationForm_Load(object sender, EventArgs e)
        {
            try
            {
                studentChoice.DataSource = context.Students.Select(s => s.StudentName).ToList();
                if (studentChoice.Items.Count > 0)
                    studentChoice.SelectedIndex = 0;
                else
                    studentChoiceText.Enabled = studentChoice.Enabled = false;
                olympiadChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
                if (olympiadChoice.Items.Count > 0)
                    olympiadChoice.SelectedIndex = 0;
                else
                    olympiadChoiceText.Enabled = olympiadChoice.Enabled = false;
                resultsChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void place_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = studentChoice.Items.Count > 0 && olympiadChoice.Items.Count > 0 && place.TextLength > 0;
        }

        public int StudentId
        {
            get { return context.Students.Where(s => s.StudentName == studentChoice.Text).Select(s => s.StudentId).SingleOrDefault(); }
        }

        public int OlympiadId
        {
            get { return context.Olympiads.Where(o => o.OlympiadName == olympiadChoice.Text).Select(o => o.OlympiadId).SingleOrDefault(); }
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
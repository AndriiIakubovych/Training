using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class EditOlympiadStudentParticipationForm : Form
    {
        private ActivityContext context;

        public string StudentName { private get; set; }
        public string OlympiadName { private get; set; }
        public string ResultsName { private get; set; }

        public EditOlympiadStudentParticipationForm(ActivityContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void EditOlympiadStudentParticipationForm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                studentChoice.DataSource = context.Students.Select(s => s.StudentName).ToList();
                if (studentChoice.Items.Count > 0)
                {
                    studentChoice.SelectedIndex = 0;
                    foreach (string s in studentChoice.Items)
                    {
                        if (studentChoice.Items[i].ToString() == StudentName)
                            studentChoice.SelectedIndex = i;
                        i++;
                    }
                }
                else
                    studentChoiceText.Enabled = studentChoice.Enabled = false;
                olympiadChoice.DataSource = context.Olympiads.Select(o => o.OlympiadName).ToList();
                i = 0;
                if (olympiadChoice.Items.Count > 0)
                {
                    olympiadChoice.SelectedIndex = 0;
                    foreach (string o in olympiadChoice.Items)
                    {
                        if (olympiadChoice.Items[i].ToString() == OlympiadName)
                            olympiadChoice.SelectedIndex = i;
                        i++;
                    }
                }
                else
                    olympiadChoiceText.Enabled = olympiadChoice.Enabled = false;
                resultsChoice.SelectedIndex = 0;
                i = 0;
                resultsChoice.SelectedIndex = 0;
                foreach (string r in resultsChoice.Items)
                {
                    if (resultsChoice.Items[i].ToString() == ResultsName)
                        resultsChoice.SelectedIndex = i;
                    i++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Data read error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void place_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = place.TextLength > 0;
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
            set { participationDate.Text = value; }
        }

        public string Place
        {
            get { return place.Text; }
            set { place.Text = value; }
        }

        public string Results
        {
            get { return resultsChoice.Text; }
            set { resultsChoice.Text = value; }
        }
    }
}
using System;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class EditCompetitionForm : Form
    {
        public EditCompetitionForm()
        {
            InitializeComponent();
        }

        private void competitionName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = competitionName.TextLength > 0;
        }

        public string CompetitionName
        {
            get { return competitionName.Text; }
            set { competitionName.Text = value; }
        }
    }
}
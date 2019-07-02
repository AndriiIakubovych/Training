using System;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class AddCompetitionForm : Form
    {
        public AddCompetitionForm()
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
        }
    }
}
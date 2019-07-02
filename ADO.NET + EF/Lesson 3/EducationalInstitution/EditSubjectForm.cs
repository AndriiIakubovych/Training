using System;
using System.Windows.Forms;

namespace EducationalInstitution
{
    public partial class EditSubjectForm : Form
    {
        public EditSubjectForm()
        {
            InitializeComponent();
        }

        private void subjectName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = subjectName.Text.Length > 0;
        }

        public string SubjectName
        {
            get { return subjectName.Text; }
            set { subjectName.Text = value; }
        }
    }
}
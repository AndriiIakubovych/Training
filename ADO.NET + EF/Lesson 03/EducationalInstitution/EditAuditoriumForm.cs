using System;
using System.Windows.Forms;

namespace EducationalInstitution
{
    public partial class EditAuditoriumForm : Form
    {
        public EditAuditoriumForm()
        {
            InitializeComponent();
        }

        private void auditoriumNumber_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = auditoriumNumber.Text.Length > 0;
        }

        public string AuditoriumNumber
        {
            get { return auditoriumNumber.Text; }
            set { auditoriumNumber.Text = value; }
        }
    }
}
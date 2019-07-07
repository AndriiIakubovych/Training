using System;
using System.Windows.Forms;

namespace EducationalInstitution
{
    public partial class AddSpecialtyForm : Form
    {
        public AddSpecialtyForm()
        {
            InitializeComponent();
        }

        private void specialtyName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = specialtyName.Text.Length > 0;
        }

        public string SpecialtyName
        {
            get { return specialtyName.Text; }
        }
    }
}
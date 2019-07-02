using System;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class AddOlympiadForm : Form
    {
        public AddOlympiadForm()
        {
            InitializeComponent();
        }

        private void olympiadName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = olympiadName.TextLength > 0;
        }

        public string OlympiadName
        {
            get { return olympiadName.Text; }
        }
    }
}
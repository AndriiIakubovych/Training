using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class EditOlympiadForm : Form
    {
        public EditOlympiadForm()
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
            set { olympiadName.Text = value; }
        }
    }
}
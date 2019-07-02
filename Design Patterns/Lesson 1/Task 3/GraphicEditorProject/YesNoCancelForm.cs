using System;
using System.Windows.Forms;

namespace GraphicEditorProject
{
    public partial class YesNoCancelForm : Form
    {
        public bool YesClick { get; private set; }

        public YesNoCancelForm()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            YesClick = true;
        }

        private void no_Click(object sender, EventArgs e)
        {
            YesClick = false;
        }
    }
}
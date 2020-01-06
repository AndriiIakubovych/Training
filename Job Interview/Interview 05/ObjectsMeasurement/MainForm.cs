using System;
using System.Windows.Forms;

namespace ObjectsMeasurement
{
    public partial class MainForm : Form
    {
        private ScreenForm screenForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Measure_Click(object sender, EventArgs e)
        {
            Visible = false;
            screenForm = new ScreenForm(this, objectWidth, objectHeight);
            screenForm.Show();
            screenForm.UpdateScreenForm();
        }
    }
}
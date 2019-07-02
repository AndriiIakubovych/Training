using System;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class AddNoteForm : Form
    {
        public AddNoteForm()
        {
            InitializeComponent();
        }

        private void noteName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = noteName.Text.Length > 0;
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            if (endTime.Value > beginningTime.Value)
                ok.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string NoteName
        {
            get { return noteName.Text; }
        }

        public DateTime BeginningTime
        {
            get { return beginningTime.Value; }
        }

        public DateTime EndTime
        {
            get { return endTime.Value; }
        }

        public string Description
        {
            get { return description.Text; }
        }
    }
}
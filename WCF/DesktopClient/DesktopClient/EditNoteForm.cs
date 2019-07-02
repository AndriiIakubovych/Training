using System;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class EditNoteForm : Form
    {
        public EditNoteForm()
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
            set { noteName.Text = value; }
        }

        public DateTime BeginningTime
        {
            get { return beginningTime.Value; }
            set { beginningTime.Value = value; }
        }

        public DateTime EndTime
        {
            get { return endTime.Value; }
            set { endTime.Value = value; }
        }

        public string Description
        {
            get { return description.Text; }
            set { description.Text = value; }
        }
    }
}
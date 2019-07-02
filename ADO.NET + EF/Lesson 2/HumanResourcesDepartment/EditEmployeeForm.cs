using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class EditEmployeeForm : Form
    {
        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        private void employeeName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = employeeName.Text.Length > 0 && position.Text.Length > 0;
        }

        private void position_TextChanged(object sender, EventArgs e)
        {
            employeeName_TextChanged(sender, e);
        }

        private void changePhoto_CheckedChanged(object sender, EventArgs e)
        {
            photo.Clear();
            photo.Enabled = openFile.Enabled = changePhoto.Checked;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                photo.Text = openFileDialog.FileName;
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (HiringOrderNumber.Length == 0 || (Convert.ToInt32(HiringOrderNumber) > 0) && (FiringOrderNumber.Length == 0 || Convert.ToInt32(FiringOrderNumber) > 0))
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string EmployeeName
        {
            get { return employeeName.Text; }
            set { employeeName.Text = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate.Value; }
            set { birthdate.Value = value; }
        }

        public string Position
        {
            get { return position.Text; }
            set { position.Text = value; }
        }

        public string HiringOrderNumber
        {
            get { return hiringOrderNumber.Text; }
            set { hiringOrderNumber.Text = value; }
        }

        public string FiringOrderNumber
        {
            get { return firingOrderNumber.Text; }
            set { firingOrderNumber.Text = value; }
        }

        public bool ChangePhoto
        {
            get { return changePhoto.Checked; }
        }

        public string PhotoFileName
        {
            get { return photo.Text; }
        }
    }
}
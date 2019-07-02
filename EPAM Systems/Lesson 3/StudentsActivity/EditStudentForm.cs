using System;
using System.Windows.Forms;

namespace StudentsActivity
{
    public partial class EditStudentForm : Form
    {
        public EditStudentForm()
        {
            InitializeComponent();
        }

        private void studentName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = studentName.TextLength > 0;
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (course.TextLength == 0 || Convert.ToInt32(course.Text) > 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Some values are entered incorrectly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Input error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string StudentName
        {
            get { return studentName.Text; }
            set { studentName.Text = value; }
        }

        public string Birthdate
        {
            get { return birthdate.Text; }
            set { birthdate.Text = value; }
        }

        public string Address
        {
            get { return address.Text; }
            set { address.Text = value; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
            set { telephone.Text = value; }
        }

        public string University
        {
            get { return university.Text; }
            set { university.Text = value; }
        }

        public string Course
        {
            get { return course.Text; }
            set { course.Text = value; }
        }
    }
}
using System;
using System.Text;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EditEmployeeForm : Form
    {
        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        private void employeeName_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(telephone.Text);
            string s;
            sb.Replace(' ', '-');
            s = sb.ToString();
            ok.Enabled = employeeName.TextLength > 0 && position.TextLength > 0 && address.TextLength > 0 && !s.Contains(" ") && s.Length == 19 && salary.TextLength > 0;
        }

        private void position_TextChanged(object sender, EventArgs e)
        {
            employeeName_TextChanged(sender, e);
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            employeeName_TextChanged(sender, e);
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            employeeName_TextChanged(sender, e);
        }

        private void salary_TextChanged(object sender, EventArgs e)
        {
            employeeName_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(Salary) > 0)
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

        public string Birthdate
        {
            get { return birthdate.Text; }
            set { birthdate.Text = value; }
        }

        public string Position
        {
            get { return position.Text; }
            set { position.Text = value; }
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

        public string Salary
        {
            get { return salary.Text; }
            set { salary.Text = value; }
        }
    }
}
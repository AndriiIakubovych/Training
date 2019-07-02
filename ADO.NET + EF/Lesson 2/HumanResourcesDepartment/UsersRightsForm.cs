using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class UsersRightsForm : Form
    {
        public UsersRightsForm()
        {
            InitializeComponent();
        }

        private void UsersRightsForm_Load(object sender, EventArgs e)
        {
            userChoice.SelectedIndex = 0;
        }

        private void userChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userChoice.SelectedIndex == 0)
            {
                passwordText.Enabled = password.Enabled = true;
                if (password.Text.Length > 0)
                    ok.Enabled = true;
                else
                    ok.Enabled = false;
            }
            else
            {
                passwordText.Enabled = password.Enabled = false;
                password.Clear();
                ok.Enabled = true;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text.Length > 0)
                ok.Enabled = true;
            else
                ok.Enabled = false;
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            if ((userChoice.SelectedIndex == 0 && password.Text == "Admin") || userChoice.SelectedIndex == 1)
                ok.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Неверный пароль!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public int UserType
        {
            get { return userChoice.SelectedIndex; }
        }
    }
}
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UsersAccounting
{
    public partial class AddUserForm : Form
    {
        private SqlConnection connection;

        public AddUserForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void userLogin_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = userLogin.Text.Length > 0 && userPassword.Text.Length > 0;
            checkUser.Enabled = userLogin.Text.Length > 0;
        }

        private void checkUser_Click(object sender, EventArgs e)
        {
            bool freeLogin = true;
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = "SELECT User_login FROM Users WHERE User_login = '" + userLogin.Text + "'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    if (reader.GetString(reader.GetOrdinal("User_login")) == userLogin.Text)
                    {
                        freeLogin = false;
                        break;
                    }
                reader.Close();
                if (freeLogin)
                    MessageBox.Show("Логин с таким именем свободен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Логин с таким именем занят!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка доступа к данным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userPassword_TextChanged(object sender, EventArgs e)
        {
            userLogin_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            bool freeLogin = true;
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = "SELECT User_login FROM Users WHERE User_login = '" + userLogin.Text + "'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    if (reader.GetString(reader.GetOrdinal("User_login")) == userLogin.Text)
                    {
                        freeLogin = false;
                        break;
                    }
                reader.Close();
                if (freeLogin)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Логин с таким именем занят!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка доступа к данным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string UserLogin
        {
            get { return userLogin.Text; }
        }

        public string UserPassword
        {
            get { return userPassword.Text; }
        }

        public string Address
        {
            get { return address.Text; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
        }

        public bool HasAdminRights
        {
            get { return hasAdminRights.Checked; }
        }
    }
}
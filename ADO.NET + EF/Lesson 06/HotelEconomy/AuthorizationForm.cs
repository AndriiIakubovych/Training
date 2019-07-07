using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class AuthorizationForm : Form
    {
        private HotelContext context;
        public string UserName { get; set; }
        public bool AdminRights { get; set; }

        public AuthorizationForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void login_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = login.TextLength > 0 && password.TextLength > 0;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            login_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            bool enter = false;
            try
            {
                var userQuery = from userItem in context.Users orderby userItem.UserName select userItem;
                foreach (var userItem in userQuery)
                {
                    if (userItem.UserName == login.Text && userItem.UserPassword == password.Text)
                    {
                        enter = true;
                        UserName = userItem.UserName;
                        AdminRights = userItem.AdminRights;
                        break;
                    }
                }
                if (enter)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Неверный логин или пароль!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
using System;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = userName.TextLength > 0 && userPassword.TextLength > 0;
        }

        private void userPassword_TextChanged(object sender, EventArgs e)
        {
            userName_TextChanged(sender, e);
        }

        public string UserName
        {
            get { return userName.Text; }
            set { userName.Text = value; }
        }

        public string UserPassword
        {
            get { return userPassword.Text; }
            set { userPassword.Text = value; }
        }

        public bool AdminRights
        {
            get { return adminRights.Checked; }
            set { adminRights.Checked = value; }
        }
    }
}
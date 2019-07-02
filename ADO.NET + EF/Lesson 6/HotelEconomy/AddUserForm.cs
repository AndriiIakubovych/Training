using System;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
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
        }

        public string UserPassword
        {
            get { return userPassword.Text; }
        }

        public bool AdminRights
        {
            get { return adminRights.Checked; }
        }
    }
}
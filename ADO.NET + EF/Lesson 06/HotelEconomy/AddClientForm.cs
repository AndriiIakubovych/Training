using System;
using System.Text;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            sexChoice.SelectedIndex = 0;
        }

        private void clientName_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(telephone.Text);
            string s;
            sb.Replace(' ', '-');
            if (sb[1] == '-')
                sb[1] = ' ';
            if (sb[2] == '-')
                sb[2] = ' ';
            s = sb.ToString();
            ok.Enabled = clientName.TextLength > 0 && passportData.TextLength > 0 && address.TextLength > 0 && !s.Contains(" ") && s.Length == 19 && nationality.TextLength > 0;
        }

        private void passportData_TextChanged(object sender, EventArgs e)
        {
            clientName_TextChanged(sender, e);
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            clientName_TextChanged(sender, e);
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            clientName_TextChanged(sender, e);
        }

        private void nationality_TextChanged(object sender, EventArgs e)
        {
            clientName_TextChanged(sender, e);
        }

        public string ClientName
        {
            get { return clientName.Text; }
        }

        public string Sex
        {
            get { return sexChoice.Text; }
        }

        public string Birthdate
        {
            get { return birthdate.Text; }
        }

        public string PassportData
        {
            get { return passportData.Text; }
        }

        public string Address
        {
            get { return address.Text; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
        }

        public string Nationality
        {
            get { return nationality.Text; }
        }
    }
}
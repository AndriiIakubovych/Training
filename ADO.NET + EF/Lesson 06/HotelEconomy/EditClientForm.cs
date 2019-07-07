using System;
using System.Text;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EditClientForm : Form
    {
        public EditClientForm()
        {
            InitializeComponent();
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sexChoice.Items.Count; i++)
                if (sexChoice.Items[i].ToString() == Sex)
                    sexChoice.SelectedIndex = i;
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
            set { clientName.Text = value; }
        }

        public string Sex
        {
            get { return sexChoice.Text; }
            set { sexChoice.Text = value; }
        }

        public string Birthdate
        {
            get { return birthdate.Text; }
            set { birthdate.Text = value; }
        }

        public string PassportData
        {
            get { return passportData.Text; }
            set { passportData.Text = value; }
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

        public string Nationality
        {
            get { return nationality.Text; }
            set { nationality.Text = value; }
        }
    }
}
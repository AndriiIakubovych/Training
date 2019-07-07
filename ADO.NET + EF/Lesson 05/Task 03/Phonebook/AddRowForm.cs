using System;
using System.Text;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class AddRowForm : Form
    {
        public AddRowForm()
        {
            InitializeComponent();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(telephone.Text);
            string s;
            sb.Replace(' ', '-');
            s = sb.ToString();
            ok.Enabled = name.Text.Length > 0 && address.Text.Length > 0 && !s.Contains(" ") && s.Length == 19;
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            name_TextChanged(sender, e);
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            name_TextChanged(sender, e);
        }

        public string NameData
        {
            get { return name.Text; }
        }

        public string Address
        {
            get { return address.Text; }
        }

        public string Telephone
        {
            get { return telephone.Text; }
        }
    }
}
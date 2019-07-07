using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class AddSellerForm : Form
    {
        public AddSellerForm()
        {
            InitializeComponent();
        }

        private void sellerName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = sellerName.Text.Length > 0;
        }

        public string SellerName
        {
            get { return sellerName.Text; }
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
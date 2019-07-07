using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class EditSellerForm : Form
    {
        public EditSellerForm()
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
            set { sellerName.Text = value; }
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
    }
}
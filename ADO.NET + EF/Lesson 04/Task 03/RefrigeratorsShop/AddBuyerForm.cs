using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class AddBuyerForm : Form
    {
        public AddBuyerForm()
        {
            InitializeComponent();
        }

        private void buyerName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = buyerName.Text.Length > 0;
        }

        public string BuyerName
        {
            get { return buyerName.Text; }
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
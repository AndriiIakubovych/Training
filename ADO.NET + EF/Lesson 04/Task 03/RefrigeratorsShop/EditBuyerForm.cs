using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class EditBuyerForm : Form
    {
        public EditBuyerForm()
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
            set { buyerName.Text = value; }
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
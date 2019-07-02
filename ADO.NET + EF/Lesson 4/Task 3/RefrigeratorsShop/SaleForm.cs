using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace RefrigeratorsShop
{
    public partial class SaleForm : Form
    {
        private ShopDataSet ds;
        private List<Product> chosenProductsList;

        public SaleForm(ShopDataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            double totalSum = 0;
            try
            {
                foreach (DataRow r in ds.buyers.Rows)
                    buyerChoice.Items.Add(r["name"]);
                buyerChoice.SelectedIndex = 0;
                foreach (DataRow r in ds.sellers.Rows)
                    sellerChoice.Items.Add(r["name"]);
                sellerChoice.SelectedIndex = 0;
                foreach (Product p in chosenProductsList)
                    totalSum += p.Price * p.Count;
                sum.Text = totalSum.ToString() + " грн.";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printCheck_Click(object sender, EventArgs e)
        {
            CheckForm checkForm = new CheckForm(ds);
            checkForm.Date = saleDate.Value;
            checkForm.BuyerName = buyerChoice.Text;
            checkForm.SellerName = sellerChoice.Text;
            checkForm.ChosenProductsList = chosenProductsList;
            checkForm.ShowDialog();
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                checkFileName.Text = saveFileDialog.FileName;
        }

        public string Date
        {
            get { return saleDate.Text; }
        }

        public string BuyerName
        {
            get { return buyerChoice.Text; }
        }

        public string SellerName
        {
            get { return sellerChoice.Text; }
        }

        public string Sum
        {
            get { return sum.Text; }
        }

        public string CheckFileName
        {
            get { return checkFileName.Text; }
        }

        public List<Product> ChosenProductsList
        {
            get { return chosenProductsList; }
            set { chosenProductsList = value; }
        }
    }
}
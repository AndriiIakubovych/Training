using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace RefrigeratorsShop
{
    public partial class CheckForm : Form
    {
        private ShopDataSet ds;
        private DateTime date;
        private string buyerName;
        private string sellerName;
        private List<Product> chosenProductsList;
        private Check check;

        public CheckForm(ShopDataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            int buyerId = 0, sellerId = 0;
            try
            {
                for (int i = 0; i < ds.buyers.Rows.Count; i++)
                    if (ds.buyers.Rows[i]["name"].ToString() == buyerName)
                    {
                        buyerId = Convert.ToInt32(ds.buyers.Rows[i]["id"]);
                        break;
                    }
                for (int i = 0; i < ds.sellers.Rows.Count; i++)
                    if (ds.sellers.Rows[i]["name"].ToString() == sellerName)
                    {
                        sellerId = Convert.ToInt32(ds.sellers.Rows[i]["id"]);
                        break;
                    }
                for (int i = 0; i < chosenProductsList.Count; i++)
                {
                    DataRow row = ds.sales.NewRow();
                    row["id"] = i + 1;
                    row["date"] = date;
                    row["buyerId"] = buyerId;
                    row["sellerId"] = sellerId;
                    row["productId"] = chosenProductsList[i].Id;
                    row["count"] = chosenProductsList[i].Count;
                    ds.sales.Rows.Add(row);
                }
                check = new Check();
                check.SetDataSource(ds);
                checkViewer.ReportSource = check;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ds.sales.Clear();
            check.Close();
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }

        public string SellerName
        {
            get { return sellerName; }
            set { sellerName = value; }
        }

        public List<Product> ChosenProductsList
        {
            get { return chosenProductsList; }
            set { chosenProductsList = value; }
        }
    }
}
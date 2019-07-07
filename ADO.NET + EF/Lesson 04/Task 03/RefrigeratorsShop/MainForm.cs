using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;

namespace RefrigeratorsShop
{
    public partial class MainForm : Form
    {
        private ShopDataSet ds;
        private List<Product> productsList;
        private List<Product> chosenProductsList;
        private Image noPhoto;

        public MainForm()
        {
            InitializeComponent();
            noPhoto = productPhoto.Image;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new ShopDataSet();
                ds.ReadXml("shop.xml");
                ds.products.DefaultView.Sort = "name";
                ds.sellers.DefaultView.Sort = "name";
                ds.buyers.DefaultView.Sort = "name";
                productsList = new List<Product>();
                chosenProductsList = new List<Product>();
                foreach (DataRow r in ds.products.Rows)
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(r["id"]);
                    product.Name = r["name"].ToString();
                    if (File.Exists("images\\" + r["photo"]))
                    {
                        FileStream fs = new FileStream("images\\" + r["photo"], FileMode.Open, FileAccess.Read);
                        product.Photo = Image.FromStream(fs);
                    }
                    else
                        product.Photo = noPhoto;
                    product.Type = r["type"].ToString();
                    product.Category = r["category"].ToString();
                    product.Control = r["control"].ToString();
                    product.Consumption = r["consumption"].ToString();
                    product.Cameras = Convert.ToInt32(r["cameras"]);
                    product.CArrangement = r["carrangement"].ToString();
                    product.Width = Convert.ToDouble(r["width"]);
                    product.Height = Convert.ToDouble(r["height"]);
                    product.Depth = Convert.ToDouble(r["depth"]);
                    product.RVolume = r["rvolume"].ToString().Length > 0 ? Convert.ToInt32(r["rvolume"]) : 0;
                    product.FVolume = r["fvolume"].ToString().Length > 0 ? Convert.ToInt32(r["fvolume"]) : 0;
                    product.RDefrosting = r["rdefrosting"].ToString();
                    product.FDefrosting = r["fdefrosting"].ToString();
                    product.Power = Convert.ToDouble(r["power"]);
                    product.Noise = Convert.ToDouble(r["noise"]);
                    product.Price = Convert.ToDouble(r["price"]);
                    product.Count = Convert.ToInt32(r["count"]);
                    productsList.Add(product);
                    shopProductsList.Items.Add(product.Name);
                }
                if (shopProductsList.Items.Count > 0)
                    shopProductsList.SelectedIndex = 0;
                else
                    addToList.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm(ds);
            productsForm.ShowDialog();
        }

        private void sellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellersForm sellersForm = new SellersForm(ds);
            sellersForm.ShowDialog();
        }

        private void buyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyersForm buyersForm = new BuyersForm(ds);
            buyersForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripProducts_Click(object sender, EventArgs e)
        {
            productsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripSellers_Click(object sender, EventArgs e)
        {
            sellersToolStripMenuItem_Click(sender, e);
        }

        private void toolStripBuyers_Click(object sender, EventArgs e)
        {
            buyersToolStripMenuItem_Click(sender, e);
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void productsToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel.Text = "Показать таблицу имеющихся товаров в магазине";
        }

        private void productsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Готово";
        }

        private void sellersToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel.Text = "Показать таблицу данных о продавцах магазина";
        }

        private void sellersToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            productsToolStripMenuItem_MouseLeave(sender, e);
        }

        private void buyersToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel.Text = "Показать таблицу данных о зарегистрированных покупателях";
        }

        private void buyersToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            productsToolStripMenuItem_MouseLeave(sender, e);
        }

        private void exitToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel.Text = "Выйти из программы";
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            productsToolStripMenuItem_MouseLeave(sender, e);
        }

        private void toolStripProducts_MouseMove(object sender, MouseEventArgs e)
        {
            productsToolStripMenuItem_MouseMove(sender, e);
        }

        private void toolStripProducts_MouseLeave(object sender, EventArgs e)
        {
            productsToolStripMenuItem_MouseLeave(sender, e);
        }

        private void toolStripSellers_MouseMove(object sender, MouseEventArgs e)
        {
            sellersToolStripMenuItem_MouseMove(sender, e);
        }

        private void toolStripSellers_MouseLeave(object sender, EventArgs e)
        {
            sellersToolStripMenuItem_MouseLeave(sender, e);
        }

        private void toolStripBuyers_MouseMove(object sender, MouseEventArgs e)
        {
            buyersToolStripMenuItem_MouseMove(sender, e);
        }

        private void toolStripBuyers_MouseLeave(object sender, EventArgs e)
        {
            buyersToolStripMenuItem_MouseLeave(sender, e);
        }

        private void toolStripExit_MouseMove(object sender, MouseEventArgs e)
        {
            exitToolStripMenuItem_MouseMove(sender, e);
        }

        private void toolStripExit_MouseLeave(object sender, EventArgs e)
        {
            exitToolStripMenuItem_MouseLeave(sender, e);
        }

        private void shopProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product p in productsList)
                if (p.Name == shopProductsList.SelectedItem.ToString())
                {
                    productName.Text = p.Name;
                    productPhoto.Image = p.Photo;
                    type.Text = p.Type;
                    category.Text = p.Category;
                    control.Text = p.Control;
                    consumption.Text = p.Consumption;
                    cameras.Text = p.Cameras.ToString();
                    carrangement.Text = p.CArrangement;
                    size.Text = p.Width.ToString() + " x " + p.Height.ToString() + " x " + p.Depth.ToString() + " см";
                    rvolume.Text = p.RVolume > 0 ? p.RVolume.ToString() + " л" : "";
                    fvolume.Text = p.FVolume > 0 ? p.FVolume.ToString() + " л" : "";
                    rdefrosting.Text = p.RDefrosting;
                    fdefrosting.Text = p.FDefrosting;
                    power.Text = p.Power.ToString() + " кг/сутки";
                    noise.Text = p.Noise.ToString() + " дБ";
                    price.Text = p.Price.ToString() + " грн.";
                    count.Text = p.Count.ToString();
                    addToList.Enabled = Convert.ToInt32(count.Text) > 0;
                    break;
                }
        }

        private void buyerProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product p in chosenProductsList)
                if (p.Name == buyerProductsList.SelectedItem.ToString())
                {
                    chosenCount.Text = p.Count.ToString();
                    deleteFromList.Enabled = Convert.ToInt32(chosenCount.Text) > 0;
                    break;
                }
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            bool hasElement = false;
            int index = 0, chosenIndex = 0;
            for (int i = 0; i < productsList.Count; i++)
                if (productsList[i].Name == shopProductsList.SelectedItem.ToString())
                {
                    index = i;
                    productsList[i].Count -= 1;
                    count.Text = (Convert.ToInt32(count.Text) - 1).ToString();
                    break;
                }
            for (int i = 0; i < chosenProductsList.Count; i++)
                if (chosenProductsList[i].Name == shopProductsList.SelectedItem.ToString())
                {
                    chosenIndex = i;
                    hasElement = true;
                    break;
                }
            if (hasElement)
            {
                chosenProductsList[chosenIndex].Count += 1;
                chosenCount.Text = chosenProductsList[chosenIndex].Count.ToString();
            }
            else
            {
                Product product = new Product();
                product.Id = productsList[index].Id;
                product.Name = productsList[index].Name;
                product.Price = productsList[index].Price;
                product.Count = 1;
                chosenProductsList.Add(product);
                buyerProductsList.Items.Add(product.Name);
                chosenCount.Text = product.Count.ToString();
            }
            buyerProductsList.SelectedItem = shopProductsList.SelectedItem;
            addToList.Enabled = Convert.ToInt32(count.Text) > 0;
            deleteFromList.Enabled = chosenCountText.Enabled = chosenCount.Enabled = sell.Enabled = buyerProductsList.Items.Count > 0;
        }

        private void deleteFromList_Click(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < productsList.Count; i++)
                if (productsList[i].Name == buyerProductsList.SelectedItem.ToString())
                {
                    productsList[i].Count += 1;
                    count.Text = (Convert.ToInt32(count.Text) + 1).ToString();
                    break;
                }
            shopProductsList.SelectedItem = buyerProductsList.SelectedItem;
            for (int i = 0; i < chosenProductsList.Count; i++)
                if (chosenProductsList[i].Name == buyerProductsList.SelectedItem.ToString())
                {
                    if (chosenProductsList[i].Count > 1)
                    {
                        chosenProductsList[i].Count -= 1;
                        chosenCount.Text = chosenProductsList[i].Count.ToString();
                    }
                    else
                    {
                        chosenProductsList.RemoveAt(i);
                        index = buyerProductsList.SelectedIndex;
                        if (index == 0)
                        {
                            if (buyerProductsList.Items.Count > 1)
                                buyerProductsList.SelectedIndex = 1;
                        }
                        else
                            buyerProductsList.SelectedIndex = index - 1;
                        buyerProductsList.Items.RemoveAt(index);
                        break;
                    }
                    break;
                }
            if (buyerProductsList.Items.Count == 0)
                chosenCount.Clear();
            addToList.Enabled = Convert.ToInt32(count.Text) > 0;
            deleteFromList.Enabled = chosenCountText.Enabled = chosenCount.Enabled = sell.Enabled = buyerProductsList.Items.Count > 0;
        }

        private void update_Click(object sender, EventArgs e)
        {
            ds.Clear();
            productsList.Clear();
            chosenProductsList.Clear();
            shopProductsList.Items.Clear();
            buyerProductsList.Items.Clear();
            chosenCount.Clear();
            deleteFromList.Enabled = chosenCountText.Enabled = chosenCount.Enabled = sell.Enabled = buyerProductsList.Items.Count > 0;
            MainForm_Load(sender, e);
        }

        private void sell_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm(ds);
            saleForm.ChosenProductsList = chosenProductsList;
            if (saleForm.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter writer = new XmlTextWriter(saleForm.CheckFileName, System.Text.Encoding.UTF8);
                try
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("sale");
                    writer.WriteElementString("date", saleForm.Date);
                    writer.WriteElementString("buyerName", saleForm.BuyerName);
                    writer.WriteElementString("sellerName", saleForm.SellerName);
                    writer.WriteStartElement("products");
                    foreach (Product p in chosenProductsList)
                    {
                        DataRow[] rows = ds.products.Select("id = " + p.Id);
                        rows[0]["count"] = Convert.ToInt32(rows[0]["count"]) - p.Count;
                        ds.products.AcceptChanges();
                        ds.WriteXml("shop.xml");
                        writer.WriteStartElement("product");
                        writer.WriteElementString("name", p.Name);
                        writer.WriteElementString("count", p.Count.ToString());
                        writer.WriteElementString("price", p.Price.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteElementString("sum", saleForm.Sum);
                    writer.WriteEndElement();
                    update_Click(sender, e);
                    MessageBox.Show("Продажа успешно произведена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }
    }
}
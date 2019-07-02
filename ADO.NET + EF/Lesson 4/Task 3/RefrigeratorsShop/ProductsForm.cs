using System;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace RefrigeratorsShop
{
    public partial class ProductsForm : Form
    {
        private ShopDataSet ds;

        public ProductsForm(ShopDataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            try
            {
                productsView.DataSource = ds.products;
                productsView.Columns[0].Visible = false;
                productsView.Columns[1].HeaderText = "Название холодильника";
                productsView.Columns[1].Width = 170;
                productsView.Columns[2].HeaderText = "Фото";
                productsView.Columns[2].Width = 195;
                productsView.Columns[3].HeaderText = "Тип холодильника";
                productsView.Columns[3].Width = 175;
                productsView.Columns[4].HeaderText = "Категория";
                productsView.Columns[4].Width = 110;
                productsView.Columns[5].HeaderText = "Тип управления";
                productsView.Columns[5].Width = 130;
                productsView.Columns[6].HeaderText = "Класс энергопотребления";
                productsView.Columns[6].Width = 170;
                productsView.Columns[7].HeaderText = "Количество камер";
                productsView.Columns[7].Width = 125;
                productsView.Columns[8].HeaderText = "Расположение морозильной камеры";
                productsView.Columns[8].Width = 225;
                productsView.Columns[9].HeaderText = "Ширина (см)";
                productsView.Columns[9].Width = 95;
                productsView.Columns[10].HeaderText = "Высота (см)";
                productsView.Columns[10].Width = 95;
                productsView.Columns[11].HeaderText = "Глубина (см)";
                productsView.Columns[11].Width = 95;
                productsView.Columns[12].HeaderText = "Объём холодильной камеры (л)";
                productsView.Columns[12].Width = 195;
                productsView.Columns[13].HeaderText = "Объём морозильной камеры (л)";
                productsView.Columns[13].Width = 195;
                productsView.Columns[14].HeaderText = "Тип размораживания холодильной камеры";
                productsView.Columns[14].Width = 260;
                productsView.Columns[15].HeaderText = "Тип размораживания морозильной камеры";
                productsView.Columns[15].Width = 260;
                productsView.Columns[16].HeaderText = "Мощность замораживания (кг/сутки)";
                productsView.Columns[16].Width = 230;
                productsView.Columns[17].HeaderText = "Уровень шума (дБ)";
                productsView.Columns[17].Width = 135;
                productsView.Columns[18].HeaderText = "Цена (грн.)";
                productsView.Columns[18].Width = 90;
                productsView.Columns[19].HeaderText = "Количество";
                productsView.Columns[19].Width = 90;
                if (productsView.Rows.Count == 0)
                    productsView.RowHeadersVisible = productsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            int maxId = 0;
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.products.Select();
                    foreach (DataRow r in rows)
                        if (Convert.ToInt32(r["id"]) > maxId)
                            maxId = Convert.ToInt32(r["id"]);
                    DataRow row = ds.products.NewRow();
                    row["id"] = maxId + 1;
                    row["name"] = addProductForm.ProductNameData;
                    row["photo"] = Path.GetFileName(addProductForm.PhotoFileName);
                    row["type"] = addProductForm.Type;
                    row["category"] = addProductForm.Category;
                    row["control"] = addProductForm.Control;
                    row["consumption"] = addProductForm.Consumption;
                    row["cameras"] = addProductForm.Cameras;
                    row["carrangement"] = addProductForm.CArrangement;
                    row["width"] = Math.Round(Convert.ToDouble(addProductForm.ProductWidth), 1);
                    row["height"] = Math.Round(Convert.ToDouble(addProductForm.ProductHeight), 1);
                    row["depth"] = Math.Round(Convert.ToDouble(addProductForm.ProductDepth), 1);
                    if (addProductForm.RVolume.Length > 0)
                        row["rvolume"] = Convert.ToInt32(addProductForm.RVolume);
                    else
                        row["rvolume"] = DBNull.Value;
                    if (addProductForm.FVolume.Length > 0)
                        row["fvolume"] = Convert.ToInt32(addProductForm.FVolume);
                    else
                        row["fvolume"] = DBNull.Value;
                    row["rdefrosting"] = addProductForm.RDefrosting;
                    row["fdefrosting"] = addProductForm.FDefrosting;
                    row["power"] = Math.Round(Convert.ToDouble(addProductForm.Power), 1);
                    row["noise"] = Math.Round(Convert.ToDouble(addProductForm.Noise), 1);
                    row["price"] = Math.Round(Convert.ToDouble(addProductForm.Price), 2);
                    row["count"] = addProductForm.Count;
                    ds.products.Rows.Add(row);
                    ds.WriteXml("shop.xml");
                    if (addProductForm.PhotoFileName.Length > 0)
                    {
                        if (!Directory.Exists("images"))
                            Directory.CreateDirectory("images");
                        if (!File.Exists("images\\" + Path.GetFileName(addProductForm.PhotoFileName)))
                            File.Copy(addProductForm.PhotoFileName, "images\\" + Path.GetFileName(addProductForm.PhotoFileName));
                    }
                    if (productsView.Rows.Count > 0)
                        productsView.RowHeadersVisible = productsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < productsView.Rows.Count; i++)
                        if (Convert.ToInt32(productsView.Rows[i].Cells[0].Value) == maxId + 1)
                            productsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditProductForm editProductForm = new EditProductForm();
            editProductForm.ProductNameData = productsView.CurrentRow.Cells[1].Value.ToString();
            editProductForm.Type = productsView.CurrentRow.Cells[3].Value.ToString();
            editProductForm.Category = productsView.CurrentRow.Cells[4].Value.ToString();
            editProductForm.Control = productsView.CurrentRow.Cells[5].Value.ToString();
            editProductForm.Consumption = productsView.CurrentRow.Cells[6].Value.ToString();
            editProductForm.Cameras = productsView.CurrentRow.Cells[7].Value.ToString();
            editProductForm.CArrangement = productsView.CurrentRow.Cells[8].Value.ToString();
            editProductForm.ProductWidth = productsView.CurrentRow.Cells[9].Value.ToString();
            editProductForm.ProductHeight = productsView.CurrentRow.Cells[10].Value.ToString();
            editProductForm.ProductDepth = productsView.CurrentRow.Cells[11].Value.ToString();
            editProductForm.RVolume = productsView.CurrentRow.Cells[12].Value.ToString();
            editProductForm.FVolume = productsView.CurrentRow.Cells[13].Value.ToString();
            editProductForm.RDefrosting = productsView.CurrentRow.Cells[14].Value.ToString();
            editProductForm.FDefrosting = productsView.CurrentRow.Cells[15].Value.ToString();
            editProductForm.Power = productsView.CurrentRow.Cells[16].Value.ToString();
            editProductForm.Noise = productsView.CurrentRow.Cells[17].Value.ToString();
            editProductForm.Price = productsView.CurrentRow.Cells[18].Value.ToString();
            editProductForm.Count = productsView.CurrentRow.Cells[19].Value.ToString();
            if (editProductForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.products.Select("id = " + productsView.CurrentRow.Cells[0].Value);
                    rows[0]["name"] = editProductForm.ProductNameData;
                    if (editProductForm.ChangePhoto)
                        rows[0]["photo"] = Path.GetFileName(editProductForm.PhotoFileName);
                    rows[0]["type"] = editProductForm.Type;
                    rows[0]["category"] = editProductForm.Category;
                    rows[0]["control"] = editProductForm.Control;
                    rows[0]["consumption"] = editProductForm.Consumption;
                    rows[0]["cameras"] = editProductForm.Cameras;
                    rows[0]["carrangement"] = editProductForm.CArrangement;
                    rows[0]["width"] = Math.Round(Convert.ToDouble(editProductForm.ProductWidth), 1);
                    rows[0]["height"] = Math.Round(Convert.ToDouble(editProductForm.ProductHeight), 1);
                    rows[0]["depth"] = Math.Round(Convert.ToDouble(editProductForm.ProductDepth), 1);
                    if (editProductForm.RVolume.Length > 0)
                        rows[0]["rvolume"] = Convert.ToInt32(editProductForm.RVolume);
                    else
                        rows[0]["rvolume"] = DBNull.Value;
                    if (editProductForm.FVolume.Length > 0)
                        rows[0]["fvolume"] = Convert.ToInt32(editProductForm.FVolume);
                    else
                        rows[0]["fvolume"] = DBNull.Value;
                    rows[0]["rdefrosting"] = editProductForm.RDefrosting;
                    rows[0]["fdefrosting"] = editProductForm.FDefrosting;
                    rows[0]["power"] = Math.Round(Convert.ToDouble(editProductForm.Power), 1);
                    rows[0]["noise"] = Math.Round(Convert.ToDouble(editProductForm.Noise), 1);
                    rows[0]["price"] = Math.Round(Convert.ToDouble(editProductForm.Price), 2);
                    rows[0]["count"] = editProductForm.Count;
                    ds.products.AcceptChanges();
                    ds.WriteXml("shop.xml");
                    if (editProductForm.ChangePhoto && editProductForm.PhotoFileName.Length > 0)
                    {
                        if (!Directory.Exists("images"))
                            Directory.CreateDirectory("images");
                        if (!File.Exists(editProductForm.PhotoFileName))
                            File.Copy(editProductForm.PhotoFileName, "images\\" + Path.GetFileName(editProductForm.PhotoFileName));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = productsView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о товаре?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRow[] rows = ds.products.Select("id = " + productsView.CurrentRow.Cells[0].Value.ToString());
                    rows[0].Delete();
                    ds.products.AcceptChanges();
                    ds.WriteXml("shop.xml");
                    if (productsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        productsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        productsView.RowHeadersVisible = productsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
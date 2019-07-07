using System;
using System.Windows.Forms;
using System.Data;

namespace RefrigeratorsShop
{
    public partial class SellersForm : Form
    {
        private ShopDataSet ds;

        public SellersForm(ShopDataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void SellersForm_Load(object sender, EventArgs e)
        {
            try
            {
                sellersView.DataSource = ds.sellers;
                sellersView.Columns[0].Visible = false;
                sellersView.Columns[1].HeaderText = "ФИО продавца";
                sellersView.Columns[1].Width = 190;
                sellersView.Columns[2].HeaderText = "Адрес";
                sellersView.Columns[2].Width = 190;
                sellersView.Columns[3].HeaderText = "Телефон";
                sellersView.Columns[3].Width = 110;
                if (sellersView.Rows.Count == 0)
                    sellersView.RowHeadersVisible = sellersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddSellerForm addSellerForm = new AddSellerForm();
            int maxId = 0;
            if (addSellerForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.sellers.Select();
                    foreach (DataRow r in rows)
                        if (Convert.ToInt32(r["id"]) > maxId)
                            maxId = Convert.ToInt32(r["id"]);
                    DataRow row = ds.sellers.NewRow();
                    row["id"] = maxId + 1;
                    row["name"] = addSellerForm.SellerName;
                    row["address"] = addSellerForm.Address;
                    row["telephone"] = addSellerForm.Telephone;
                    ds.sellers.Rows.Add(row);
                    ds.WriteXml("shop.xml");
                    if (sellersView.Rows.Count > 0)
                        sellersView.RowHeadersVisible = sellersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < sellersView.Rows.Count; i++)
                        if (Convert.ToInt32(sellersView.Rows[i].Cells[0].Value) == maxId + 1)
                            sellersView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditSellerForm editSellerForm = new EditSellerForm();
            editSellerForm.SellerName = sellersView.CurrentRow.Cells[1].Value.ToString();
            editSellerForm.Address = sellersView.CurrentRow.Cells[2].Value.ToString();
            editSellerForm.Telephone = sellersView.CurrentRow.Cells[3].Value.ToString();
            if (editSellerForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.sellers.Select("id = " + sellersView.CurrentRow.Cells[0].Value);
                    rows[0]["name"] = editSellerForm.SellerName;
                    rows[0]["address"] = editSellerForm.Address;
                    rows[0]["telephone"] = editSellerForm.Telephone;
                    ds.sellers.AcceptChanges();
                    ds.WriteXml("shop.xml");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = sellersView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о продавце?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRow[] rows = ds.sellers.Select("id = " + sellersView.CurrentRow.Cells[0].Value);
                    rows[0].Delete();
                    ds.sellers.AcceptChanges();
                    ds.WriteXml("shop.xml");
                    if (sellersView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        sellersView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        sellersView.RowHeadersVisible = sellersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
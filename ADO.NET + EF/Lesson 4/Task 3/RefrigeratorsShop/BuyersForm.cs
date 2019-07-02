using System;
using System.Windows.Forms;
using System.Data;

namespace RefrigeratorsShop
{
    public partial class BuyersForm : Form
    {
        private ShopDataSet ds;

        public BuyersForm(ShopDataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }

        private void BuyersForm_Load(object sender, EventArgs e)
        {
            try
            {
                buyersView.DataSource = ds.buyers;
                buyersView.Columns[0].Visible = false;
                buyersView.Columns[1].HeaderText = "ФИО покупателя";
                buyersView.Columns[1].Width = 190;
                buyersView.Columns[2].HeaderText = "Адрес";
                buyersView.Columns[2].Width = 190;
                buyersView.Columns[3].HeaderText = "Телефон";
                buyersView.Columns[3].Width = 110;
                if (buyersView.Rows.Count == 0)
                    buyersView.RowHeadersVisible = buyersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddBuyerForm addBuyerForm = new AddBuyerForm();
            int maxId = 0;
            if (addBuyerForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.buyers.Select();
                    foreach (DataRow r in rows)
                        if (Convert.ToInt32(r["id"]) > maxId)
                            maxId = Convert.ToInt32(r["id"]);
                    DataRow row = ds.buyers.NewRow();
                    row["id"] = maxId + 1;
                    row["name"] = addBuyerForm.BuyerName;
                    row["address"] = addBuyerForm.Address;
                    row["telephone"] = addBuyerForm.Telephone;
                    ds.buyers.Rows.Add(row);
                    ds.WriteXml("shop.xml");
                    if (buyersView.Rows.Count > 0)
                        buyersView.RowHeadersVisible = buyersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < buyersView.Rows.Count; i++)
                        if (Convert.ToInt32(buyersView.Rows[i].Cells[0].Value) == maxId + 1)
                            buyersView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditBuyerForm editBuyerForm = new EditBuyerForm();
            editBuyerForm.BuyerName = buyersView.CurrentRow.Cells[1].Value.ToString();
            editBuyerForm.Address = buyersView.CurrentRow.Cells[2].Value.ToString();
            editBuyerForm.Telephone = buyersView.CurrentRow.Cells[3].Value.ToString();
            if (editBuyerForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataRow[] rows = ds.buyers.Select("id = " + buyersView.CurrentRow.Cells[0].Value);
                    rows[0]["name"] = editBuyerForm.BuyerName;
                    rows[0]["address"] = editBuyerForm.Address;
                    rows[0]["telephone"] = editBuyerForm.Telephone;
                    ds.buyers.AcceptChanges();
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
            int index = buyersView.CurrentRow.Index;
            if (MessageBox.Show("Вы действительно хотите удалить данные о покупателе?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRow[] rows = ds.buyers.Select("id = " + buyersView.CurrentRow.Cells[0].Value);
                    rows[0].Delete();
                    ds.buyers.AcceptChanges();
                    ds.WriteXml("shop.xml");
                    if (buyersView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        buyersView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        buyersView.RowHeadersVisible = buyersView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
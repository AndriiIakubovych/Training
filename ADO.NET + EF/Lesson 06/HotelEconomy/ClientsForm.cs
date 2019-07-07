using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class ClientsForm : Form
    {
        private HotelContext context;

        public ClientsForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var clientQuery = from clientItem in context.Clients orderby clientItem.ClientName select clientItem;
                var roomNumberQuery = from roomItem in context.Rooms orderby roomItem.RoomNumber select roomItem.RoomNumber;
                clientsView.DataSource = clientQuery.ToList();
                clientsView.Columns[0].Visible = false;
                clientsView.Columns[1].HeaderText = "ФИО клиента";
                clientsView.Columns[1].Width = 190;
                clientsView.Columns[2].HeaderText = "Пол";
                clientsView.Columns[2].Width = 55;
                clientsView.Columns[3].HeaderText = "Дата рождения";
                clientsView.Columns[3].Width = 110;
                clientsView.Columns[4].HeaderText = "Паспортные данные";
                clientsView.Columns[4].Width = 140;
                clientsView.Columns[5].HeaderText = "Домашний адрес";
                clientsView.Columns[5].Width = 320;
                clientsView.Columns[6].HeaderText = "Телефон";
                clientsView.Columns[6].Width = 105;
                clientsView.Columns[7].HeaderText = "Национальность";
                clientsView.Columns[7].Width = 100;
                clientsView.Columns[8].Visible = false;
                if (clientsView.Rows.Count == 0)
                    clientsView.RowHeadersVisible = clientsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                foreach (int r in roomNumberQuery)
                    roomChoice.Items.Add(r);
                if (roomChoice.Items.Count > 0)
                    roomChoice.SelectedIndex = 0;
                else
                    roomSearch.Enabled = roomChoiceText.Enabled = roomChoice.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            int maxId;
            if (addClientForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Client client = new Client();
                    IEnumerable<int> clientIdQuery = from clientItem in context.Clients select clientItem.ClientId;
                    maxId = clientIdQuery.Max();
                    client.ClientId = maxId + 1;
                    client.ClientName = addClientForm.ClientName;
                    client.Sex = addClientForm.Sex;
                    client.Birthdate = Convert.ToDateTime(addClientForm.Birthdate);
                    client.PassportData = addClientForm.PassportData;
                    client.Address = addClientForm.Address;
                    client.Telephone = addClientForm.Telephone;
                    client.Nationality = addClientForm.Nationality;
                    context.Clients.Add(client);
                    context.SaveChanges();
                    var clientQuery = from clientItem in context.Clients orderby clientItem.ClientName select clientItem;
                    clientsView.DataSource = clientQuery.ToList();
                    if (clientsView.Rows.Count > 0)
                        clientsView.RowHeadersVisible = clientsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < clientsView.Rows.Count; i++)
                        if (Convert.ToInt32(clientsView.Rows[i].Cells[0].Value) == maxId + 1)
                            clientsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditClientForm editClientForm = new EditClientForm();
            int id = Convert.ToInt32(clientsView.CurrentRow.Cells[0].Value);
            editClientForm.ClientName = clientsView.CurrentRow.Cells[1].Value.ToString();
            editClientForm.Sex = clientsView.CurrentRow.Cells[2].Value.ToString();
            editClientForm.Birthdate = clientsView.CurrentRow.Cells[3].Value.ToString();
            editClientForm.PassportData = clientsView.CurrentRow.Cells[4].Value.ToString();
            editClientForm.Address = clientsView.CurrentRow.Cells[5].Value.ToString();
            editClientForm.Telephone = clientsView.CurrentRow.Cells[6].Value.ToString();
            editClientForm.Nationality = clientsView.CurrentRow.Cells[7].Value.ToString();
            if (editClientForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Client client = context.Clients.Find(id);
                    client.ClientName = editClientForm.ClientName;
                    client.Sex = editClientForm.Sex;
                    client.Birthdate = Convert.ToDateTime(editClientForm.Birthdate);
                    client.PassportData = editClientForm.PassportData;
                    client.Address = editClientForm.Address;
                    client.Telephone = editClientForm.Telephone;
                    client.Nationality = editClientForm.Nationality;
                    context.SaveChanges();
                    var clientQuery = from clientItem in context.Clients orderby clientItem.ClientName select clientItem;
                    clientsView.DataSource = clientQuery.ToList();
                    for (int i = 0; i < clientsView.Rows.Count; i++)
                        if (Convert.ToInt32(clientsView.Rows[i].Cells[0].Value) == id)
                            clientsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = clientsView.CurrentRow.Index;
            int id = Convert.ToInt32(clientsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о клиенте?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Client client = context.Clients.Find(id);
                    context.Clients.Remove(client);
                    context.SaveChanges();
                    var clientQuery = from clientItem in context.Clients orderby clientItem.ClientName select clientItem;
                    clientsView.DataSource = clientQuery.ToList();
                    if (clientsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        clientsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        clientsView.RowHeadersVisible = clientsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clientNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            clientNameText.Enabled = clientName.Enabled = clientNameSearch.Checked;
        }

        private void roomSearch_CheckedChanged(object sender, EventArgs e)
        {
            roomChoiceText.Enabled = roomChoice.Enabled = roomSearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            IEnumerable<Client> clientQuery = null;
            string name = "";
            int roomNumber = 0;
            try
            {
                if (clientNameSearch.Checked)
                    name = clientName.Text;
                if (roomSearch.Checked)
                {
                    roomNumber = Convert.ToInt32(roomChoice.Text);
                    clientQuery = from clientItem in context.Clients join hiringOutItem in context.RoomsHiringOut on clientItem.ClientId equals hiringOutItem.ClientId where clientItem.ClientName.Contains(name) && hiringOutItem.Room.RoomNumber == roomNumber orderby clientItem.ClientName select clientItem;
                }
                else
                    clientQuery = from clientItem in context.Clients where clientItem.ClientName.Contains(name) orderby clientItem.ClientName select clientItem;
                clientsView.DataSource = clientQuery.Distinct().ToList();
                clientsView.RowHeadersVisible = clientsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = clientsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
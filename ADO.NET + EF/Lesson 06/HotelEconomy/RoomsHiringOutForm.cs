using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class RoomsHiringOutForm : Form
    {
        private HotelContext context;

        public RoomsHiringOutForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void RoomsHiringOutForm_Load(object sender, EventArgs e)
        {
            try
            {
                var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut orderby hiringOutItem.BeginningDate select new { HiringId = hiringOutItem.RoomsHiringOutId, RoomId = hiringOutItem.RoomId, RoomNumber = hiringOutItem.Room.RoomNumber, ClientId = hiringOutItem.ClientId, ClientName = hiringOutItem.Client.ClientName, BeginningDate = hiringOutItem.BeginningDate, DaysCount = hiringOutItem.DaysCount, Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                roomsHiringOutView.DataSource = hiringOutQuery.ToList();
                roomsHiringOutView.Columns[0].Visible = false;
                roomsHiringOutView.Columns[1].Visible = false;
                roomsHiringOutView.Columns[2].HeaderText = "Номер комнаты";
                roomsHiringOutView.Columns[2].Width = 115;
                roomsHiringOutView.Columns[3].Visible = false;
                roomsHiringOutView.Columns[4].HeaderText = "ФИО клиента";
                roomsHiringOutView.Columns[4].Width = 190;
                roomsHiringOutView.Columns[5].HeaderText = "Дата заселения";
                roomsHiringOutView.Columns[5].Width = 115;
                roomsHiringOutView.Columns[6].HeaderText = "Количество дней";
                roomsHiringOutView.Columns[6].Width = 120;
                roomsHiringOutView.Columns[7].HeaderText = "Цена проживания (грн.)";
                roomsHiringOutView.Columns[7].Width = 150;
                if (roomsHiringOutView.Rows.Count == 0)
                    roomsHiringOutView.RowHeadersVisible = roomsHiringOutView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddHiringOutForm addHiringOutForm = new AddHiringOutForm(context);
            int maxId;
            bool occupy = true;
            if (addHiringOutForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (addHiringOutForm.HasClient)
                        occupy = MessageBox.Show("Данный номер уже забронирован на этот период! Желаете всё равно заселить клиента?", "Заселение клиентов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (occupy)
                    {
                        RoomsHiringOut roomsHiringOut = new RoomsHiringOut();
                        IEnumerable<int> hiringOutIdQuery = from hiringOutItem in context.RoomsHiringOut select hiringOutItem.RoomsHiringOutId;
                        maxId = hiringOutIdQuery.Max();
                        roomsHiringOut.RoomsHiringOutId = maxId + 1;
                        roomsHiringOut.RoomId = addHiringOutForm.Room;
                        roomsHiringOut.ClientId = addHiringOutForm.Client;
                        roomsHiringOut.BeginningDate = Convert.ToDateTime(addHiringOutForm.BeginningDate);
                        roomsHiringOut.DaysCount = Convert.ToInt32(addHiringOutForm.DaysCount);
                        context.RoomsHiringOut.Add(roomsHiringOut);
                        context.SaveChanges();
                        var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut orderby hiringOutItem.BeginningDate select new { HiringId = hiringOutItem.RoomsHiringOutId, RoomId = hiringOutItem.RoomId, RoomNumber = hiringOutItem.Room.RoomNumber, ClientId = hiringOutItem.ClientId, ClientName = hiringOutItem.Client.ClientName, BeginningDate = hiringOutItem.BeginningDate, DaysCount = hiringOutItem.DaysCount, Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                        roomsHiringOutView.DataSource = hiringOutQuery.ToList();
                        if (roomsHiringOutView.Rows.Count > 0)
                            roomsHiringOutView.RowHeadersVisible = roomsHiringOutView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                        for (int i = 0; i < roomsHiringOutView.Rows.Count; i++)
                            if (Convert.ToInt32(roomsHiringOutView.Rows[i].Cells[0].Value) == maxId + 1)
                                roomsHiringOutView.Rows[i].Cells[2].Selected = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditHiringOutForm editHiringOutForm = new EditHiringOutForm(context);
            int id = Convert.ToInt32(roomsHiringOutView.CurrentRow.Cells[0].Value);
            bool occupy = true;
            editHiringOutForm.Room = Convert.ToInt32(roomsHiringOutView.CurrentRow.Cells[1].Value);
            editHiringOutForm.Client = Convert.ToInt32(roomsHiringOutView.CurrentRow.Cells[3].Value);
            editHiringOutForm.BeginningDate = roomsHiringOutView.CurrentRow.Cells[5].Value.ToString();
            editHiringOutForm.DaysCount = roomsHiringOutView.CurrentRow.Cells[6].Value.ToString();
            if (editHiringOutForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (editHiringOutForm.HasClient)
                        occupy = MessageBox.Show("Данный номер уже забронирован на этот период! Желаете заселить ещё одного клиента?", "Заселение клиентов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (occupy)
                    {
                        RoomsHiringOut roomsHiringOut = context.RoomsHiringOut.Find(id);
                        roomsHiringOut.RoomId = editHiringOutForm.Room;
                        roomsHiringOut.ClientId = editHiringOutForm.Client;
                        roomsHiringOut.BeginningDate = Convert.ToDateTime(editHiringOutForm.BeginningDate);
                        roomsHiringOut.DaysCount = Convert.ToInt32(editHiringOutForm.DaysCount);
                        context.SaveChanges();
                        var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut orderby hiringOutItem.BeginningDate select new { HiringId = hiringOutItem.RoomsHiringOutId, RoomId = hiringOutItem.RoomId, RoomNumber = hiringOutItem.Room.RoomNumber, ClientId = hiringOutItem.ClientId, ClientName = hiringOutItem.Client.ClientName, BeginningDate = hiringOutItem.BeginningDate, DaysCount = hiringOutItem.DaysCount, Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                        roomsHiringOutView.DataSource = hiringOutQuery.ToList();
                        for (int i = 0; i < roomsHiringOutView.Rows.Count; i++)
                            if (Convert.ToInt32(roomsHiringOutView.Rows[i].Cells[0].Value) == id)
                                roomsHiringOutView.Rows[i].Cells[2].Selected = true;
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
            int index = roomsHiringOutView.CurrentRow.Index;
            int id = Convert.ToInt32(roomsHiringOutView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о заселении?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    RoomsHiringOut roomsHiringOut = context.RoomsHiringOut.Find(id);
                    context.RoomsHiringOut.Remove(roomsHiringOut);
                    context.SaveChanges();
                    var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut orderby hiringOutItem.BeginningDate select new { HiringId = hiringOutItem.RoomsHiringOutId, RoomId = hiringOutItem.RoomId, RoomNumber = hiringOutItem.Room.RoomNumber, ClientId = hiringOutItem.ClientId, ClientName = hiringOutItem.Client.ClientName, BeginningDate = hiringOutItem.BeginningDate, DaysCount = hiringOutItem.DaysCount, Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                    roomsHiringOutView.DataSource = hiringOutQuery.ToList();
                    if (roomsHiringOutView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        roomsHiringOutView.Rows[index].Cells[2].Selected = true;
                    }
                    else
                        roomsHiringOutView.RowHeadersVisible = roomsHiringOutView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void periodSearch_CheckedChanged(object sender, EventArgs e)
        {
            periodText.Enabled = beginningDate.Enabled = separator.Enabled = endDate.Enabled = periodSearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut where hiringOutItem.BeginningDate >= (periodSearch.Checked ? beginningDate.Value.Date : hiringOutItem.BeginningDate) && hiringOutItem.BeginningDate <= (periodSearch.Checked ? endDate.Value.Date : hiringOutItem.BeginningDate) orderby hiringOutItem.BeginningDate select new { HiringId = hiringOutItem.RoomsHiringOutId, RoomId = hiringOutItem.RoomId, RoomNumber = hiringOutItem.Room.RoomNumber, ClientId = hiringOutItem.ClientId, ClientName = hiringOutItem.Client.ClientName, BeginningDate = hiringOutItem.BeginningDate, DaysCount = hiringOutItem.DaysCount, Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                roomsHiringOutView.DataSource = hiringOutQuery.ToList();
                roomsHiringOutView.RowHeadersVisible = roomsHiringOutView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = roomsHiringOutView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
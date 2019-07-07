using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class RoomsForm : Form
    {
        private HotelContext context;

        public RoomsForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var roomQuery = from roomItem in context.Rooms orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = roomItem.EmployeeId, EmployeeName = roomItem.Employee.EmployeeName };
                roomsView.DataSource = roomQuery.ToList();
                roomsView.Columns[0].Visible = false;
                roomsView.Columns[1].HeaderText = "Номер комнаты";
                roomsView.Columns[1].Width = 115;
                roomsView.Columns[2].HeaderText = "Этаж";
                roomsView.Columns[2].Width = 40;
                roomsView.Columns[3].HeaderText = "Категория";
                roomsView.Columns[3].Width = 70;
                roomsView.Columns[4].HeaderText = "Количество мест";
                roomsView.Columns[4].Width = 120;
                roomsView.Columns[5].HeaderText = "Цена (грн./сутки)";
                roomsView.Columns[5].Width = 120;
                roomsView.Columns[6].Visible = false;
                roomsView.Columns[7].HeaderText = "Ответственное лицо";
                roomsView.Columns[7].Width = 190;
                if (roomsView.Rows.Count == 0)
                    roomsView.RowHeadersVisible = roomsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                categoryChoice.SelectedIndex = placesCountChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoomForm = new AddRoomForm(context);
            int maxId;
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Room room = new Room();
                    IEnumerable<int> roomIdQuery = from roomItem in context.Rooms select roomItem.RoomId;
                    maxId = roomIdQuery.Max();
                    room.RoomId = maxId + 1;
                    room.RoomNumber = Convert.ToInt32(addRoomForm.RoomNumber);
                    room.Floor = Convert.ToInt32(addRoomForm.Floor);
                    room.Category = addRoomForm.Category;
                    room.PlacesCount = Convert.ToInt32(addRoomForm.PlacesCount);
                    room.Price = Math.Round(Convert.ToDouble(addRoomForm.Price), 2);
                    room.EmployeeId = addRoomForm.Employee;
                    context.Rooms.Add(room);
                    context.SaveChanges();
                    var roomQuery = from roomItem in context.Rooms orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = roomItem.EmployeeId, EmployeeName = roomItem.Employee.EmployeeName };
                    roomsView.DataSource = roomQuery.ToList();
                    if (roomsView.Rows.Count > 0)
                        roomsView.RowHeadersVisible = roomsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < roomsView.Rows.Count; i++)
                        if (Convert.ToInt32(roomsView.Rows[i].Cells[0].Value) == maxId + 1)
                            roomsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditRoomForm editRoomForm = new EditRoomForm(context);
            int id = Convert.ToInt32(roomsView.CurrentRow.Cells[0].Value);
            editRoomForm.RoomNumber = roomsView.CurrentRow.Cells[1].Value.ToString();
            editRoomForm.Floor = roomsView.CurrentRow.Cells[2].Value.ToString();
            editRoomForm.Category = roomsView.CurrentRow.Cells[3].Value.ToString();
            editRoomForm.PlacesCount = roomsView.CurrentRow.Cells[4].Value.ToString();
            editRoomForm.Price = roomsView.CurrentRow.Cells[5].Value.ToString();
            editRoomForm.Employee = Convert.ToInt32(roomsView.CurrentRow.Cells[6].Value);
            if (editRoomForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Room room = context.Rooms.Find(id);
                    room.RoomNumber = Convert.ToInt32(editRoomForm.RoomNumber);
                    room.Floor = Convert.ToInt32(editRoomForm.Floor);
                    room.Category = editRoomForm.Category;
                    room.PlacesCount = Convert.ToInt32(editRoomForm.PlacesCount);
                    room.Price = Math.Round(Convert.ToDouble(editRoomForm.Price), 2);
                    room.EmployeeId = editRoomForm.Employee;
                    context.SaveChanges();
                    var roomQuery = from roomItem in context.Rooms orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = roomItem.EmployeeId, EmployeeName = roomItem.Employee.EmployeeName };
                    roomsView.DataSource = roomQuery.ToList();
                    for (int i = 0; i < roomsView.Rows.Count; i++)
                        if (Convert.ToInt32(roomsView.Rows[i].Cells[0].Value) == id)
                            roomsView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = roomsView.CurrentRow.Index;
            int id = Convert.ToInt32(roomsView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о номере?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Room room = context.Rooms.Find(id);
                    context.Rooms.Remove(room);
                    context.SaveChanges();
                    var roomQuery = from roomItem in context.Rooms join employeeItem in context.Employees on roomItem.EmployeeId equals employeeItem.EmployeeId orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = employeeItem.EmployeeId, EmployeeName = employeeItem.EmployeeName };
                    roomsView.DataSource = roomQuery.ToList();
                    if (roomsView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        roomsView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        roomsView.RowHeadersVisible = roomsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void categorySearch_CheckedChanged(object sender, EventArgs e)
        {
            categoryChoiceText.Enabled = categoryChoice.Enabled = categorySearch.Checked;
        }

        private void placesCountSearch_CheckedChanged(object sender, EventArgs e)
        {
            placesCountChoiceText.Enabled = placesCountChoice.Enabled = placesCountSearch.Checked;
        }

        private void priceSearch_CheckedChanged(object sender, EventArgs e)
        {
            priceText.Enabled = firstPrice.Enabled = firstSeparator.Enabled = secondPrice.Enabled = priceSearch.Checked;
        }

        private void freeSearch_CheckedChanged(object sender, EventArgs e)
        {
            freeDateText.Enabled = beginningDate.Enabled = secondSeparator.Enabled = endDate.Enabled = freeSearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            int placesCount = 0;
            double fPrice = 0, sPrice = 0;
            DateTime sEndDate;
            List<int> roomsList = new List<int>();
            try
            {
                placesCount = Convert.ToInt32(placesCountChoice.Text);
                fPrice = Convert.ToDouble(firstPrice.Text);
                sPrice = Convert.ToDouble(secondPrice.Text);
                if (freeSearch.Checked)
                {
                    if (beginningDate.Value.Date > endDate.Value.Date)
                        throw new Exception();
                    var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut select hiringOutItem;
                    foreach (var hiringOutItem in hiringOutQuery)
                    {
                        sEndDate = hiringOutItem.BeginningDate.AddDays(hiringOutItem.DaysCount);
                        if (!(endDate.Value.Date < hiringOutItem.BeginningDate || beginningDate.Value.Date > sEndDate))
                            roomsList.Add(hiringOutItem.RoomId);
                    }
                    var roomQuery = from roomItem in context.Rooms where roomItem.Category == (categorySearch.Checked ? categoryChoice.Text : roomItem.Category) && roomItem.PlacesCount == (placesCountSearch.Checked ? placesCount : roomItem.PlacesCount) && roomItem.Price >= (priceSearch.Checked ? fPrice : roomItem.Price) && roomItem.Price <= (priceSearch.Checked ? sPrice : roomItem.Price) && !roomsList.Contains(roomItem.RoomId) orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = roomItem.EmployeeId, EmployeeName = roomItem.Employee.EmployeeName };
                    roomsView.DataSource = roomQuery.ToList();
                }
                else
                {
                    var roomQuery = from roomItem in context.Rooms where roomItem.Category == (categorySearch.Checked ? categoryChoice.Text : roomItem.Category) && roomItem.PlacesCount == (placesCountSearch.Checked ? placesCount : roomItem.PlacesCount) && roomItem.Price >= (priceSearch.Checked ? fPrice : roomItem.Price) && roomItem.Price <= (priceSearch.Checked ? sPrice : roomItem.Price) orderby roomItem.RoomNumber select new { RoomId = roomItem.RoomId, RoomNumber = roomItem.RoomNumber, Floor = roomItem.Floor, Category = roomItem.Category, PlacesCount = roomItem.PlacesCount, Price = roomItem.Price, EmployeeId = roomItem.EmployeeId, EmployeeName = roomItem.Employee.EmployeeName };
                    roomsView.DataSource = roomQuery.ToList();
                }
                roomsView.RowHeadersVisible = roomsView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = roomsView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class AddRoomForm : Form
    {
        private HotelContext context;
        private Dictionary<int, string> employeesList;
        private int employeeId;

        public AddRoomForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
            employeesList = new Dictionary<int, string>();
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            try
            {
                var employeeQuery = from employeeItem in context.Employees where employeeItem.Position == "Дежурный" orderby employeeItem.EmployeeName select employeeItem;
                categoryChoice.SelectedIndex = placesCountChoice.SelectedIndex = 0;
                foreach (var employeeItem in employeeQuery)
                {
                    employeesList.Add(employeeItem.EmployeeId, employeeItem.EmployeeName);
                    employeeChoice.Items.Add(employeeItem.EmployeeName);
                }
                if (employeeChoice.Items.Count > 0)
                    employeeChoice.SelectedIndex = 0;
                else
                    employeeChoiceText.Enabled = employeeChoice.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roomNumber_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = roomNumber.TextLength > 0 && floor.TextLength > 0 && price.TextLength > 0 && employeeChoice.Items.Count > 0;
        }

        private void floor_TextChanged(object sender, EventArgs e)
        {
            roomNumber_TextChanged(sender, e);
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            roomNumber_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(roomNumber.Text) > 0 && Convert.ToInt32(floor.Text) > 0 && Convert.ToDouble(price.Text) > 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string RoomNumber
        {
            get { return roomNumber.Text; }
        }

        public string Floor
        {
            get { return floor.Text; }
        }

        public string Category
        {
            get { return categoryChoice.Text; }
        }

        public string PlacesCount
        {
            get { return placesCountChoice.Text; }
        }

        public string Price
        {
            get { return price.Text; }
        }

        public int Employee
        {
            get
            {
                foreach (KeyValuePair<int, string> e in employeesList)
                    if (e.Value == employeeChoice.Text)
                    {
                        employeeId = e.Key;
                        break;
                    }
                return employeeId;
            }
        }
    }
}
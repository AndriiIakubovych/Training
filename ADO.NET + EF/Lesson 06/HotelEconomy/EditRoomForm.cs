using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EditRoomForm : Form
    {
        private HotelContext context;
        private Dictionary<int, string> employeesList;
        private int employeeId;

        public EditRoomForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
            employeesList = new Dictionary<int, string>();
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            int j = 0;
            var employeeQuery = from employeeItem in context.Employees where employeeItem.Position == "Дежурный" orderby employeeItem.EmployeeName select employeeItem;
            foreach (var employeeItem in employeeQuery)
            {
                employeesList.Add(employeeItem.EmployeeId, employeeItem.EmployeeName);
                employeeChoice.Items.Add(employeeItem.EmployeeName);
            }
            for (int i = 0; i < categoryChoice.Items.Count; i++)
                if (categoryChoice.Items[i].ToString() == Category)
                    categoryChoice.SelectedIndex = i;
            if (employeeChoice.Items.Count > 0)
            {
                employeeChoice.SelectedIndex = 0;
                foreach (KeyValuePair<int, string> el in employeesList)
                {
                    if (el.Key == employeeId)
                    {
                        employeeChoice.SelectedIndex = j;
                        break;
                    }
                    j++;
                }
            }
            else
                employeeChoiceText.Enabled = employeeChoice.Enabled = ok.Enabled = false;
        }

        private void roomNumber_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = roomNumber.TextLength > 0 && floor.TextLength > 0 && price.TextLength > 0;
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
            set { roomNumber.Text = value; }
        }

        public string Floor
        {
            get { return floor.Text; }
            set { floor.Text = value; }
        }

        public string Category
        {
            get { return categoryChoice.Text; }
            set { categoryChoice.Text = value; }
        }

        public string PlacesCount
        {
            get { return placecCountChoice.Text; }
            set { placecCountChoice.Text = value; }
        }

        public string Price
        {
            get { return price.Text; }
            set { price.Text = value; }
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
            set { employeeId = value; }
        }
    }
}
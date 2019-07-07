using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EditHiringOutForm : Form
    {
        private HotelContext context;
        private Dictionary<int, int> roomsList;
        private Dictionary<int, string> clientsList;
        private int roomId;
        private int clientId;
        private bool hasClient;

        public EditHiringOutForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
            roomsList = new Dictionary<int, int>();
            clientsList = new Dictionary<int, string>();
        }

        private void EditHiringOutForm_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                var roomQuery = from roomItem in context.Rooms orderby roomItem.RoomNumber select roomItem;
                var clientQuery = from clientItem in context.Clients orderby clientItem.ClientName select clientItem;
                foreach (var roomItem in roomQuery)
                {
                    roomsList.Add(roomItem.RoomId, roomItem.RoomNumber);
                    roomChoice.Items.Add(roomItem.RoomNumber);
                }
                if (roomChoice.Items.Count > 0)
                {
                    roomChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, int> r in roomsList)
                    {
                        if (r.Key == roomId)
                        {
                            roomChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    roomChoiceText.Enabled = roomChoice.Enabled = ok.Enabled = false;
                i = 0;
                foreach (var clientItem in clientQuery)
                {
                    clientsList.Add(clientItem.ClientId, clientItem.ClientName);
                    clientChoice.Items.Add(clientItem.ClientName);
                }
                if (clientChoice.Items.Count > 0)
                {
                    clientChoice.SelectedIndex = 0;
                    foreach (KeyValuePair<int, string> c in clientsList)
                    {
                        if (c.Key == clientId)
                        {
                            clientChoice.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else
                    clientChoiceText.Enabled = clientChoice.Enabled = ok.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void daysCount_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = daysCount.TextLength > 0;
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            DateTime endDate, sEndDate;
            int roomNumber;
            hasClient = false;
            try
            {
                endDate = beginningDate.Value.AddDays(Convert.ToInt32(daysCount.Text));
                roomNumber = Convert.ToInt32(roomChoice.Text);
                var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut where hiringOutItem.Room.RoomNumber == roomNumber select hiringOutItem;
                foreach (var hiringOutItem in hiringOutQuery)
                {
                    sEndDate = hiringOutItem.BeginningDate.AddDays(hiringOutItem.DaysCount);
                    if (!(endDate < hiringOutItem.BeginningDate || beginningDate.Value.Date > sEndDate))
                    {
                        hasClient = true;
                        break;
                    }
                }
                if (Convert.ToInt32(daysCount.Text) > 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Room
        {
            get
            {
                foreach (KeyValuePair<int, int> r in roomsList)
                    if (r.Value.ToString() == roomChoice.Text)
                    {
                        roomId = r.Key;
                        break;
                    }
                return roomId;
            }
            set { roomId = value; }
        }

        public int Client
        {
            get
            {
                foreach (KeyValuePair<int, string> c in clientsList)
                    if (c.Value == clientChoice.Text)
                    {
                        clientId = c.Key;
                        break;
                    }
                return clientId;
            }
            set { clientId = value; }
        }

        public string BeginningDate
        {
            get { return beginningDate.Text; }
            set { beginningDate.Text = value; }
        }

        public string DaysCount
        {
            get { return daysCount.Text; }
            set { daysCount.Text = value; }
        }

        public bool HasClient
        {
            get { return hasClient; }
        }
    }
}
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class MainForm : Form
    {
        private HotelContext context;
        public string UserName { get; set; }
        public bool AdminRights { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            context = new HotelContext();
            AuthorizationForm authorizationForm = new AuthorizationForm(context);
            try
            {
                if (authorizationForm.ShowDialog() == DialogResult.OK)
                {
                    var roomQuery = from roomItem in context.Rooms select roomItem;
                    var employeesQuery = from employeeItem in context.Employees select employeeItem;
                    roomsCount.Text = roomQuery.Count().ToString();
                    employeesCount.Text = employeesQuery.Count().ToString();
                    UserName = authorizationForm.UserName;
                    AdminRights = authorizationForm.AdminRights;
                    toolStripStatusLabel.Text = "Текущий пользователь: " + UserName;
                    usersDataToolStripMenuItem.Enabled = AdminRights;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void usersDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm(context);
            usersForm.ShowDialog();
        }

        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            AuthorizationForm authorizationForm = new AuthorizationForm(context);
            if (authorizationForm.ShowDialog() == DialogResult.OK)
            {
                Visible = true;
                UserName = authorizationForm.UserName;
                AdminRights = authorizationForm.AdminRights;
                toolStripStatusLabel.Text = "Текущий пользователь: " + UserName;
                usersDataToolStripMenuItem.Enabled = AdminRights;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm(context);
            clientsForm.ShowDialog();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomsForm roomsForm = new RoomsForm(context);
            roomsForm.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(context);
            employeesForm.ShowDialog();
        }

        private void roomsHiringOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomsHiringOutForm roomsHiringOutForm = new RoomsHiringOutForm(context);
            roomsHiringOutForm.ShowDialog();
        }

        private void expensesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensesForm expensesForm = new ExpensesForm(context);
            expensesForm.ShowDialog();
        }

        private void toolStripClients_Click(object sender, EventArgs e)
        {
            clientsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripRooms_Click(object sender, EventArgs e)
        {
            roomsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripEmployees_Click(object sender, EventArgs e)
        {
            employeesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripRoomsHiringOut_Click(object sender, EventArgs e)
        {
            roomsHiringOutToolStripMenuItem_Click(sender, e);
        }

        private void toolStripExpenses_Click(object sender, EventArgs e)
        {
            expensesDataToolStripMenuItem_Click(sender, e);
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }

        private void clientsCountShow_Click(object sender, EventArgs e)
        {
            try
            {
                var hiringOutQuery = from hiringOutItem in context.RoomsHiringOut where hiringOutItem.BeginningDate >= clientsBeginningDate.Value.Date && hiringOutItem.BeginningDate <= clientsEndDate.Value.Date select hiringOutItem;
                clientsCount.Text = hiringOutQuery.Count().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                var roomQuery = from roomItem in context.Rooms select roomItem;
                var employeesQuery = from employeeItem in context.Employees select employeeItem;
                roomsCount.Text = roomQuery.Count().ToString();
                employeesCount.Text = employeesQuery.Count().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void incomesCalculate_Click(object sender, EventArgs e)
        {
            double sum = 0;
            try
            {
                var hiringOutSumQuery = from hiringOutItem in context.RoomsHiringOut where hiringOutItem.BeginningDate >= incomesBeginningDate.Value.Date && hiringOutItem.BeginningDate <= incomesEndDate.Value.Date select new { Sum = hiringOutItem.Room.Price * hiringOutItem.DaysCount };
                foreach (var hiringOutItem in hiringOutSumQuery)
                    sum += hiringOutItem.Sum;
                incomes.Text = sum.ToString() + " грн.";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void expensesCalculate_Click(object sender, EventArgs e)
        {
            double sum = 0;
            try
            {
                var expenseQuery = from expenseItem in context.Expenses where expenseItem.ExpenseDate >= expensesBeginningDate.Value.Date && expenseItem.ExpenseDate <= expensesEndDate.Value.Date select expenseItem;
                foreach (var expenseItem in expenseQuery)
                    sum += expenseItem.ExpenseSum;
                expenses.Text = sum.ToString() + " грн.";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkingDays
{
    public partial class MainForm : Form
    {
        private WorkDB db;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            db = new WorkDB("Data Source = .\\SQLEXPRESS; Initial Catalog = Work; Integrated Security = True");
        }

        private void show_Click(object sender, EventArgs e)
        {
            bool empty = true;
            DateTime date;
            TreeNode node = null;
            try
            {
                var scheduleQuery = from scheduleItem in db.schedule where scheduleItem.EmployeeName.Contains(employeeLastName.Text + " ") orderby scheduleItem.EmployeeName select scheduleItem;
                employeesView.Nodes.Clear();
                foreach (var scheduleItem in scheduleQuery)
                {
                    IEnumerable<int> workingWeekdayQuery = from workingWeekdayItem in db.workingWeek where workingWeekdayItem.ScheduleId == scheduleItem.ScheduleId select workingWeekdayItem.WeekdayNumber;
                    if (workingWeekdayQuery.Count() > 0)
                    {
                        empty = false;
                        node = new TreeNode(scheduleItem.EmployeeName);
                        employeesView.Nodes.Add(node);
                    }
                    date = scheduleItem.WorkingPeriodBeginning;
                    while (date <= scheduleItem.WorkingPeriodEnd)
                    {
                        if (workingWeekdayQuery.Contains(Convert.ToInt32(date.DayOfWeek)))
                            node.Nodes.Add(date.ToShortDateString());
                        date = date.AddDays(1);
                    }
                }
                if (empty)
                    MessageBox.Show("Сотрудники не найдены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.schedule = null;
            db.workingWeek = null;
            db.Dispose();
        }
    }
}
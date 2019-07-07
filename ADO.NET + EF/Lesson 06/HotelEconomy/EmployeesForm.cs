using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class EmployeesForm : Form
    {
        private HotelContext context;

        public EmployeesForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var employeeQuery = from employeeItem in context.Employees orderby employeeItem.EmployeeName select employeeItem;
                var employeePositionQuery = from employeeItem in context.Employees select employeeItem.Position;
                employeesView.DataSource = employeeQuery.ToList();
                employeesView.Columns[0].Visible = false;
                employeesView.Columns[1].HeaderText = "ФИО работника";
                employeesView.Columns[1].Width = 190;
                employeesView.Columns[2].HeaderText = "Дата рождения";
                employeesView.Columns[2].Width = 110;
                employeesView.Columns[3].HeaderText = "Должность";
                employeesView.Columns[3].Width = 150;
                employeesView.Columns[4].HeaderText = "Домашний адрес";
                employeesView.Columns[4].Width = 210;
                employeesView.Columns[5].HeaderText = "Телефон";
                employeesView.Columns[5].Width = 105;
                employeesView.Columns[6].HeaderText = "Зарплата (грн.)";
                employeesView.Columns[6].Width = 110;
                employeesView.Columns[7].Visible = false;
                if (employeesView.Rows.Count == 0)
                    employeesView.RowHeadersVisible = employeesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                foreach (var p in employeePositionQuery.Distinct())
                    positionChoice.Items.Add(p);
                if (positionChoice.Items.Count > 0)
                    positionChoice.SelectedIndex = 0;
                else
                    positionSearch.Enabled = positionChoiceText.Enabled = positionChoice.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            int maxId;
            if (addEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Employee employee = new Employee();
                    IEnumerable<int> employeeIdQuery = from employeeItem in context.Employees select employeeItem.EmployeeId;
                    maxId = employeeIdQuery.Max();
                    employee.EmployeeId = maxId + 1;
                    employee.EmployeeName = addEmployeeForm.EmployeeName;
                    employee.Birthdate = Convert.ToDateTime(addEmployeeForm.Birthdate);
                    employee.Position = addEmployeeForm.Position;
                    employee.Address = addEmployeeForm.Address;
                    employee.Telephone = addEmployeeForm.Telephone;
                    employee.Salary = Math.Round(Convert.ToDouble(addEmployeeForm.Salary), 2);
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    var employeeQuery = from employeeItem in context.Employees orderby employeeItem.EmployeeName select employeeItem;
                    var employeePositionQuery = from employeeItem in context.Employees select employeeItem.Position;
                    employeesView.DataSource = employeeQuery.ToList();
                    if (employeesView.Rows.Count > 0)
                        employeesView.RowHeadersVisible = employeesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < employeesView.Rows.Count; i++)
                        if (Convert.ToInt32(employeesView.Rows[i].Cells[0].Value) == maxId + 1)
                            employeesView.Rows[i].Cells[1].Selected = true;
                    positionChoice.Items.Clear();
                    foreach (var p in employeePositionQuery.Distinct())
                        positionChoice.Items.Add(p);
                    if (positionChoice.Items.Count > 0)
                        positionChoice.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditEmployeeForm editEmployeeForm = new EditEmployeeForm();
            int id = Convert.ToInt32(employeesView.CurrentRow.Cells[0].Value);
            editEmployeeForm.EmployeeName = employeesView.CurrentRow.Cells[1].Value.ToString();
            editEmployeeForm.Birthdate = employeesView.CurrentRow.Cells[2].Value.ToString();
            editEmployeeForm.Position = employeesView.CurrentRow.Cells[3].Value.ToString();
            editEmployeeForm.Address = employeesView.CurrentRow.Cells[4].Value.ToString();
            editEmployeeForm.Telephone = employeesView.CurrentRow.Cells[5].Value.ToString();
            editEmployeeForm.Salary = employeesView.CurrentRow.Cells[6].Value.ToString();
            if (editEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Employee employee = context.Employees.Find(id);
                    employee.EmployeeName = editEmployeeForm.EmployeeName;
                    employee.Birthdate = Convert.ToDateTime(editEmployeeForm.Birthdate);
                    employee.Position = editEmployeeForm.Position;
                    employee.Address = editEmployeeForm.Address;
                    employee.Telephone = editEmployeeForm.Telephone;
                    employee.Salary = Math.Round(Convert.ToDouble(editEmployeeForm.Salary), 2);
                    context.SaveChanges();
                    var employeeQuery = from employeeItem in context.Employees orderby employeeItem.EmployeeName select employeeItem;
                    var employeePositionQuery = from employeeItem in context.Employees select employeeItem.Position;
                    employeesView.DataSource = employeeQuery.ToList();
                    for (int i = 0; i < employeesView.Rows.Count; i++)
                        if (Convert.ToInt32(employeesView.Rows[i].Cells[0].Value) == id)
                            employeesView.Rows[i].Cells[1].Selected = true;
                    positionChoice.Items.Clear();
                    foreach (var p in employeePositionQuery.Distinct())
                        positionChoice.Items.Add(p);
                    if (positionChoice.Items.Count > 0)
                        positionChoice.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = employeesView.CurrentRow.Index;
            int id = Convert.ToInt32(employeesView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о работнике?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Employee employee = context.Employees.Find(id);
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    var employeeQuery = from employeeItem in context.Employees orderby employeeItem.EmployeeName select employeeItem;
                    employeesView.DataSource = employeeQuery.ToList();
                    if (employeesView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        employeesView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        employeesView.RowHeadersVisible = employeesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void employeeNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            employeeNameText.Enabled = employeeName.Enabled = employeeNameSearch.Checked;
        }

        private void positionSearch_CheckedChanged(object sender, EventArgs e)
        {
            positionChoiceText.Enabled = positionChoice.Enabled = positionSearch.Checked;
        }

        private void search_Click(object sender, EventArgs e)
        {
            IEnumerable<Employee> employeeQuery = null;
            string name = "", position = "";
            try
            {
                if (employeeNameSearch.Checked)
                    name = employeeName.Text;
                if (positionSearch.Checked)
                    position = positionChoice.Text;
                employeeQuery = from employeeItem in context.Employees where employeeItem.EmployeeName.Contains(name) && employeeItem.Position.Contains(position) orderby employeeItem.EmployeeName select employeeItem;
                employeesView.DataSource = employeeQuery.Distinct().ToList();
                employeesView.RowHeadersVisible = employeesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = employeesView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
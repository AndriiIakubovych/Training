using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class ExpensesForm : Form
    {
        private HotelContext context;

        public ExpensesForm(HotelContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var expenseQuery = from expenseItem in context.Expenses orderby expenseItem.ExpenseDate select expenseItem;
                expensesView.DataSource = expenseQuery.ToList();
                expensesView.Columns[0].Visible = false;
                expensesView.Columns[1].HeaderText = "Описание";
                expensesView.Columns[1].Width = 250;
                expensesView.Columns[2].HeaderText = "Дата";
                expensesView.Columns[2].Width = 63;
                expensesView.Columns[3].HeaderText = "Сумма (грн.)";
                expensesView.Columns[3].Width = 100;
                if (expensesView.Rows.Count == 0)
                    expensesView.RowHeadersVisible = expensesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                add.Enabled = edit.Enabled = delete.Enabled = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm();
            int maxId;
            if (addExpenseForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Expense expense = new Expense();
                    IEnumerable<int> expenseIdQuery = from expenseItem in context.Expenses select expenseItem.ExpenseId;
                    maxId = expenseIdQuery.Max();
                    expense.ExpenseId = maxId + 1;
                    expense.ExpenseName = addExpenseForm.ExpenseName;
                    expense.ExpenseDate = Convert.ToDateTime(addExpenseForm.ExpenseDate);
                    expense.ExpenseSum = Convert.ToDouble(addExpenseForm.ExpenseSum);
                    context.Expenses.Add(expense);
                    context.SaveChanges();
                    var expenseQuery = from expenseItem in context.Expenses orderby expenseItem.ExpenseDate select expenseItem;
                    expensesView.DataSource = expenseQuery.ToList();
                    if (expensesView.Rows.Count > 0)
                        expensesView.RowHeadersVisible = expensesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = true;
                    for (int i = 0; i < expensesView.Rows.Count; i++)
                        if (Convert.ToInt32(expensesView.Rows[i].Cells[0].Value) == maxId + 1)
                            expensesView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            EditExpenseForm editExpenseForm = new EditExpenseForm();
            int id = Convert.ToInt32(expensesView.CurrentRow.Cells[0].Value);
            editExpenseForm.ExpenseName = expensesView.CurrentRow.Cells[1].Value.ToString();
            editExpenseForm.ExpenseDate = expensesView.CurrentRow.Cells[2].Value.ToString();
            editExpenseForm.ExpenseSum = expensesView.CurrentRow.Cells[3].Value.ToString();
            if (editExpenseForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Expense expense = context.Expenses.Find(id);
                    expense.ExpenseName = editExpenseForm.ExpenseName;
                    expense.ExpenseDate = Convert.ToDateTime(editExpenseForm.ExpenseDate);
                    expense.ExpenseSum = Convert.ToDouble(editExpenseForm.ExpenseSum);
                    context.SaveChanges();
                    var expenseQuery = from expenseItem in context.Expenses orderby expenseItem.ExpenseDate select expenseItem;
                    expensesView.DataSource = expenseQuery.ToList();
                    expensesView.DataSource = expenseQuery.ToList();
                    for (int i = 0; i < expensesView.Rows.Count; i++)
                        if (Convert.ToInt32(expensesView.Rows[i].Cells[0].Value) == id)
                            expensesView.Rows[i].Cells[1].Selected = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка редактирования данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = expensesView.CurrentRow.Index;
            int id = Convert.ToInt32(expensesView.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить данные о работнике?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Expense expense = context.Expenses.Find(id);
                    context.Expenses.Remove(expense);
                    context.SaveChanges();
                    var expenseQuery = from expenseItem in context.Expenses orderby expenseItem.ExpenseDate select expenseItem;
                    expensesView.DataSource = expenseQuery.ToList();
                    if (expensesView.Rows.Count > 0)
                    {
                        index = index > 0 ? index - 1 : 0;
                        expensesView.Rows[index].Cells[1].Selected = true;
                    }
                    else
                        expensesView.RowHeadersVisible = expensesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = false;
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
                var expenseQuery = from expenseItem in context.Expenses where expenseItem.ExpenseDate >= (periodSearch.Checked ? beginningDate.Value.Date : expenseItem.ExpenseDate) && expenseItem.ExpenseDate <= (periodSearch.Checked ? endDate.Value.Date : expenseItem.ExpenseDate) orderby expenseItem.ExpenseDate select expenseItem;
                expensesView.DataSource = expenseQuery.ToList();
                expensesView.RowHeadersVisible = expensesView.ColumnHeadersVisible = edit.Enabled = delete.Enabled = expensesView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
﻿using System;
using System.Windows.Forms;

namespace HotelEconomy
{
    public partial class AddExpenseForm : Form
    {
        public AddExpenseForm()
        {
            InitializeComponent();
        }

        private void expenseName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = expenseName.TextLength > 0 && expenseSum.TextLength > 0;
        }

        private void expenseSum_TextChanged(object sender, EventArgs e)
        {
            expenseName_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(ExpenseSum) > 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ExpenseName
        {
            get { return expenseName.Text; }
        }

        public string ExpenseDate
        {
            get { return expenseDate.Text; }
        }

        public string ExpenseSum
        {
            get { return expenseSum.Text; }
        }
    }
}
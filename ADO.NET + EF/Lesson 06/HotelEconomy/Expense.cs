using System;

namespace HotelEconomy
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public DateTime ExpenseDate { get; set; }
        public double ExpenseSum { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace HotelEconomy
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
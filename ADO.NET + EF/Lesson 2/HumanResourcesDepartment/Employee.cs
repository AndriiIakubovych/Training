using System;
using System.Drawing;

namespace HumanResourcesDepartment
{
    class Employee
    {
        private int employeeId;
        private string employeeName;
        private DateTime birthdate;
        private string position;
        private int hiringOrderNumber;
        private int firingOrderNumber;
        private Image photo;

        public Employee(int employeeId, string employeeName, DateTime birthdate, string position, int hiringOrderNumber, int firingOrderNumber, Image photo)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.birthdate = birthdate;
            this.position = position;
            this.hiringOrderNumber = hiringOrderNumber;
            this.firingOrderNumber = firingOrderNumber;
            this.photo = photo;
        }

        public int EmployeeId
        {
            get { return employeeId; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public int HiringOrderNumber
        {
            get { return hiringOrderNumber; }
            set { hiringOrderNumber = value; }
        }

        public int FiringOrderNumber
        {
            get { return firingOrderNumber; }
            set { firingOrderNumber = value; }
        }

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }
    }
}
namespace EmployeesSalaryCalculation
{
    public abstract class Employee
    {
        private int id;
        private string name;

        public abstract double GetAverageMonthlySalary();

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
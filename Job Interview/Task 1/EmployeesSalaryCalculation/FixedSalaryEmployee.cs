namespace EmployeesSalaryCalculation
{
    class FixedSalaryEmployee : Employee
    {
        private double monthlySalary;

        public FixedSalaryEmployee(int id, string name, double monthlySalary)
        {
            Id = id;
            Name = name;
            this.monthlySalary = monthlySalary;
        }

        public override double GetAverageMonthlySalary()
        {
            return monthlySalary;
        }

        public double MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }
    }
}
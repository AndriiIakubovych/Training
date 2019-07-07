namespace EmployeesSalaryCalculation
{
    class HourlySalaryEmployee : Employee
    {
        private double hourlySalary;

        public HourlySalaryEmployee(int id, string name, double hourlySalary)
        {
            Id = id;
            Name = name;
            this.hourlySalary = hourlySalary;
        }

        public override double GetAverageMonthlySalary()
        {
            return 20.8 * 8 * hourlySalary;
        }

        public double HourlySalary
        {
            get { return hourlySalary; }
            set { hourlySalary = value; }
        }
    }
}
using System;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CompanyEmployeesOperating
{
    public class Employee : INotifyPropertyChanged, IDataErrorInfo
    {
        private string photoSource;

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get { return LastName + " " + FirstName + " " + MiddleName; } }
        public BitmapImage Photo { get; set; }
        public string PhotoSource { get { return photoSource; } set { photoSource = value; OnPropertyChanged("PhotoSource"); } }
        public DateTime Birthdate { get; set; }
        public int Age { get { int age = DateTime.Now.Year - Birthdate.Year; if (DateTime.Now.Month < Birthdate.Month || (DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day)) age--; return age; } }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string EmploymentContract { get; set; }
        public DateTime HireDate { get; set; }
        public string Information { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string this[string fieldName]
        {
            get
            {
                string result = string.Empty;
                switch (fieldName)
                {
                    case "LastName":
                        if (LastName == null || LastName == "")
                            result = "Поле \"Фамилия\" не заполнено!";
                        break;
                    case "FirstName":
                        if (FirstName == null || FirstName == "")
                            result = "Поле \"Имя\" не заполнено!";
                        break;
                    case "MiddleName":
                        if (MiddleName == null || MiddleName == "")
                            result = "Поле \"Отчество\" не заполнено!";
                        break;
                    case "Position":
                        if (Position == null || Position == "")
                            result = "Поле \"Должность\" не заполнено!";
                        break;
                    case "Salary":
                        if (Salary < 0)
                            result = "Поле \"Оклад\" допускает только положительные числа!";
                        break;
                }
                return result;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
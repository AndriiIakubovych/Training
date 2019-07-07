using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace CompanyEmployeesOperating
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public Employee Employee { get; set; }

        public AddEmployeeWindow(List<string> DepartmentsList)
        {
            InitializeComponent();
            try
            {
                Employee = new Employee();
                DataContext = Employee;
                lastNameInput.Focus();
                Employee.PhotoSource = Employee.Address = Employee.Telephone = Employee.EmploymentContract = Employee.Information = string.Empty;
                Employee.Birthdate = DateTime.Now;
                Employee.HireDate = DateTime.Now;
                Employee.Gender = "Мужской";
                Employee.Department = DepartmentsList[0];
                departmentChoice.ItemsSource = DepartmentsList;
                if (departmentChoice.Items.Count > 0)
                    departmentChoice.SelectedIndex = 0;
                else
                    departmentChoice.IsEnabled = ok.IsEnabled = false;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                departmentChoice.IsEnabled = ok.IsEnabled = false;
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Открытие";
            ofd.Filter = "Файлы изображений|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Employee.PhotoSource = ofd.FileName;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Employee.Age >= 18 || Employee.Birthdate > DateTime.Now || Employee.HireDate > DateTime.Now)
                DialogResult = true;
            else
                System.Windows.MessageBox.Show("Возраст работника должен быть не менее 18 лет!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
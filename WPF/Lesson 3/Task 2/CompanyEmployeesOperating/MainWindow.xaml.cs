using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CompanyEmployeesOperating
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DependencyProperty employeeProperty;
        private string xmlFileName = "company.xml";
        private XDocument document;
        private DirectoryInfo directoryInfo;

        public List<Employee> EmployeesList { get; set; }
        public List<Employee> OriginalEmployeesList { get; set; }
        public List<string> DepartmentsList { get; set; }
        public Employee Employee { get { return (Employee)GetValue(employeeProperty); } set { SetValue(employeeProperty, value); } }

        static MainWindow()
        {
            employeeProperty = DependencyProperty.Register("Employee", typeof(Employee), typeof(MainWindow));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage photo;
                document = XDocument.Load(xmlFileName);
                directoryInfo = new DirectoryInfo("images");
                EmployeesList = new List<Employee>();
                OriginalEmployeesList = new List<Employee>();
                foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                {
                    photo = new BitmapImage();
                    photo.BeginInit();
                    photo.UriSource = employeeElement.Element("photo") != null ? new Uri(directoryInfo.FullName + "\\" + employeeElement.Element("photo").Value) : new Uri(noPhoto.Source.ToString());
                    photo.EndInit();
                    EmployeesList.Add(new Employee() { LastName = employeeElement.Element("lname").Value, FirstName = employeeElement.Element("fname").Value, MiddleName = employeeElement.Element("mname").Value, Photo = photo, Birthdate = Convert.ToDateTime(employeeElement.Element("birthdate").Value), Gender = employeeElement.Element("gender").Value, Address = employeeElement.Element("address") != null ? employeeElement.Element("address").Value : "", Telephone = employeeElement.Element("telephone") != null ? employeeElement.Element("telephone").Value : "", Department = employeeElement.Element("department").Value, Position = employeeElement.Element("position").Value, Salary = employeeElement.Element("salary") != null ? Convert.ToDouble(employeeElement.Element("salary").Value) : 0, EmploymentContract = employeeElement.Element("contract") != null ? employeeElement.Element("contract").Value : "", HireDate = Convert.ToDateTime(employeeElement.Element("hiredate").Value), Information = employeeElement.Element("information") != null ? employeeElement.Element("information").Value : "" });
                }
                EmployeesList = EmployeesList.OrderBy(emp => emp.LastName).ToList();
                foreach (Employee emp in EmployeesList)
                    OriginalEmployeesList.Add(emp);
                employeeChoice.ItemsSource = EmployeesList.Select(emp => emp.LastName + " " + emp.FirstName[0] + ". " + emp.MiddleName[0] + ".");
                if (employeeChoice.Items.Count > 0)
                    employeeChoice.SelectedIndex = 0;
                else
                    edit.IsEnabled = delete.IsEnabled = find.IsEnabled = editButton.IsEnabled = deleteButton.IsEnabled = findButton.IsEnabled = false;
                DepartmentsList = new List<string>();
                foreach (XElement departmentElement in document.Element("data").Element("departments").Elements("department"))
                    DepartmentsList.Add(departmentElement.Value);
                for (int i = 18; i <= 90; i++)
                {
                    startAgeChoice.Items.Add(i);
                    endAgeChoice.Items.Add(i);
                }
                startAgeChoice.SelectedIndex = 0;
                endAgeChoice.SelectedIndex = endAgeChoice.Items.Count - 1;
                departmentChoice.ItemsSource = DepartmentsList;
                if (departmentChoice.Items.Count > 0)
                    departmentChoice.SelectedIndex = 0;
                else
                    departmentSearch.IsEnabled = false;
                positionChoice.ItemsSource = EmployeesList.Select(emp => emp.Position).Distinct().ToList();
                if (positionChoice.Items.Count > 0)
                    positionChoice.SelectedIndex = 0;
                else
                    positionSearch.IsEnabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeeChoice.SelectedIndex >= 0)
                Employee = EmployeesList[employeeChoice.SelectedIndex];
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(DepartmentsList);
                BitmapImage photo;
                string birthdate, hireDate;
                string[] employeeName;
                if (addEmployeeWindow.ShowDialog() == true)
                {
                    if (addEmployeeWindow.Employee.PhotoSource != string.Empty)
                    {
                        if (!Directory.Exists(directoryInfo.Name))
                            Directory.CreateDirectory(directoryInfo.Name);
                        if (!File.Exists(directoryInfo.FullName + "\\" + System.IO.Path.GetFileName(addEmployeeWindow.Employee.PhotoSource)))
                            File.Copy(addEmployeeWindow.Employee.PhotoSource, directoryInfo.FullName + "\\" + System.IO.Path.GetFileName(addEmployeeWindow.Employee.PhotoSource));
                    }
                    birthdate = addEmployeeWindow.Employee.Birthdate.Year + "-" + (addEmployeeWindow.Employee.Birthdate.Month < 10 ? "0" + addEmployeeWindow.Employee.Birthdate.Month.ToString() : addEmployeeWindow.Employee.Birthdate.Month.ToString()) + "-" + (addEmployeeWindow.Employee.Birthdate.Day < 10 ? "0" + addEmployeeWindow.Employee.Birthdate.Day.ToString() : addEmployeeWindow.Employee.Birthdate.Day.ToString());
                    hireDate = addEmployeeWindow.Employee.HireDate.Year + "-" + (addEmployeeWindow.Employee.HireDate.Month < 10 ? "0" + addEmployeeWindow.Employee.HireDate.Month.ToString() : addEmployeeWindow.Employee.HireDate.Month.ToString()) + "-" + (addEmployeeWindow.Employee.HireDate.Day < 10 ? "0" + addEmployeeWindow.Employee.HireDate.Day.ToString() : addEmployeeWindow.Employee.HireDate.Day.ToString());
                    document.Element("data").Element("employees").Add(new XElement("employee", new XElement("lname", addEmployeeWindow.Employee.LastName), new XElement("fname", addEmployeeWindow.Employee.FirstName), new XElement("mname", addEmployeeWindow.Employee.MiddleName), addEmployeeWindow.Employee.PhotoSource != string.Empty ? new XElement("photo", System.IO.Path.GetFileName(addEmployeeWindow.Employee.PhotoSource)) : null, new XElement("birthdate", birthdate), new XElement("gender", addEmployeeWindow.Employee.Gender), addEmployeeWindow.Employee.Address != string.Empty ? new XElement("address", addEmployeeWindow.Employee.Address) : null, addEmployeeWindow.Employee.Telephone != string.Empty && addEmployeeWindow.Employee.Telephone.IndexOf('_') < 0 ? new XElement("telephone", addEmployeeWindow.Employee.Telephone) : null, new XElement("department", addEmployeeWindow.Employee.Department), new XElement("position", addEmployeeWindow.Employee.Position), addEmployeeWindow.Employee.Salary > 0 ? new XElement("salary", addEmployeeWindow.Employee.Salary) : null, addEmployeeWindow.Employee.EmploymentContract != string.Empty ? new XElement("contract", addEmployeeWindow.Employee.EmploymentContract) : null, new XElement("hiredate", hireDate), addEmployeeWindow.Employee.Information != string.Empty ? new XElement("information", addEmployeeWindow.Employee.Information) : null));
                    document.Save(xmlFileName);
                    EmployeesList.Clear();
                    foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                    {
                        photo = new BitmapImage();
                        photo.BeginInit();
                        photo.UriSource = employeeElement.Element("photo") != null ? new Uri(directoryInfo.FullName + "\\" + employeeElement.Element("photo").Value) : new Uri(noPhoto.Source.ToString());
                        photo.EndInit();
                        EmployeesList.Add(new Employee() { LastName = employeeElement.Element("lname").Value, FirstName = employeeElement.Element("fname").Value, MiddleName = employeeElement.Element("mname").Value, Photo = photo, Birthdate = Convert.ToDateTime(employeeElement.Element("birthdate").Value), Gender = employeeElement.Element("gender").Value, Address = employeeElement.Element("address") != null ? employeeElement.Element("address").Value : "", Telephone = employeeElement.Element("telephone") != null ? employeeElement.Element("telephone").Value : "", Department = employeeElement.Element("department").Value, Position = employeeElement.Element("position").Value, Salary = employeeElement.Element("salary") != null ? Convert.ToDouble(employeeElement.Element("salary").Value) : 0, EmploymentContract = employeeElement.Element("contract") != null ? employeeElement.Element("contract").Value : "", HireDate = Convert.ToDateTime(employeeElement.Element("hiredate").Value), Information = employeeElement.Element("information") != null ? employeeElement.Element("information").Value : "" });
                    }
                    EmployeesList = EmployeesList.OrderBy(emp => emp.LastName).ToList();
                    OriginalEmployeesList.Clear();
                    foreach (Employee emp in EmployeesList)
                        OriginalEmployeesList.Add(emp);
                    employeeChoice.ItemsSource = EmployeesList.Select(emp => emp.LastName + " " + emp.FirstName[0] + ". " + emp.MiddleName[0] + ".");
                    for (int i = 0; i < employeeChoice.Items.Count; i++)
                    {
                        employeeName = employeeChoice.Items[i].ToString().Split(' ');
                        if (employeeName[0] == addEmployeeWindow.Employee.LastName && employeeName[1][0] == addEmployeeWindow.Employee.FirstName[0] && employeeName[2][0] == addEmployeeWindow.Employee.MiddleName[0])
                        {
                            employeeChoice.SelectedIndex = i;
                            break;
                        }
                    }
                    if (employeeChoice.Items.Count > 0)
                        edit.IsEnabled = delete.IsEnabled = find.IsEnabled = editButton.IsEnabled = deleteButton.IsEnabled = findButton.IsEnabled = true;
                    positionChoice.ItemsSource = EmployeesList.Select(emp => emp.Position).Distinct().ToList();
                    if (positionChoice.Items.Count > 0)
                        positionChoice.SelectedIndex = 0;
                    else
                        positionSearch.IsEnabled = false;
                    lnameSearch.IsChecked = fnameSearch.IsChecked = mnameSearch.IsChecked = ageSearch.IsChecked = departmentSearch.IsChecked = positionSearch.IsChecked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(Employee, DepartmentsList);
                BitmapImage photo;
                XElement photoElement;
                string lastName = Employee.LastName, firstName = Employee.FirstName, middleName = Employee.MiddleName, birthdate, hireDate;
                string[] employeeName;
                if (editEmployeeWindow.ShowDialog() == true)
                {
                    if (editEmployeeWindow.photoChange.IsChecked.Value && editEmployeeWindow.Employee.PhotoSource != string.Empty)
                    {
                        if (!Directory.Exists(directoryInfo.Name))
                            Directory.CreateDirectory(directoryInfo.Name);
                        if (!File.Exists(directoryInfo.FullName + "\\" + System.IO.Path.GetFileName(editEmployeeWindow.Employee.PhotoSource)))
                            File.Copy(editEmployeeWindow.Employee.PhotoSource, directoryInfo.FullName + "\\" + System.IO.Path.GetFileName(editEmployeeWindow.Employee.PhotoSource));
                    }
                    foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                        if (employeeElement.Element("lname").Value == lastName && employeeElement.Element("fname").Value == firstName && employeeElement.Element("mname").Value == middleName)
                        {
                            photoElement = employeeElement.Element("photo");
                            employeeElement.Remove();
                            if (editEmployeeWindow.photoChange.IsChecked.Value)
                                photoElement = editEmployeeWindow.Employee.PhotoSource != string.Empty ? new XElement("photo", System.IO.Path.GetFileName(editEmployeeWindow.Employee.PhotoSource)) : null;
                            birthdate = editEmployeeWindow.Employee.Birthdate.Year + "-" + (editEmployeeWindow.Employee.Birthdate.Month < 10 ? "0" + editEmployeeWindow.Employee.Birthdate.Month.ToString() : editEmployeeWindow.Employee.Birthdate.Month.ToString()) + "-" + (editEmployeeWindow.Employee.Birthdate.Day < 10 ? "0" + editEmployeeWindow.Employee.Birthdate.Day.ToString() : editEmployeeWindow.Employee.Birthdate.Day.ToString());
                            hireDate = editEmployeeWindow.Employee.HireDate.Year + "-" + (editEmployeeWindow.Employee.HireDate.Month < 10 ? "0" + editEmployeeWindow.Employee.HireDate.Month.ToString() : editEmployeeWindow.Employee.HireDate.Month.ToString()) + "-" + (editEmployeeWindow.Employee.HireDate.Day < 10 ? "0" + editEmployeeWindow.Employee.HireDate.Day.ToString() : editEmployeeWindow.Employee.HireDate.Day.ToString());
                            document.Element("data").Element("employees").Add(new XElement("employee", new XElement("lname", editEmployeeWindow.Employee.LastName), new XElement("fname", editEmployeeWindow.Employee.FirstName), new XElement("mname", editEmployeeWindow.Employee.MiddleName), photoElement, new XElement("birthdate", birthdate), new XElement("gender", editEmployeeWindow.Employee.Gender), editEmployeeWindow.Employee.Address != string.Empty ? new XElement("address", editEmployeeWindow.Employee.Address) : null, editEmployeeWindow.Employee.Telephone != string.Empty && editEmployeeWindow.Employee.Telephone.IndexOf('_') < 0 ? new XElement("telephone", editEmployeeWindow.Employee.Telephone) : null, new XElement("department", editEmployeeWindow.Employee.Department), new XElement("position", editEmployeeWindow.Employee.Position), editEmployeeWindow.Employee.Salary > 0 ? new XElement("salary", editEmployeeWindow.Employee.Salary) : null, editEmployeeWindow.Employee.EmploymentContract != string.Empty ? new XElement("contract", editEmployeeWindow.Employee.EmploymentContract) : null, new XElement("hiredate", hireDate), editEmployeeWindow.Employee.Information != string.Empty ? new XElement("information", editEmployeeWindow.Employee.Information) : null));
                            break;
                        }
                    document.Save(xmlFileName);
                    EmployeesList.Clear();
                    foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                    {
                        photo = new BitmapImage();
                        photo.BeginInit();
                        photo.UriSource = employeeElement.Element("photo") != null ? new Uri(directoryInfo.FullName + "\\" + employeeElement.Element("photo").Value) : new Uri(noPhoto.Source.ToString());
                        photo.EndInit();
                        EmployeesList.Add(new Employee() { LastName = employeeElement.Element("lname").Value, FirstName = employeeElement.Element("fname").Value, MiddleName = employeeElement.Element("mname").Value, Photo = photo, Birthdate = Convert.ToDateTime(employeeElement.Element("birthdate").Value), Gender = employeeElement.Element("gender").Value, Address = employeeElement.Element("address") != null ? employeeElement.Element("address").Value : "", Telephone = employeeElement.Element("telephone") != null ? employeeElement.Element("telephone").Value : "", Department = employeeElement.Element("department").Value, Position = employeeElement.Element("position").Value, Salary = employeeElement.Element("salary") != null ? Convert.ToDouble(employeeElement.Element("salary").Value) : 0, EmploymentContract = employeeElement.Element("contract") != null ? employeeElement.Element("contract").Value : "", HireDate = Convert.ToDateTime(employeeElement.Element("hiredate").Value), Information = employeeElement.Element("information") != null ? employeeElement.Element("information").Value : "" });
                    }
                    EmployeesList = EmployeesList.OrderBy(emp => emp.LastName).ToList();
                    OriginalEmployeesList.Clear();
                    foreach (Employee emp in EmployeesList)
                        OriginalEmployeesList.Add(emp);
                    employeeChoice.ItemsSource = EmployeesList.Select(emp => emp.LastName + " " + emp.FirstName[0] + ". " + emp.MiddleName[0] + ".");
                    for (int i = 0; i < employeeChoice.Items.Count; i++)
                    {
                        employeeName = employeeChoice.Items[i].ToString().Split(' ');
                        if (employeeName[0] == editEmployeeWindow.Employee.LastName && employeeName[1][0] == editEmployeeWindow.Employee.FirstName[0] && employeeName[2][0] == editEmployeeWindow.Employee.MiddleName[0])
                        {
                            employeeChoice.SelectedIndex = i;
                            break;
                        }
                    }
                    Employees_SelectionChanged(sender, null);
                    positionChoice.ItemsSource = EmployeesList.Select(emp => emp.Position).Distinct().ToList();
                    if (positionChoice.Items.Count > 0)
                        positionChoice.SelectedIndex = 0;
                    else
                        positionSearch.IsEnabled = false;
                    lnameSearch.IsChecked = fnameSearch.IsChecked = mnameSearch.IsChecked = ageSearch.IsChecked = departmentSearch.IsChecked = positionSearch.IsChecked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка изменения данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = employeeChoice.SelectedIndex;
                BitmapImage photo;
                if (MessageBox.Show("Вы действительно хотите удалить данные о работнике?", "Удаление данных", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                        if (employeeElement.Element("lname").Value == Employee.LastName && employeeElement.Element("fname").Value == Employee.FirstName && employeeElement.Element("mname").Value == Employee.MiddleName)
                        {
                            employeeElement.Remove();
                        }
                    document.Save(xmlFileName);
                    EmployeesList.Clear();
                    foreach (XElement employeeElement in document.Element("data").Element("employees").Elements("employee"))
                    {
                        photo = new BitmapImage();
                        photo.BeginInit();
                        photo.UriSource = employeeElement.Element("photo") != null ? new Uri(directoryInfo.FullName + "\\" + employeeElement.Element("photo").Value) : new Uri(noPhoto.Source.ToString());
                        photo.EndInit();
                        EmployeesList.Add(new Employee() { LastName = employeeElement.Element("lname").Value, FirstName = employeeElement.Element("fname").Value, MiddleName = employeeElement.Element("mname").Value, Photo = photo, Birthdate = Convert.ToDateTime(employeeElement.Element("birthdate").Value), Gender = employeeElement.Element("gender").Value, Address = employeeElement.Element("address") != null ? employeeElement.Element("address").Value : "", Telephone = employeeElement.Element("telephone") != null ? employeeElement.Element("telephone").Value : "", Department = employeeElement.Element("department").Value, Position = employeeElement.Element("position").Value, Salary = employeeElement.Element("salary") != null ? Convert.ToDouble(employeeElement.Element("salary").Value) : 0, EmploymentContract = employeeElement.Element("contract") != null ? employeeElement.Element("contract").Value : "", HireDate = Convert.ToDateTime(employeeElement.Element("hiredate").Value), Information = employeeElement.Element("information") != null ? employeeElement.Element("information").Value : "" });
                    }
                    EmployeesList = EmployeesList.OrderBy(emp => emp.LastName).ToList();
                    OriginalEmployeesList.Clear();
                    foreach (Employee emp in EmployeesList)
                        OriginalEmployeesList.Add(emp);
                    employeeChoice.ItemsSource = EmployeesList.Select(emp => emp.LastName + " " + emp.FirstName[0] + ". " + emp.MiddleName[0] + ".");
                    if (employeeChoice.Items.Count > 0)
                    {
                        if (lnameSearch.IsChecked == false && fnameSearch.IsChecked == false && mnameSearch.IsChecked == false && ageSearch.IsChecked == false && departmentSearch.IsChecked == false && positionSearch.IsChecked == false)
                        {
                            index = index > 0 ? index - 1 : 0;
                            employeeChoice.SelectedIndex = index;
                        }
                        else
                            employeeChoice.SelectedIndex = 0;
                    }
                    else
                    {
                        edit.IsEnabled = delete.IsEnabled = find.IsEnabled = editButton.IsEnabled = deleteButton.IsEnabled = findButton.IsEnabled = false;
                        Employee = null;
                    }
                    positionChoice.ItemsSource = EmployeesList.Select(emp => emp.Position).Distinct().ToList();
                    if (positionChoice.Items.Count > 0)
                        positionChoice.SelectedIndex = 0;
                    else
                        positionSearch.IsEnabled = false;
                    lnameSearch.IsChecked = fnameSearch.IsChecked = mnameSearch.IsChecked = ageSearch.IsChecked = departmentSearch.IsChecked = positionSearch.IsChecked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EmployeeChoiceItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit_Click(sender, e);
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lname = lnameSearch.IsChecked == true ? lnameInput.Text : "", fname = fnameSearch.IsChecked == true ? fnameInput.Text : "", mname = mnameSearch.IsChecked == true ? mnameInput.Text : "";
                int startAge = ageSearch.IsChecked == true ? Convert.ToInt32(startAgeChoice.Text) : Convert.ToInt32(startAgeChoice.Items[0]), endAge = ageSearch.IsChecked == true ? Convert.ToInt32(endAgeChoice.Text) : Convert.ToInt32(endAgeChoice.Items[endAgeChoice.Items.Count - 1]);
                EmployeesList.Clear();
                foreach (Employee emp in OriginalEmployeesList)
                    EmployeesList.Add(emp);
                EmployeesList = EmployeesList.Where(emp => emp.LastName.ToLower().Contains(lname.ToLower()) && emp.FirstName.ToLower().Contains(fname.ToLower()) && emp.MiddleName.ToLower().Contains(mname.ToLower()) && emp.Age >= startAge && emp.Age <= endAge && emp.Department == (departmentSearch.IsChecked == true ? departmentChoice.Text : emp.Department) && emp.Position == (positionSearch.IsChecked == true ? positionChoice.Text : emp.Position)).OrderBy(emp => emp.LastName).ToList();
                employeeChoice.ItemsSource = EmployeesList.Select(emp => emp.LastName + " " + emp.FirstName[0] + ". " + emp.MiddleName[0] + ".");
                if (employeeChoice.Items.Count > 0)
                    employeeChoice.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка поиска данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowToolBar_Click(object sender, RoutedEventArgs e)
        {
            if (showToolBar.IsChecked)
            {
                toolBar.Visibility = Visibility.Visible;
                dockPanel.Children.Clear();
                dockPanel.Children.Add(mainMenu);
                DockPanel.SetDock(mainMenu, Dock.Top);
                dockPanel.Children.Add(toolBar);
                DockPanel.SetDock(toolBar, Dock.Top);
                dockPanel.Children.Add(statusBar);
                DockPanel.SetDock(statusBar, Dock.Bottom);
                dockPanel.Children.Add(searchParameters);
                DockPanel.SetDock(searchParameters, Dock.Bottom);
                dockPanel.Children.Add(mainContent);
            }
            else
            {
                toolBar.Visibility = Visibility.Hidden;
                dockPanel.Children.Remove(toolBar);
            }
        }

        private void ShowSearchPanel_Click(object sender, RoutedEventArgs e)
        {
            if (showSearchPanel.IsChecked)
            {
                searchParameters.Visibility = Visibility.Visible;
                dockPanel.Children.Clear();
                dockPanel.Children.Add(mainMenu);
                DockPanel.SetDock(mainMenu, Dock.Top);
                dockPanel.Children.Add(toolBar);
                DockPanel.SetDock(toolBar, Dock.Top);
                dockPanel.Children.Add(statusBar);
                DockPanel.SetDock(statusBar, Dock.Bottom);
                dockPanel.Children.Add(searchParameters);
                DockPanel.SetDock(searchParameters, Dock.Bottom);
                dockPanel.Children.Add(mainContent);
            }
            else
            {
                searchParameters.Visibility = Visibility.Hidden;
                dockPanel.Children.Remove(searchParameters);
            }
        }

        private void ShowStatusBar_Click(object sender, RoutedEventArgs e)
        {
            if (showStatusBar.IsChecked)
            {
                statusBar.Visibility = Visibility.Visible;
                dockPanel.Children.Clear();
                dockPanel.Children.Add(mainMenu);
                DockPanel.SetDock(mainMenu, Dock.Top);
                dockPanel.Children.Add(toolBar);
                DockPanel.SetDock(toolBar, Dock.Top);
                dockPanel.Children.Add(statusBar);
                DockPanel.SetDock(statusBar, Dock.Bottom);
                dockPanel.Children.Add(searchParameters);
                DockPanel.SetDock(searchParameters, Dock.Bottom);
                dockPanel.Children.Add(mainContent);
            }
            else
            {
                statusBar.Visibility = Visibility.Hidden;
                dockPanel.Children.Remove(statusBar);
            }
        }

        private void Add_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Добавить нового работника";
        }

        private void Add_MouseLeave(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Готово";
        }

        private void Edit_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Изменить данные о работнике";
        }

        private void Edit_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void Delete_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Удалить данные о работнике";
        }

        private void Delete_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void Find_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Искать персонал по критериям поиска";
        }

        private void Find_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void Exit_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Выйти из программы";
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void ShowToolBar_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Отображать/скрывать панель инструментов";
        }

        private void ShowToolBar_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void ShowSearchPanel_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Отображать/скрывать панель поиска";
        }

        private void ShowSearchPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }

        private void ShowStatusBar_MouseMove(object sender, MouseEventArgs e)
        {
            statusBarText.Text = "Отображать/скрывать строку состояния";
        }

        private void ShowStatusBar_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_MouseLeave(sender, e);
        }
    }
}
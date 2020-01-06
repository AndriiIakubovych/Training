using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace EmployeesSalaryCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemNumber = 0, index = -1, employeeType, employeeId;
            string name;
            string[] data, newData;
            double salary;
            List<Employee> employeesList = new List<Employee>();
            StreamReader sr;
            StreamWriter sw;
            Console.Title = "Расчёт заработной платы работников";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("М Е Н Ю");
                    Console.WriteLine("\n1 - Добавить нового работника");
                    Console.WriteLine("2 - Редактировать данные о работнике");
                    Console.WriteLine("3 - Удалить работника");
                    Console.WriteLine("4 - Вывести все данные");
                    Console.WriteLine("5 - Вывести данные по критерию");
                    Console.WriteLine("6 - Записать данные в файл");
                    Console.WriteLine("7 - Прочитать данные из файла");
                    Console.WriteLine("8 - Выход");
                    Console.Write("\nВаш выбор: ");
                    itemNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (itemNumber)
                    {
                        case 1:
                            try
                            {
                                Console.Write("Выберите тип работника (1 - с почасовой оплатой, 2 - с фиксированной оплатой): ");
                                employeeType = Convert.ToInt32(Console.ReadLine());
                                if (employeeType == 1)
                                {
                                    Console.Write("Введите имя работника: ");
                                    name = Console.ReadLine();
                                    Console.Write("Введите почасовую ставку (грн.): ");
                                    salary = Convert.ToDouble(Console.ReadLine());
                                    if (salary <= 0)
                                        throw new FormatException();
                                    employeesList.Add(new HourlySalaryEmployee(employeesList.Count > 0 ? employeesList[employeesList.Count - 1].Id + 1 : 1, name, salary));
                                    Console.WriteLine("\nДанные успешно добавлены!");
                                }
                                else
                                {
                                    if (employeeType == 2)
                                    {
                                        Console.Write("Введите имя работника: ");
                                        name = Console.ReadLine();
                                        Console.Write("Введите фиксированную месячную оплату (грн.): ");
                                        salary = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                        if (salary <= 0)
                                            throw new FormatException();
                                        employeesList.Add(new FixedSalaryEmployee(employeesList.Count > 0 ? employeesList[employeesList.Count - 1].Id + 1 : 1, name, salary));
                                        Console.WriteLine("\nДанные успешно добавлены!");
                                    }
                                    else
                                        Console.WriteLine("\nНеправильный выбор!");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка ввода!");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            try
                            {
                                Console.Write("Введите идентификатор работника: ");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                index = employeesList.FindIndex(e => e.Id == employeeId);
                                Console.WriteLine(index);
                                if (index > -1)
                                {
                                    if (employeesList[index] is HourlySalaryEmployee)
                                    {
                                        Console.Write("Введите имя работника: ");
                                        name = Console.ReadLine();
                                        Console.Write("Введите почасовую ставку (грн.): ");
                                        salary = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                                        if (salary <= 0)
                                            throw new FormatException();
                                        employeesList[index] = new HourlySalaryEmployee(employeeId, name, salary);
                                    }
                                    else
                                    {
                                        Console.Write("Введите имя работника: ");
                                        name = Console.ReadLine();
                                        Console.Write("Введите фиксированную месячную оплату (грн.): ");
                                        salary = Convert.ToDouble(Console.ReadLine());
                                        if (salary <= 0)
                                            throw new FormatException();
                                        employeesList[index] = new FixedSalaryEmployee(employeeId, name, salary);
                                    }
                                    Console.WriteLine("\nДанные о работнике успешно изменены!");
                                }
                                else
                                    Console.WriteLine("\nРаботник не найден!");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка ввода!");
                            }
                            Console.ReadKey();
                            break;
                        case 3:
                            try
                            {
                                Console.Write("Введите идентификатор работника: ");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                index = employeesList.FindIndex(e => e.Id == employeeId);
                                if (index > -1)
                                {
                                    employeesList.RemoveAt(index);
                                    Console.WriteLine("\nРаботник успешно удалён!");
                                }
                                else
                                    Console.WriteLine("\nРаботник не найден!");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка ввода!");
                            }
                            Console.ReadKey();
                            break;
                        case 4:
                            if (employeesList.Count > 0)
                                for (int i = 0; i < employeesList.Count; i++)
                                {
                                    if (i > 0)
                                        Console.WriteLine();
                                    Console.WriteLine("Идентификатор работника: " + employeesList[i].Id);
                                    Console.WriteLine("Имя работника: " + employeesList[i].Name);
                                    Console.WriteLine("Среднемесячная заработная плата: " + employeesList[i].GetAverageMonthlySalary() + " грн.");
                                }
                            else
                                Console.WriteLine("Данные отсутствуют!");
                            Console.ReadKey();
                            break;
                        case 5:
                            if (employeesList.Count > 0)
                            {
                                List<Employee> newEmployeesList = new List<Employee>();
                                foreach (Employee e in employeesList)
                                    newEmployeesList.Add(e);
                                newEmployeesList.Sort(delegate (Employee e1, Employee e2)
                                {
                                    int comparer = e2.GetAverageMonthlySalary().CompareTo(e1.GetAverageMonthlySalary());
                                    if (comparer == 0)
                                        comparer = e1.Name.CompareTo(e2.Name);
                                    return comparer;
                                });
                                Console.WriteLine("Список работников, отсортированный по убыванию среднемесячного заработка (или имени работников):");
                                foreach (Employee e in newEmployeesList)
                                    Console.WriteLine(e.Id + " - " + e.Name + " - " + e.GetAverageMonthlySalary() + " грн.");
                                Console.WriteLine("\nПервые 5 имён работников из полученного списка:");
                                foreach (Employee e in newEmployeesList.Take(5))
                                    Console.WriteLine(e.Name);
                                Console.WriteLine("\nПоследние 3 идентификатора работников из полученного списка:");
                                foreach (Employee e in newEmployeesList.Skip(newEmployeesList.Count - 3).Take(3))
                                    Console.WriteLine(e.Id);
                            }
                            else
                                Console.WriteLine("Данные отсутствуют!");
                            Console.ReadKey();
                            break;
                        case 6:
                            try
                            {
                                if (employeesList.Count > 0)
                                {
                                    Console.Write("Введите путь к файлу: ");
                                    name = Console.ReadLine();
                                    sw = new StreamWriter(name, false, Encoding.UTF8);
                                    foreach (Employee e in employeesList)
                                    {
                                        if (e is HourlySalaryEmployee)
                                        {
                                            HourlySalaryEmployee requiredEmployee = (HourlySalaryEmployee)e;
                                            employeeType = 0;
                                            sw.WriteLine(requiredEmployee.Id + "/" + requiredEmployee.Name + "/" + requiredEmployee.HourlySalary + "/" + employeeType);
                                        }
                                        else
                                        {
                                            FixedSalaryEmployee requiredEmployee = (FixedSalaryEmployee)e;
                                            employeeType = 1;
                                            sw.WriteLine(requiredEmployee.Id + "/" + requiredEmployee.Name + "/" + requiredEmployee.MonthlySalary + "/" + employeeType);
                                        }
                                    }
                                    sw.Dispose();
                                    Console.WriteLine("\nДанные успешно записаны в файл!");
                                }
                                else
                                    Console.WriteLine("Данные отсутствуют!");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nОшибка записи в файл!");
                            }
                            Console.ReadKey();
                            break;
                        case 7:
                            try
                            {
                                Console.Write("Введите путь к файлу: ");
                                name = Console.ReadLine();
                                sr = new StreamReader(name);
                                data = sr.ReadToEnd().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                employeesList.Clear();
                                foreach (string s in data)
                                {
                                    newData = s.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                    if (Convert.ToInt32(newData[3]) == 0)
                                        employeesList.Add(new HourlySalaryEmployee(Convert.ToInt32(newData[0]), newData[1], Math.Round(Convert.ToDouble(newData[2]), 2)));
                                    else
                                        employeesList.Add(new FixedSalaryEmployee(Convert.ToInt32(newData[0]), newData[1], Math.Round(Convert.ToDouble(newData[2]), 2)));
                                }
                                sr.Dispose();
                                Console.WriteLine("\nДанные из файла успешно прочитаны!");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nОшибка чтения файла!");
                            }
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.WriteLine("Работа завершена!");
                            break;
                        default:
                            Console.WriteLine("Нет такого пункта меню!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка ввода!");
                    Console.ReadKey();
                }
            }
            while (itemNumber != 8);
            Console.ReadKey();
        }
    }
}
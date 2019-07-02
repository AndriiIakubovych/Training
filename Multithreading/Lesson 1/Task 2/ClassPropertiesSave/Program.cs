using System;

namespace ClassPropertiesSave
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int money, percent;
            string name, choice;
            Console.Title = "Сохранение свойств класса";
            try
            {
                Console.Write("Введите бюджет банка (грн.): ");
                money = Convert.ToInt32(Console.ReadLine());
                if (money < 0)
                    throw new Exception();
                Console.Write("Введите название банка: ");
                name = Console.ReadLine();
                Console.Write("Введите количество процентов за кредит (%): ");
                percent = Convert.ToInt32(Console.ReadLine());
                if (percent < 0 || percent >= 100)
                    throw new Exception();
                bank.ChangeProperties(money, name, percent);
                Console.WriteLine("\nДанные о свойствах успешно записаны в файл!");
                do
                {
                    Console.Write("\nВыберите свойство для изменения: (1 - бюджет, 2 - название, 3 - процент, 4 - выход): ");
                    choice = Console.ReadLine();
                    Console.WriteLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите бюджет банка (грн.): ");
                            money = Convert.ToInt32(Console.ReadLine());
                            if (money > 0)
                            {
                                bank.ChangeProperties(money, name, percent);
                                Console.WriteLine("\nДанные о свойствах успешно записаны в файл!");
                            }
                            else
                                Console.WriteLine("\nОшибка ввода!");
                            break;
                        case "2":
                            Console.Write("Введите название банка: ");
                            name = Console.ReadLine();
                            bank.ChangeProperties(money, name, percent);
                            Console.WriteLine("\nДанные о свойствах успешно записаны в файл!");
                            break;
                        case "3":
                            Console.Write("Введите количество процентов за кредит (%): ");
                            percent = Convert.ToInt32(Console.ReadLine());
                            if (percent > 0 && percent <= 100)
                            {
                                bank.ChangeProperties(money, name, percent);
                                Console.WriteLine("\nДанные о свойствах успешно записаны в файл!");
                            }
                            else
                                Console.WriteLine("\nОшибка ввода!");
                            break;
                        case "4":
                            Console.WriteLine("Работа завершена!");
                            break;
                        default:
                            Console.WriteLine("Ошибка ввода!");
                            break;
                    }
                }
                while (choice != "4");
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}
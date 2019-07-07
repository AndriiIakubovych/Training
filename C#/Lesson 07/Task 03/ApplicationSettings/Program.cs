using System;
using System.IO;

namespace ApplicationSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            byte red, green, blue;
            int choose, width, height;
            string title;
            Console.Title = "Настройки приложения";
            try
            {
                ApplicationSettingsHelper.ReadSettings();
            }
            catch (FormatException)
            {
                ApplicationSettingsHelper.WriteSettings(0, 0, 0, Console.WindowWidth, Console.WindowHeight, Console.Title);
            }
            catch (FileNotFoundException)
            {
                ApplicationSettingsHelper.WriteSettings(0, 0, 0, Console.WindowWidth, Console.WindowHeight, Console.Title);
            }
            catch (EndOfStreamException)
            {
                ApplicationSettingsHelper.WriteSettings(0, 0, 0, Console.WindowWidth, Console.WindowHeight, Console.Title);
            }
            do
            {
                Console.Clear();
                Console.Write("Выберите действие:\n\n1 - Считывание настроек приложения\n2 - Запись настроек приложения\n3 - Выход\n\nВаш выбор: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            ApplicationSettingsHelper.ReadSettings();
                            Console.WriteLine("Настройки приложения успешно считаны!");
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Файл не найден!");
                        }
                        catch (EndOfStreamException)
                        {
                            Console.WriteLine("Ошибка чтения файла!");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Введите цвет окна:");
                            Console.Write("Красный = ");
                            red = Convert.ToByte(Console.ReadLine());
                            Console.Write("Зелёный = ");
                            green = Convert.ToByte(Console.ReadLine());
                            Console.Write("Синий = ");
                            blue = Convert.ToByte(Console.ReadLine());
                            Console.Write("Введите ширину окна: ");
                            width = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите высоту окна: ");
                            height = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите заголовок окна: ");
                            title = Console.ReadLine();
                            ApplicationSettingsHelper.WriteSettings(red, green, blue, width, height, title);
                            Console.WriteLine("\nНастройки приложения успешно записаны!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nОшибка ввода!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("\nОшибка ввода!");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Работа завершена!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор!");
                        Console.ReadKey();
                        break;
                }
            }
            while (choose != 3);
        }
    }
}
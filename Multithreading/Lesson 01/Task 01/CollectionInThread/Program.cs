using System;
using System.Collections.Generic;
using System.Threading;

namespace CollectionInThread
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            List<object> collection = new List<object>();
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(PrintCollection);
            Thread thread = new Thread(threadStart);
            Console.Title = "Запись коллекции в поток";
            Console.Write("Введите количество элементов коллекции: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    Console.WriteLine();
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Введите значение " + (i + 1) + "-го элемента коллекции: ");
                        collection.Add(Console.ReadLine());
                    }
                    Console.WriteLine();
                    thread.Start(collection);
                }
                else
                    Console.WriteLine("\nКоличество элементов введено неверно!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }

        static void PrintCollection(object parameter)
        {
            List<object> collection = (List<object>)parameter;
            Console.WriteLine("Значения элементов коллекции: ");
            for (int i = 0; i < collection.Count; i++)
                Console.WriteLine(collection[i].ToString());
        }
    }
}
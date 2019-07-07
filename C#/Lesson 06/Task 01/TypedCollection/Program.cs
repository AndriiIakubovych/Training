using System;
using System.Collections.Specialized;

namespace TypedCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string element;
            bool continueEnter;
            Console.Title = "Типизированная коллекция";
            StringCollection collection = new StringCollection();
            do
            {
                Console.Write("Введите значение нового элемента коллекции: ");
                element = Console.ReadLine();
                collection.Add(element);
                Console.Write("Добавить ещё элементов в коллекцию (y/n)? ");
                continueEnter = Console.ReadLine().ToLower().StartsWith("n");
                Console.WriteLine();
            }
            while (!continueEnter);
            Console.WriteLine("Полученная коллекция:");
            foreach (string s in collection)
                Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
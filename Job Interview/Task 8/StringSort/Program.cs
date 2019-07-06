using System;

namespace StringSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.Write("Введите строку: ");
            str = Console.ReadLine();
            Console.WriteLine("\nПреобразованная строка: " + Sort(str));
            Console.ReadKey();
        }

        static string Sort(string str)
        {
            char[] array = str.ToCharArray();
            Array.Sort(array);
            Array.Reverse(array);
            return new string(array);
        }
    }
}
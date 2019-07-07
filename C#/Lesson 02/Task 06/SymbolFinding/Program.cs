using System;

namespace SymbolFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            char c;
            int count = 0;
            Console.Title = "Нахождение символа в строке";
            Console.Write("Введите строку: ");
            s = Console.ReadLine();
            Console.Write("Введите символ: ");
            c = Convert.ToChar(Console.ReadLine());
            Console.Write("\nИндексы элементов строки, куда входит данный символ: ");
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c)
                {
                    Console.Write(i + " ");
                    count++;
                }
            if (count == 0)
                Console.Write("нет");
            s = s.Replace(c, Convert.ToChar(c.ToString().ToUpper()));
            s = s.Remove(s.LastIndexOf(Convert.ToChar(c.ToString().ToUpper())));
            Console.WriteLine("\nПреобразованная строка: " + s);
            Console.ReadKey();
        }
    }
}
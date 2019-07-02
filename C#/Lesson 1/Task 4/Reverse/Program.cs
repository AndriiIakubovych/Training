using System;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, newN;
            String strValue = "";
            Console.Title = "Число, прочитанное в обратном порядке";
            Console.Write("Введите значение числа N: ");
            N = Convert.ToInt32(Console.ReadLine());
            if (N > 0)
            {
                newN = N;
                while (newN >= 10)
                {
                    strValue += newN % 10;
                    newN = newN / 10;
                }
                strValue += newN;
                newN = Convert.ToInt32(strValue);
                Console.WriteLine("\nЧисло, полученное при прочтении числа N справа налево: " + newN);
            }
            else
                Console.WriteLine("\nЗначение числа N введено неверно!");
            Console.ReadKey();
        }
    }
}
using System;

namespace IntegersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B;
            Console.Title = "Строки чисел";
            Console.Write("Введите значение числа A: ");
            A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите значение числа B: ");
            B = Convert.ToInt32(Console.ReadLine());
            if (A > 0 && B > 0 && A < B)
            {
                Console.WriteLine("\nРезультат:");
                for (int i = A; i <= B; i++)
                {
                    for (int j = 0; j < i; j++)
                        Console.Write(i + " ");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("\nЗначения чисел A и B введены неверно!");
            Console.ReadKey();
        }
    }
}
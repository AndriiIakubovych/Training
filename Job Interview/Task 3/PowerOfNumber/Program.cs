using System;

namespace PowerOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.Title = "Степень числа 2";
            try
            {
                Console.Write("Введите значение натурального числа N: ");
                N = Convert.ToInt32(Console.ReadLine());
                if (N > 0)
                {
                    if ((N & (N - 1)) == 0)
                        Console.WriteLine("\nЧисло N является степенью числа 2!");
                    else
                        Console.WriteLine("\nЧисло N не является степенью числа 2!");
                }
                else
                    Console.WriteLine("\nЗначение числа N введено неверно!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}
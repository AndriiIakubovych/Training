using System;

namespace NumberInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, count = 0;
            double[] array;
            double number;
            Console.Title = "Число в массиве";
            Console.Write("Введите размерность массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n > 0)
            {
                array = new double[n];
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Введите элемент массива с индексом [" + i + "]: ");
                    array[i] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine("\nВы ввели массив:");
                for (int i = 0; i < n; i++)
                    Console.Write(array[i] + " ");
                Console.WriteLine();
                Console.Write("\nВведите число для поиска: ");
                number = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                    if (array[i] == number)
                        count++;
                Console.WriteLine("\nКоличество раз, которое число " + number + " встречается в массиве: " + count);
            }
            else
                Console.WriteLine("\nРазмерность массива введена неверно!");
            Console.ReadKey();
        }
    }
}
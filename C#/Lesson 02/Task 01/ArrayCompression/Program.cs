using System;

namespace ArrayCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] array;
            Console.Title = "Сжатие массива";
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
                for (int i = 0, k = 0; i < n; i++)
                    if (array[i] == 0)
                    {
                        k++;
                        for (int j = i; j < n - k; j++)
                            array[j] = array[j + 1];
                        array[n - k] = -1;
                        if (array[i] == 0)
                            i--;
                    }
                Console.WriteLine("\nПреобразованный массив:");
                for (int i = 0; i < n; i++)
                    Console.Write(array[i] + " ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("\nРазмерность массива введена неверно!");
            Console.ReadKey();
        }
    }
}
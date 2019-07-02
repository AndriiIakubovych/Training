using System;

namespace ArrayTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] array;
            double negativeNumber;
            Console.Title = "Преобразование массива";
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
                    if (array[i] < 0)
                    {
                        negativeNumber = array[i];
                        for (int j = i; j > k; j--)
                            array[j] = array[j - 1];
                        array[k] = negativeNumber;
                        k++;
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
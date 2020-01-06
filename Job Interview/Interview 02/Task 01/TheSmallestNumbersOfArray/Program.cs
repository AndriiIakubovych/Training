using System;

namespace TheSmallestNumbersOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] array;
            double[] indexes = new double[3] { 0, 1, 2 };
            double a, b, c;
            Console.Title = "Номера трёх наименьших элементов массива";
            try
            {
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
                    a = array[0];
                    b = array[1];
                    c = array[2];
                    for (int i = 3; i < n; i++)
                        if (array[i] < a || array[i] < b || array[i] < c)
                        {
                            if (a > b && a > c)
                            {
                                a = array[i];
                                indexes[0] = i;
                            }
                            else
                                if (b > c)
                                {
                                    b = array[i];
                                    indexes[1] = i;
                                }
                                else
                                {
                                    c = array[i];
                                    indexes[2] = i;
                                }
                        }
                    Array.Sort(indexes);
                    Console.Write("\nИндексы трёх наименьших чисел массива: " + indexes[0] + " " + indexes[1] + " " + indexes[2] + "\n");
                }
                else
                    Console.WriteLine("\nРазмерность массива введена неверно!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}
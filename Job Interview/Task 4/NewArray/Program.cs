using System;

namespace NewArray
{
    class Program
    {
        static void GetNewArray(double[] array, out double[] newArray)
        {
            newArray = new double[array.Length];
            newArray[0] = array[0];
            for (int i = 1; i < array.Length; i++)
                newArray[i] = newArray[i - 1] + array[i];
        }

        static void Main(string[] args)
        {
            int n;
            double[] array;
            double[] newArray = { };
            Console.Title = "Получение нового массива";
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
                    Console.WriteLine("\n\nПолученный массив:");
                    GetNewArray(array, out newArray);
                    for (int i = 0; i < n; i++)
                        Console.Write(newArray[i] + " ");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}
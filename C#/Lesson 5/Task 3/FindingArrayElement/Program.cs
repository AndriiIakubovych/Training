using System;

namespace FindingArrayElement
{
    class Program
    {
        static public int FindElement(string[] array, string requiredElement, Comparer comparer)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
                if (comparer(array[i], requiredElement))
                {
                    index = i;
                    break;
                }
            return index;
        }

        static public bool IsRequired(string arrayElement, string requiredElement)
        {
            return arrayElement == requiredElement;
        }

        public delegate bool Comparer(string firstElement, string secondElement);

        static void Main(string[] args)
        {
            int n, result;
            string[] array;
            string requiredElement;
            Console.Title = "Нахождение элемента массива";
            try
            {
                Console.Write("Введите размерность массива: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    array = new string[n];
                    Console.WriteLine();
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Введите элемент массива с индексом [" + i + "]: ");
                        array[i] = Console.ReadLine();
                    }
                    Console.WriteLine("\nВы ввели массив:");
                    for (int i = 0; i < n; i++)
                        Console.Write(array[i] + " ");
                    Console.WriteLine();
                    Console.Write("\nВведите значение элемента массива, который необходимо найти: ");
                    requiredElement = Console.ReadLine();
                    result = FindElement(array, requiredElement, new Comparer(IsRequired));
                    if (result >= 0)
                        Console.WriteLine("\nИндекс искомого элемента массива: " + result);
                    else
                        Console.WriteLine("\nЭлемент не найден!");
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
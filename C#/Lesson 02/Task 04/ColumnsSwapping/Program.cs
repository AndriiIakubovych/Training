using System;

namespace ColumnsSwapping
{
    class Program
    {
        static void Main(string[] args)
        {
            int M, N, firstColumn, secondColumn;
            double[,] array;
            double max;
            Console.Title = "Перестановка столбцов в матрице";
            Console.Write("Введите количество строк массива: ");
            M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов массива: ");
            N = Convert.ToInt32(Console.ReadLine());
            if (M > 0 && N > 0)
            {
                array = new double[M, N];
                Console.WriteLine();
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("Введите элемент массива с индексом [" + i + ", " + j + "]: ");
                        array[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                max = array[0, 0];
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                        if (array[i, j] > max)
                            max = array[i, j];
                Console.WriteLine("\nВы ввели массив:");
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write("{0, -" + (max.ToString().Length + 1) + "}", array[i, j]);
                    Console.WriteLine();
                }
                Console.WriteLine("\nКакие столбцы вы бы хотели поменять местами?");
                Console.Write("Номер первого столбца: ");
                firstColumn = Convert.ToInt32(Console.ReadLine());
                Console.Write("Номер второго столбца: ");
                secondColumn = Convert.ToInt32(Console.ReadLine());
                if (firstColumn >= 0 && firstColumn < N && secondColumn >= 0 && secondColumn < N)
                {
                    for (int i = 0; i < M; i++)
                    {
                        array[i, firstColumn] = array[i, firstColumn] + array[i, secondColumn];
                        array[i, secondColumn] = array[i, secondColumn] - array[i, firstColumn];
                        array[i, secondColumn] = -array[i, secondColumn];
                        array[i, firstColumn] = array[i, firstColumn] - array[i, secondColumn];
                    }
                    Console.WriteLine("\nПреобразованный массив:");
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                            Console.Write("{0, -" + (max.ToString().Length + 1) + "}", array[i, j]);
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("\nНомера столбцов введены неверно!");
            }
            else
                Console.WriteLine("\nРазмерность массива введена неверно!");
            Console.ReadKey();
        }
    }
}
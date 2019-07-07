using System;

namespace EquationCoefficient
{
    class LinearEquation
    {
        public static double A;
        public static double B;

        public static bool Parse(string coefficientsString)
        {
            string[] array;
            coefficientsString = coefficientsString.Replace(", ", " ");
            if (!coefficientsString.Contains(" "))
                coefficientsString += " ";
            array = coefficientsString.Split(' ');
            try
            {
                if (array.Length > 2)
                    throw new FormatException();
                A = Convert.ToDouble(array[0]);
                B = Convert.ToDouble(array[1]);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНедопустимый формат строки!");
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Линейное уравнение";
            Console.Write("Введите значения коэффициентов A и B линейного уравнения: ");
            if (LinearEquation.Parse(Console.ReadLine()))
                Console.WriteLine("\nУравнение имеет вид: ({0} * X) + ({1} * Y) = 0", LinearEquation.A, LinearEquation.B);
            Console.ReadKey();
        }
    }
}
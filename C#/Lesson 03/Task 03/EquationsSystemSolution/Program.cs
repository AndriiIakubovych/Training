using System;

namespace EquationsSystemSolution
{
    class Program
    {
        static void Solve(double A1, double B1, double C1, double A2, double B2, double C2, out double X, out double Y, out bool infinite)
        {
            X = Y = 0;
            infinite = false;
            if (A1 / A2 == B1 / B2 && A1 / A2 != C1 / C2)
                throw new ArgumentOutOfRangeException();
            if (A1 / A2 == B1 / B2 && A1 / A2 == C1 / C2)
                infinite = true;
            if (infinite)
                return;
            else
            {
                X = (B2 * C1 - B1 * C2) / (A1 * B2 - A2 * B1);
                Y = (A1 * C2 - A2 * C1) / (A1 * B2 - A2 * B1);
            }
        }

        static void Main(string[] args)
        {
            double A1, B1, C1, A2, B2, C2, X, Y;
            bool infinite;
            Console.Title = "Решение системы линейных уравнений";
            try
            {
                Console.Write("Введите значение коэффициента A1 первого линейного уравнения: ");
                A1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение коэффициента B1 первого линейного уравнения: ");
                B1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение свободного члена первого линейного уравнения: ");
                C1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение коэффициента A2 второго линейного уравнения: ");
                A2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение коэффициента B2 второго линейного уравнения: ");
                B2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение свободного члена второго линейного уравнения: ");
                C2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nСистема уравнений имеет вид:\n({0} * X) + ({1} * Y) = {2}\n({3} * X) + ({4} * Y) = {5}", A1, B1, C1, A2, B2, C2);
                Solve(A1, B1, C1, A2, B2, C2, out X, out Y, out infinite);
                if (infinite)
                    Console.WriteLine("\nСистема имеет бесконечное множество решений!");
                else
                    Console.WriteLine("\nНайденное решение: X = " + X + ", Y = " + Y);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nСистема не имеет решений!");
            }
            Console.ReadKey();
        }
    }
}
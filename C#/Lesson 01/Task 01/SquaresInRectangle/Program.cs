using System;

namespace SquaresInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B, C, valueSide, numberHorizontal = 0, numberVertical = 0, emptyHorizontal, emptyVertical;
            Console.Title = "Квадраты внутри прямоугольника";
            Console.Write("Введите длину прямоугольника A (см): ");
            A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину прямоугольника B (см): ");
            B = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите сторону квадрата C (см): ");
            C = Convert.ToInt32(Console.ReadLine());
            if (A > 0 && B > 0 && C > 0)
                if (A >= C && B >= C)
                {
                    valueSide = A;
                    while (valueSide >= C)
                    {
                        valueSide -= C;
                        numberHorizontal++;
                    }
                    emptyHorizontal = valueSide * B;
                    valueSide = B;
                    while (valueSide >= C)
                    {
                        valueSide -= C;
                        numberVertical++;
                    }
                    emptyVertical = C * numberHorizontal * valueSide;
                    Console.WriteLine("\nКоличество квадратов, размещённых в прямоугольнике: " + (numberHorizontal * numberVertical));
                    Console.WriteLine("Площадь незанятой части прямоугольника: " + (emptyHorizontal + emptyVertical) + " см кв.");
                }
                else
                    Console.WriteLine("\nВ прямоугольнике A * B нельзя разместить ни одного квадрата со стороной C!");
            else
                Console.WriteLine("\nЗначения чисел введены неверно!");
            Console.ReadKey();
        }
    }
}
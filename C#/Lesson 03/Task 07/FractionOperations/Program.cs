using System;

namespace FractionOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            double d = 1.5;
            Console.Title = "Простая дробь";
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            Fraction f3 = f + d;
            Console.WriteLine("f1 = {0}\nf2 = {1}\nf3 = {2}", f1, f2, f3);
            Console.ReadKey();
        }
    }
}
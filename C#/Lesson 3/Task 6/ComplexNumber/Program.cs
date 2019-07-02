using System;

namespace ComplexNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(1, 1);
            Complex z1;
            Console.Title = "Комплексное число";
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 = {0}", z1);
            Console.ReadKey();
        }
    }
}
using System;

namespace Deposit
{
    class Program
    {
        static void Main(string[] args)
        {
            double S = 1000, P;
            int K = 0;
            Console.Title = "Депозит";
            Console.Write("Введите значение процентов на вклад (0 < P < 25): ");
            P = Convert.ToInt32(Console.ReadLine());
            if (P > 0 && P < 25)
            {
                while (S <= 1100)
                {
                    S += S * P / 100;
                    K++;
                }
                Console.WriteLine("\nКоличество месяцев, по истечению которых размер вклада превысит 1100 грн.: " + K);
                Console.WriteLine("Итоговый размер вклада составит: " + S + " грн.");
            }
            else
                Console.WriteLine("\nЗначение процентов на вклад введено неверно!");
            Console.ReadKey();
        }
    }
}
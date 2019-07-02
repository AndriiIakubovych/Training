using System;

namespace ExchangeTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("Аваль", stock);
            Broker broker = new Broker("Виктор Иванов", stock);
            Console.Title = "Модель приложения \"Биржа\"";
            stock.Market();
            broker.StopTrade();
            stock.Market();
            Console.ReadKey();
        }
    }
}
using System;

namespace ExchangeTemplate
{
    class Bank : IObserver
    {
        IObservable stock;

        public string Name { get; set; }

        public Bank(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.RegisterObserver(this);
        }

        public void Update(object obj)
        {
            StockInfo stockInfo = (StockInfo)obj;
            if (stockInfo.Euro > 40)
                Console.WriteLine("Банк \"{0}\" продает евро. Курс евро: {1} грн.", Name, stockInfo.Euro);
            else
                Console.WriteLine("Банк \"{0}\" покупает евро. Курс евро: {1} грн.", Name, stockInfo.Euro);
        }
    }
}
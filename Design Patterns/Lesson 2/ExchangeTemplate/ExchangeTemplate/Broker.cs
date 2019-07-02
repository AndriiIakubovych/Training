using System;

namespace ExchangeTemplate
{
    class Broker : IObserver
    {
        IObservable stock;

        public string Name { get; set; }

        public Broker(string name, IObservable observable)
        {
            Name = name;
            stock = observable;
            stock.RegisterObserver(this);
        }

        public void Update(object obj)
        {
            StockInfo stockInfo = (StockInfo)obj;
            if (stockInfo.USD > 30)
                Console.WriteLine("Брокер \"{0}\" продает доллары. Курс доллара: {1} грн.", Name, stockInfo.USD);
            else
                Console.WriteLine("Брокер \"{0}\" покупает доллары. Курс доллара: {1} грн.", Name, stockInfo.USD);
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }
}
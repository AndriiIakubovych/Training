using System;
using System.Collections.Generic;

namespace ExchangeTemplate
{
    class Stock : IObservable
    {
        StockInfo stockInfo;
        List<IObserver> observers;

        public Stock()
        {
            stockInfo = new StockInfo();
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Update(stockInfo);
        }

        public void Market()
        {
            Random rnd = new Random();
            stockInfo.USD = rnd.Next(20, 40);
            stockInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }
}
namespace ExchangeTemplate
{
    interface IObservable
    {
        void RegisterObserver(IObserver observable);
        void RemoveObserver(IObserver observable);
        void NotifyObservers();
    }
}
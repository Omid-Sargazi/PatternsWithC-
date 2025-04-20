namespace MessageBroker.WithObserver
{
    public interface IStockPriceListener
    {
        void OnStockPriceChanged(string symbol, decimal price);
    }
}
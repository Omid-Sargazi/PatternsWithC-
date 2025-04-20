namespace MessageBroker.WithObserver
{
    public class DisplayBoardUpdater : IStockPriceListener
    {
        public void OnStockPriceChanged(string symbol, decimal price)
        {
            Console.WriteLine($"به‌روزرسانی تابلو نمایش برای سهام {symbol}: {price}");
        }
    }
}
namespace MessageBroker.WithObserver
{
    public class MobileAppNotifier : IStockPriceListener
    {
        public void OnStockPriceChanged(string symbol, decimal price)
        {
            Console.WriteLine($"به‌روزرسانی اپلیکیشن موبایل برای سهام {symbol}: {price}");
        }
    }
}
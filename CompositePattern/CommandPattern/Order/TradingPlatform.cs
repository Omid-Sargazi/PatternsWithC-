namespace CompositePattern.CommandPattern.TradeOrder
{
    public class TradingPlatform
    {
        public void ExecuteBuyOrder(string symbol, int quantity, decimal price)
        {
            Console.WriteLine($"Buying {quantity} of {symbol} at {price}");
        }
    }
}
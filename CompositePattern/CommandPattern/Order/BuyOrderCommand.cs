using CompositePattern.CommandPattern.TradeOrder;

namespace CompositePattern.CommandPattern.Order
{
    public class BuyOrderCommand : ICommand
    {
        private TradingPlatform _platform;
        private TradeOrder _order;
        public BuyOrderCommand(TradingPlatform platform, TradeOrder order)
        {
            _platform = platform;
            _order = order;
        }

        public bool CanExcecute()
        {
            return _order.Quantity > 0 && _order.Price > 0;
        }

        public void Execute()
        {
           if(CanExcecute())
           {
                 _platform.ExecuteBuyOrder(_order.Symbol, _order.Quantity, _order.Price);
           }
           else{
            Console.WriteLine("Invalid order!");
           }
        }
    }
}
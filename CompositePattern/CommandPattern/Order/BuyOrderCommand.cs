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
        public void Execute()
        {
            _platform.ExecuteBuyOrder(_order.Symbol, _order.Quantity, _order.Price);
        }
    }
}
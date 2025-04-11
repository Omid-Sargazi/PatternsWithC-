using CompositePattern.CommandPattern.TradeOrder;

namespace CompositePattern.CommandPattern.Order
{
    public class BuyOrderCommand : ICommand
    {
        private TradingPlatform _platform;
        private TradeOrder _order;
        private bool _exceuted;
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

        public void Undo()
        {
            if(_exceuted)
            {
                Console.WriteLine($"Undoing buy of {_order.Quantity} {_order.Symbol}");
                _exceuted = false;
            }
        }
    }
}
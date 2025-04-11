namespace CompositePattern.CommandPattern.Order
{
    public class TradeExecutor
    {
        private ICommand _command;
        public void setCommand(ICommand command)
        {
            _command = command;
        }
        public void ProcessOrder()
        {
            _command.Execute();
        }
    }
}
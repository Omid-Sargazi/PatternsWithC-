namespace CompositePattern.CommandPattern.Order
{
    public class TradeExecutor
    {
        private readonly Queue<ICommand> _orderQueue = new Queue<ICommand>();
        private readonly Stack<ICommand> _history = new Stack<ICommand>();
        public void AddToQueue(ICommand command)
        {
            _orderQueue.Enqueue(command);
        }
        private ICommand _command;
        public void setCommand(ICommand command)
        {
            _command = command;
        }
        public void ProcessOrder()
        {
           while(_orderQueue.Count>0)
           {
             var command = _orderQueue.Dequeue();
             if(command.CanExcecute())
             {
                command.Execute();
             }
           }
        }
    }
}
using System.Runtime.InteropServices;

namespace DesignPattern.CQRSPattern
{
    public class CreateOrderCommand
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public CreateOrderCommand(string ProductName, int quantity)
        {
            ProductName = ProductName;
            Quantity = quantity;
        }
    }

    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }

    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
    {
        public void Handle(CreateOrderCommand command)
        {
            Console.WriteLine($"Order created: {command.ProductName} x{command.Quantity}");
        }
    }

    public class SimpleMediator
    {
        private Dictionary<Type, Object> _handlers = new();

        public void Register<TCommand>(ICommandHandler<TCommand> handler)
        {
            _handlers[typeof(TCommand)] = handler;
        }

        public void Send<TCommand>(TCommand command)
        {
            if (_handlers.TryGetValue(typeof(TCommand), out var handlerObj))
            {
                var handler = (ICommandHandler<TCommand>)handlerObj;
                handler.Handle(command);
            }
        }
    }
}
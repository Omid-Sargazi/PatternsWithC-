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
}
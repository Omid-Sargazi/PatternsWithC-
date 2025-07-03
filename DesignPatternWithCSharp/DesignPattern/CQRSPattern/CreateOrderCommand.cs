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
}
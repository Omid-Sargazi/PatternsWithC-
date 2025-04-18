namespace MessageBroker.MessageBrokerExample
{
    public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string[] Products { get; set; }
}
}
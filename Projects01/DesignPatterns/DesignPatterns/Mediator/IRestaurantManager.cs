namespace DesignPatterns.Mediator
{
    public class Order
    {
        public int Id { get; }
        public string Description { get; }

        public Order(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
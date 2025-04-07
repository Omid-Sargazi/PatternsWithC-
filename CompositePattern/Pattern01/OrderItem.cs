namespace CompositePattern.Pattern01
{
    public abstract class OrderItem
    {
        public string Name {get; set;}
        public OrderItem(string name)
        {
            Name = name;
        }
        
        public abstract int GetPrice();
        public abstract double GetWeight();
        public abstract string GenerateInvoiceLine(int indentLevel = 0);
    }
}
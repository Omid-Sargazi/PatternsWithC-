namespace CompositePattern.Pattern01
{
    public class SimpleProduct 
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }

        public SimpleProduct(string name, int price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
       

        public decimal GetPrice()
        {
            return Price;
        }

    public double GetWeight()
        {
            return Weight;
        }

    public string GenerateInvoiceLine()
        {
            return $"{Name}: {Price:C}";
        }
    }
}
namespace CompositePattern.Pattern01
{
    public class SimpleProduct : OrderItem
    {
        public int Price { get; set; }
        public double Weight {get; set;}
        public SimpleProduct(string name, int price, double weight) : base(name)
        {
            Price = price;
            Weight = weight;
        }

        //     public string Name { get; set; }
        //     public int Price { get; set; }
        //     public double Weight { get; set; }

        //     public SimpleProduct(string name, int price, double weight)
        //     {
        //         Name = name;
        //         Price = price;
        //         Weight = weight;
        //     }


        //     public decimal GetPrice()
        //     {
        //         return Price;
        //     }

        // public double GetWeight()
        //     {
        //         return Weight;
        //     }

        // public string GenerateInvoiceLine()
        //     {
        //         return $"{Name}: {Price:C}";
        //     }
        public override string GenerateInvoiceLine(int indentLevel = 0)
        {
           return $"{new string(' ', indentLevel * 2)}{Name}: {Price:C}";
        }

        public override int GetPrice()
        {
            return Price;
        }

        public override double GetWeight()
        {
            return Weight;
        }
    }
}
namespace BehavioralPattern.VisitorCompositePattern
{
    public class Book
    {
        public string Name {get; set;}
        public double Price {get; set;}
        public double Discount {get; set;}

        public Book(string name, double price, double discount)
        {
            Name = name;
            Price = price;
            Discount = discount;
        }

        public double CalculateFinalPrice()
        {
            return Price *(1- Discount/100);
        }
    }

    public class Electronics
    {
        public string Name { get; }
        public double Price { get; }
        public double WarrantyCost { get; }

            public Electronics(string name, double price, double warrantyCost)
        {
            Name = name;
            Price = price;
            WarrantyCost = warrantyCost;
        }

        public double CalculateFinalPrice()
        {
            return Price + WarrantyCost;
        }
    }

    public class Clothing
    {
        public string Name { get; }
        public double Price { get; }
        public double ShippingCost { get; }

        public Clothing(string name, double price, double shippingCost)
        {
            Name = name;
            Price = price;
            ShippingCost = shippingCost;
        }

        public double CalculateFinalPrice()
        {
            return Price + ShippingCost;
        }
    }
}
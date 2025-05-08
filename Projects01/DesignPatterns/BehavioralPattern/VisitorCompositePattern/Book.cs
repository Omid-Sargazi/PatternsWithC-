using System.Security.Cryptography.X509Certificates;

namespace BehavioralPattern.VisitorCompositePattern
{
    public interface IProduct
    {
        string Name {get;}
        public double Price {get;}
    }
    public class Book : IProduct
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

    public class Electronics : IProduct
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

    public class Clothing :IProduct
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

    public class PriceCalculator
    {
        public double CalculateFinalPrice(IProduct product)
        {
            if(product is Book book)
            {
                return book.Price * (1/book.Discount/100);
            }
            else if(product is Electronics electronics)
            {
                return electronics.Price + electronics.WarrantyCost;
            }
            else if(product is Clothing clothing)
            {
               return clothing.Price + clothing.ShippingCost;
            }
            else
                throw new ArgumentException("Unknown product type");
        }
    }
}
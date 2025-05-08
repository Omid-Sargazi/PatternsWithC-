using System.Security.Cryptography.X509Certificates;

namespace BehavioralPattern.VisitorCompositePattern
{

    public interface IVisitorProducts
    {
        void Visit(Book book);
        void Visit(Clothing clothing);
        void Visit(Electronics electronics);
    }
    public interface IProduct
    {
        string Name {get;}
        public double Price {get;}
        void Accept(IVisitorProducts visitor);
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

        public void Accept(IVisitorProducts visitor)
        {
            visitor.Visit(this);
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

        public void Accept(IVisitorProducts visitor)
        {
            visitor.Visit(this);
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

        public void Accept(IVisitorProducts visitor)
        {
            visitor.Visit(this);
        }
    }

    // public class PriceCalculator
    // {
    //     public double CalculateFinalPrice(IProduct product)
    //     {
    //         if(product is Book book)
    //         {
    //             return book.Price * (1/book.Discount/100);
    //         }
    //         else if(product is Electronics electronics)
    //         {
    //             return electronics.Price + electronics.WarrantyCost;
    //         }
    //         else if(product is Clothing clothing)
    //         {
    //            return clothing.Price + clothing.ShippingCost;
    //         }
    //         else
    //             throw new ArgumentException("Unknown product type");
    //     }
    // }

    public class PriceCalculatorVisitor : IVisitorProducts
    {
        public double FinalPrice {get; private set;}
        public void Visit(Book book)
        {
            FinalPrice = book.Price * (1-book.Discount/100);
        }

        public void Visit(Clothing clothing)
        {
            FinalPrice = clothing.Price + clothing.ShippingCost;
        }

        public void Visit(Electronics electronics)
        {
            FinalPrice = electronics.Price + electronics.WarrantyCost;
        }
    }
}
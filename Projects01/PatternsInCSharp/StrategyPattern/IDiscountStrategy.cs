namespace PatternsInCSharp.StrategyPattern
{
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double price);
    }

    public class Percent20Discount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            return price * 0.8;
        }
    }

    public class Fixed5000Discount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            return price - 5000;
        }
    }

    public class Extra10Discount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            if (price > 100000)
                 return price * 0.9; // 10 درصد تخفیف اضافی
            return price;
        }
    }

    public class Product
    {
        public string Name {get; set;}
        public double Price {get; set;}
        private IDiscountStrategy _discountStrategy;
        public Product(string name, double price, IDiscountStrategy discountStrategy)
        {
            Name = name;
            Price = price;
            _discountStrategy = discountStrategy;
        }

        public double CalculateFinalPrice()
        {
            return _discountStrategy.ApplyDiscount(Price);
        }
    }
}
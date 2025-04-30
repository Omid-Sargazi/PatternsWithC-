namespace PatternsInCSharp.DecoratorPattern
{
    public interface ICoffee
    {
        string GetDescription();
        decimal GetCost();
    }
    public class Espresso : ICoffee
    {
        public decimal GetCost()
        {
            return 2.50m;
        }

        public string GetDescription()
        {
            return "Espresso";
        }
    }
    public class Americano : ICoffee
    {
        public decimal GetCost()
        {
            return 3.00m;
        }

        public string GetDescription()
        {
            return "Americano";
        }
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public abstract decimal GetCost();

        public abstract string GetDescription();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.50m;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }
        
    }

    public class ChocolateDecorator : CoffeeDecorator
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 5.00m;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Chocolate";
        }
    }
}
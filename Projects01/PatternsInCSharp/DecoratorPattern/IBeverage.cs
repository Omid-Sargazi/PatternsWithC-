namespace PatternsInCSharp.DecoratorPattern
{
    public interface IBeverage
    {
        string GetDescription();
        double GetCost();
        double GetTime();
    }

    public class SimpleCoffee : IBeverage
    {
        public double GetCost()
        {
            return 1.00;
        }

        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetTime()
        {
            return 5.0; // Time in minutes
        }
    }

    public class SimpleTea : IBeverage
    {
        public double GetCost()
        {
            return 0.75;
        }

        public string GetDescription()
        {
            return "Simple Tea";
        }

        public double GetTime()
        {
            return 3.0; // Time in minutes
        }
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;
        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }
        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }

        public virtual string GetDescription()
        {
            throw new NotImplementedException();
        }

        public virtual double GetTime()
        {
            throw new NotImplementedException();
        }
    }

    public class MilkDecoratorr : BeverageDecorator
    {
        public MilkDecoratorr(IBeverage beverage) : base(beverage)
        {
        }

        public override double GetCost()
        {
            return _beverage.GetCost() + 0.50;
        }
        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Milk";
        }

        public override double GetTime()
        {
            return _beverage.GetTime() + 1.0; // Adding 1 minute for milk
        }

    }

    public class SugarDecorator : BeverageDecorator
    {
        public SugarDecorator(IBeverage beverage) : base(beverage)
        {
        }
        public override double GetCost()
        {
            return _beverage.GetCost() + 0.25;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Sugar";
        }

        public override double GetTime()
        {
            return _beverage.GetTime() + 0.5; // Adding 0.5 minutes for sugar
        }
    }
}
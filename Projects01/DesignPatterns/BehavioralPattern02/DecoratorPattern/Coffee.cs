namespace BehavioralPattern02.DecoratorPattern
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
    public class SimpleCoffee : ICoffee
    {
        public double GetCost()
        {
            return 2.0;
        }

        public string GetDescription()
        {
            return "Plain Coffee";
        }
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public virtual double GetCost()=>_coffee.GetCost();

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }
    }



    public class CoffeeWithMilk : CoffeeDecorator
    {
        public CoffeeWithMilk(ICoffee coffee) : base(coffee)
        {
        }
        
        public override string GetDescription()=>base.GetDescription()+"Milk";
        public override double GetCost()
        {
            return base.GetCost();
        }
    }

    public class CoffeeWithSugar : CoffeeDecorator
    {
        public CoffeeWithSugar(ICoffee coffee) : base(coffee)
        {
        }
        public override string GetDescription()
        {
            return base.GetDescription() + "Sugar";
        }
        public override double GetCost()
        {
            return base.GetCost() + 2.06;
        }
    }

    public class CoffeeWithMilkAndSugar : CoffeeDecorator
    {
        public CoffeeWithMilkAndSugar(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return "Coffee with Milk and Sugar";
        }
        public override double GetCost()
        {
            return 2.8;
        }
    }
}
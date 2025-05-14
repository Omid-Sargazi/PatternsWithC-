namespace BehavioralPattern02.DecoratorPattern
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
    public class Coffee
    {
        public virtual string GetDescription() => "Plain Coffee";
        public virtual double GetCost() => 2.0;
    }

    public class CoffeeWithMilk : Coffee
    {
        public override string GetDescription()
        {
            return "Coffee with Milk";
        }

        public override double GetCost()
        {
            return 2.5;
        }
    }

    public class CoffeeWithSugar  :Coffee
    {
        public override string GetDescription()
        {
            return "Coffee with Sugar";
        }
        public override double GetCost()=>2.3;
    }

    public class CoffeeWithMilkAndSugar : Coffee
    {
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
namespace CompositePattern.DecoratorPattern.WithoutPattern
{
   public class PlainCoffee
   {
        public string GetDescription()=> "Plain Coffee";
        public double GetCoast()=> 1.00;
   }

   public class CoffeeWithSugar()
   {
        public string GetDescription() => "Plain Coffee with Sugar";
         public double GetCost() => 2.5;
    }
    public class CoffeeWithMilk
{
    public string GetDescription() => "Plain Coffee with Milk";
    public double GetCost() => 3.0;
}
public class CoffeeWithMilkAndSugar
{
    public string GetDescription() => "Plain Coffee with Milk and Sugar";
    public double GetCost() => 3.5;
}
   
}
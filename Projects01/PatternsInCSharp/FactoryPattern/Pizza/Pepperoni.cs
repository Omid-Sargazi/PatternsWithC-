namespace PatternsInCSharp.FactoryPattern.Pizza
{
    public class Pepperoni : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking Pepperoni pizza...");
        }

        public void Prepare()
        {
            
            Console.WriteLine("Preparing Pepperoni pizza...");
        }
    }
}
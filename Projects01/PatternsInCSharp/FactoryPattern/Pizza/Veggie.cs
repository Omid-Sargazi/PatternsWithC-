namespace PatternsInCSharp.FactoryPattern.Pizza
{
    public class Veggie : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking Veggie pizza...");
        }

        public void Prepare()
        {
            Console.WriteLine("Preparing Veggie pizza...");
        }
    }
}
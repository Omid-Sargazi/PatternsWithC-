namespace PatternsInCSharp.FactoryPattern.Pizza
{
    public class Margherita : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("Baking Margherita pizza...");
        }

        public void Prepare()
        {
            Console.WriteLine("Preparing Margherita pizza...");
        }
    }
}
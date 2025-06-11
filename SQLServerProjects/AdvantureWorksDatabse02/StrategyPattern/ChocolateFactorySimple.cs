namespace AdvantureWorksDatabse02.StrategyPattern
{
    public class ChocolateFactorySimple
    {

        public void ProcessChocolate()
        {
            var chocolates = new List<string> { "A", "B", "C", "D" };
            var AChocolate = new List<string>();
            foreach (var chocolate in chocolates)
            {
                if (chocolate.Contains("A"))
                    AChocolate.Add(chocolate);
            }
        }
    }
}
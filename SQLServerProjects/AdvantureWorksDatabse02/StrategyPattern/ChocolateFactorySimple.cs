using Microsoft.VisualBasic;

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

    public class ChocolateFactoryMessy
    {
        public List<string> ProcessChocolates(List<string> chocolates, string operation)
        {
            if (operation == "only-A")
            {
                return chocolates.Where(c => c.Contains("A")).ToList();
            }

            else if (operation == "only-B")
                return chocolates.Where(c => c.Contains("B")).ToList();

            else if (operation.Contains("make-uppercase"))
                return chocolates.Select(c => c.ToUpper()).ToList();

            return chocolates;
        }

        public class ChocolateFactorySmart
        {
            public delegate IEnumerable<string> ChocolateProcessor(IEnumerable<string> chocolates);
            public void ChocolateFactory()
            {
                var chocolates = new List<string> { "تلخ", "شیری", "سفید", "کاکائویی", "نارگیلی" };

                ChocolateProcessor filterMilky = chocs => chocs.Where(c => c.Contains(""));

                ChocolateProcessor addPremium = chocs => chocs.Select(c => "premium" + c);

                ChocolateProcessor makeUpper = chocs => chocs.Select(c => c.ToUpper());

                var result01 = ProcessChocolate(chocolates, addPremium);
            }

            public static IEnumerable<string> ProcessChocolate(IEnumerable<string> chocolates, ChocolateProcessor
             processor)
            {
                return processor(chocolates);
             }
        }
    }
}
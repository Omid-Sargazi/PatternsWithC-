namespace PatternsInCSharp.AbstractFactory.Furniture
{
    public class ModernCoffeeTable : ICoffeeTable
    {
        public string GetMaterial()
        {
            return "Modern Coffee Table";
        }
    }
}
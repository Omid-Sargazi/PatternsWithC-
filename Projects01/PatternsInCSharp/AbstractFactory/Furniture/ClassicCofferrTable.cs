namespace PatternsInCSharp.AbstractFactory.Furniture
{
    public class ClassicCoffeeTable : ICoffeeTable
    {
        public string GetMaterial()
        {
            return "Classic Coffee Table";
        }
    }
}
namespace PatternsInCSharp.AbstractFactory.Furniture
{
    public class ModernFactory : IFurnitureFactory
    {
        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }

        public ICoffeeTable CreateCoffeeTable()
        {
            return new ModernCoffeeTable();
        }

        public ICabinet CreateCabinet()
        {
            return new ModernCabinet();
        }
    }
}
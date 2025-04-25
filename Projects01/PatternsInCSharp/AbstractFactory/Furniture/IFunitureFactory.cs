namespace PatternsInCSharp.AbstractFactory.Furniture
{
    public interface IFurnitureFactory
    {
        ISofa CreateSofa();
        ICoffeeTable CreateCoffeeTable();
        ICabinet CreateCabinet();
    }
}
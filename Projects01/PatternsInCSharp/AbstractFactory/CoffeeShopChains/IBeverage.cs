namespace PatternsInCSharp.AbstractFactory.CoffeeShopChains
{
    public interface IBeverage 
    {
        string GetName();
    }
    public interface IDessert 
    {
        string GetDescription();
    }

    public interface ISnake
    {
        string GetType();
    }
}
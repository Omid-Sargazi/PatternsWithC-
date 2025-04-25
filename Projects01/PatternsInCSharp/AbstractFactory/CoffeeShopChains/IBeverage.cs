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

    public class Espresso : IBeverage
    {
        public string GetName()
        {
            return "Espresso";
        }
    }
    public class Tramisso : IDessert
    {
        public string GetDescription()
        {
            return "Tramisso";
        }
    }

    public class Panini : ISnake
    {
        string ISnake.GetType()
        {
            return "Panini";
        }
    }

    public class Matcha : IBeverage
    {
        public string GetName()
        {
            return "Matcha Tea";
        }
    }

    public class Mochi : IDessert
    {
        public string GetDescription()
        {
            return "Sweet rice cake";
        }
    }

    public class Onigiri : ISnake
    {
        string ISnake.GetType()
        {
            return "Onigiri";
        }
    }

    public interface ICoffeeShopFactory
    {
        IBeverage CreateBeverage();
        IDessert CreateDessert();
        ISnake CreateSnake();
    }

    public class ItalianCoffeeShopFactory : ICoffeeShopFactory
    {
        public IBeverage CreateBeverage()
        {
            return new Espresso();
        }

        public IDessert CreateDessert()
        {
           return new Tramisso();
        }

        public ISnake CreateSnake()
        {
            return new Panini();
        }
    }

    public class JapaneseCoffeeShopFactory : ICoffeeShopFactory
    {
        public IBeverage CreateBeverage()
        {
            return new Matcha();
        }

        public IDessert CreateDessert()
        {
            return new Mochi();
        }

        public ISnake CreateSnake()
        {
            return new Onigiri();
        }
    }

    public class Menu
    {
        private readonly ICoffeeShopFactory _factory;
        public Menu(ICoffeeShopFactory factory)
        {
            _factory = factory;
        }

        public string DisplayMenu()
        {
            var beverage = _factory.CreateBeverage();
            var desert = _factory.CreateDessert();
            var snake = _factory.CreateSnake();

            return $"beverage: {beverage},desert: {desert}, snake:{snake}";
        }
    }
}
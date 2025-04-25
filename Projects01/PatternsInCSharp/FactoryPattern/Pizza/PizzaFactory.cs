namespace PatternsInCSharp.FactoryPattern.Pizza
{
    public class PizzaFactory
    {
        public IPizza CreatePizza(PizzaType type)
        {
            return type switch
            {
                PizzaType.Margherita => new Margherita(),
                PizzaType.Pepperoni => new Pepperoni(),
                PizzaType.Veggie => new Veggie(),
                _=>throw new ArgumentException("Invalid pizza type")
            };
        }
    }
}
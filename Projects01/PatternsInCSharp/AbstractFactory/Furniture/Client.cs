namespace PatternsInCSharp.AbstractFactory.Furniture
{
    public class Client
    {
        private readonly IFurnitureFactory _factory;
        public Client(IFurnitureFactory factory)
        {
            _factory = factory;
        }

        public void Run()
        {
            var sofa = _factory.CreateSofa();
            var coffeeTable = _factory.CreateCoffeeTable();
            var cabinet = _factory.CreateCabinet();

            Console.WriteLine($"Sofa: {sofa.GetDesign()}");
            Console.WriteLine($"Coffee Table: {coffeeTable.GetMaterial()}");
            Console.WriteLine($"Cabinet: {cabinet.GetStyle()}");
        }
    }
}
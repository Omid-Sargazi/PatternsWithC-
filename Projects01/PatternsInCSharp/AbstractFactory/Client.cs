namespace PatternsInCSharp.AbstractFactory
{
   public class Client
   {
        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            productA.UsefulFunctionA();
            productB.UsefulFunctionA();
        }
   }
}
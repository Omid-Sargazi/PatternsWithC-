namespace PatternsInCSharp.AbstractFactory.Furniture
{
   public class ClassicFactory : IFurnitureFactory
   {
      public ICabinet CreateCabinet()
      {
         return new ClassicCabinet();
      }

      public ICoffeeTable CreateCoffeeTable()
      {
         return new ClassicCoffeeTable();
      }

      public ISofa CreateSofa()
      {
         return new ClassicSofa();
      }
   }
}
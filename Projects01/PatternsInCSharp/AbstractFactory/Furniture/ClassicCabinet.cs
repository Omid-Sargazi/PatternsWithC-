namespace PatternsInCSharp.AbstractFactory.Furniture
{
   public class ClassicCabinet : ICabinet
   {
      public string GetStyle()
      {
         return "Classic Cabinet";
      }
   }
}
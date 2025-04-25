namespace PatternsInCSharp.AbstractFactory
{
   public interface IAbstractFactory
   {
      IAbstractProductA CreateProductA();
      IAbstractProductB CreateProductB();
   }
}
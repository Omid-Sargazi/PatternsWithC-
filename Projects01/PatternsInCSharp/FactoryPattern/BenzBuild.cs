namespace PatternsInCSharp.FactoryPattern
{
    public class BenzBuild : IBuild
    {
        public void Build()
        {
            Console.WriteLine("Benz Build");
        }
    }
}
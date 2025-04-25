namespace PatternsInCSharp.FactoryPattern
{
    public class BMWBuild : IBuild
    {
        public void Build()
        {
            Console.WriteLine("BMW Build");
        }
    }
}
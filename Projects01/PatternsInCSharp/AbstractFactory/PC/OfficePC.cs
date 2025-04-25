namespace PatternsInCSharp.AbstractFactory.PC
{
    public class OfficePC : IOfficePC
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling Office PC");
            // Add assembly logic here
        }

        public void Test()
        {
            Console.WriteLine("Testing Office PC");
            // Add testing logic here
        }
    }
}
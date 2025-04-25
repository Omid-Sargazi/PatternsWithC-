namespace PatternsInCSharp.AbstractFactory.PC
{
    public class GamingPC : IGamingPC
    {
        public void Assemble()
        {
            Console.WriteLine("Assembling Gaming PC");
        }

        public void Test()
        {
            Console.WriteLine("Testing Gaming PC");
        }
    }
}
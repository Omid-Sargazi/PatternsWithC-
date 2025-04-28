namespace PatternsInCSharp02.BridgePattern
{
    public interface IAccessMode
    {
        void Access(string title, string memberName);
        void Return(string title);
    }

    public class PhysicalAccess : IAccessMode
    {
        public void Access(string title, string memberName)
        {
           Console.WriteLine($"{memberName} has borrowed the printed book '{title}'.");
        }

        public void Return(string title)
        {
            Console.WriteLine($"The printed book '{title}' has been returned.");
        }
    }
}
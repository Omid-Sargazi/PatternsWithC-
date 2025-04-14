namespace Patterns.RemoteController
{
    public class Fan : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Fan is turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Fan is turned off.");
        }
    }
}
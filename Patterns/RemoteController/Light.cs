namespace Patterns.RemoteController
{
    public class Light : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is turned off.");
        }
    }
}
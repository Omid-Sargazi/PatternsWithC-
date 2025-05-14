namespace BehavioralPattern02.BridgePattern
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }
    public class Tv : IDevice
    {
        public void TurnOn()=>Console.WriteLine("TV is ON");
        public void TurnOff() => Console.WriteLine("TV is Off");
    }

    public class Radio : IDevice
    {
         public void TurnOn() => Console.WriteLine("Radio is ON");

       public void TurnOff() => Console.WriteLine("Radio is OFF");
    }

    public class Remote
    {
        private IDevice _device;
        public Remote(IDevice device)
        {
            _device = device;
        }
        
        public void TogglePower()
        {
             Console.WriteLine("Using Remote to toggle power.");
           _device.TurnOn();
        }
    }
}
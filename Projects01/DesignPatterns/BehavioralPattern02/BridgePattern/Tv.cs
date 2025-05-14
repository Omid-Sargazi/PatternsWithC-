namespace BehavioralPattern02.BridgePattern
{
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int percent);
        void Mute();
    }
    public class Tv : IDevice
    {
        public void TurnOn()=>Console.WriteLine("TV is ON");
        public void TurnOff() => Console.WriteLine("TV is Off");

        public void SetVolume(int percent) => Console.WriteLine($"TV volume set to {percent}%");

       public void Mute() => Console.WriteLine("TV muted");
    }

    public class Radio : IDevice
    {
         public void TurnOn() => Console.WriteLine("Radio is ON");

       public void TurnOff() => Console.WriteLine("Radio is OFF");

        public void Mute() => Console.WriteLine("Radio muted");

        public void SetVolume(int percent) => Console.WriteLine($"Radio volume set to {percent}%");
    }

    public class Remote
    {
        protected IDevice _device;
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

    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            Console.WriteLine("Advanced remote muting device...");
            _device.Mute();
        }

        public void SetVolume(int percent)
        {
            Console.WriteLine($"Advanced remote setting volume to {percent}%...");
             _device.SetVolume(percent);
        }
    }
}
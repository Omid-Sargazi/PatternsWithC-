using System.Formats.Tar;

namespace DesignPattern.BridgePattern
{
    public interface ITelevision
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int channel);
    }

    public class SonyTV : ITelevision
    {
        public void SetChannel(int channel)
        {
            Console.WriteLine($"Sony TV channel set to {channel}");
        }

        public void TurnOff()
        {
            Console.WriteLine("Sony TV is now OFF");
        }

        public void TurnOn()
        {
            Console.WriteLine("Sony TV is now ON");
        }
    }

    public class LGTV : ITelevision
    {
        public void SetChannel(int channel)
        {
            Console.WriteLine($"LG TV channel set to {channel}");
        }

        public void TurnOff()
        {
            Console.WriteLine("LG TV is now OFF");
        }

        public void TurnOn()
        {
            Console.WriteLine("LG TV is now ON");
        }
    }

    public abstract class Remote
    {
        protected readonly ITelevision _television;
        public Remote(ITelevision television)
        {
            _television = television;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetChannel(int channel);
    }

    public class BasicRemote : Remote
    {
        public BasicRemote(ITelevision television) : base(television)
        {
        }

        public override void SetChannel(int channel)
        {
            _television.SetChannel(channel);
        }

        public override void TurnOff()
        {
            _television.TurnOff();
        }

        public override void TurnOn()
        {
            _television.TurnOn();
        }
    }

    public class SmartRemote : Remote
    {
        public SmartRemote(ITelevision television) : base(television)
        {
        }

        public override void SetChannel(int channel)
        {
            Console.WriteLine($"[Voice] Set channel to {channel}");
            _television.SetChannel(channel);
        }

        public override void TurnOff()
        {
            Console.WriteLine("[Voice] Turning TV off...");
            _television.TurnOff();
        }

        public override void TurnOn()
        {
            Console.WriteLine("[Voice] Turning TV on...");
            _television.TurnOn();
        }

        public void Mute()
        {
            Console.WriteLine("TV is now muted (simulated)");
        }
    }
}
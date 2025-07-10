namespace DesignPattern.Mediator
{
    public interface ISmartHomeMediator
    {
        void Notify(object sender, string evt);
    }

    public class Light
    {
        public void TurnOn() => Console.WriteLine("Light turned ON");
        public void TurnOff() => Console.WriteLine("Light turned ON");
    }

    public class Thermostat
    {
        public void TurnOn() => Console.WriteLine("🌡️ Thermostat turned ON");
        public void TurnOff() => Console.WriteLine("🌡️ Thermostat turned OFF");
    }

    public class DoorLock
    {
        private ISmartHomeMediator _mediator;
        public DoorLock(ISmartHomeMediator mediator)
        {
            _mediator = mediator;
        }

        public void Lock()
        {
            Console.WriteLine("🔒 Door is now locked");
            _mediator.Notify(this, "DoorLocked");
        }

        public void Unlock()
        {
            Console.WriteLine("🔓 Door is now unlocked");
            _mediator.Notify(this, "DoorUnlocked");
        }
    }

    public class SmartHomeController : ISmartHomeMediator
    {
        public void Notify(object sender, string evt)
        {
            throw new NotImplementedException();
        }
    }
}
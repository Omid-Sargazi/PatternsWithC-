namespace PatternsInCSharp.MediatorPattern
{
    public interface IHomeMediator
    {
        void RegisterDevice(SmartDevice device);
        void Notify(SmartDevice device, string eventCode);
    }



    public abstract class SmartDevice
    {
        protected IHomeMediator _mediator;
        public string Name { get; }
        public SmartDevice(string name, IHomeMediator mediator)
        {
            _mediator = mediator;
            Name = name;
        }

        public void Send(string eventCode)
        {
            _mediator.Notify(this, eventCode);
        }

        public abstract void Receive(string message);
    }

    public class SmartHomeHub : IHomeMediator
    {
        private readonly List<SmartDevice> _devices = new();

        public void RegisterDevice(SmartDevice device)
        {
            if (!_devices.Contains(device))
                _devices.Add(device);
        }
        public void Notify(SmartDevice sender, string eventCode)
        {
            Console.WriteLine($"[Hub] {sender.Name} sent event '{eventCode}'");
            switch (eventCode)
            {
                case "DoorOpened":
                    // e.g., turn on lights and adjust thermostat
                    foreach (var d in _devices.Where(d => d != sender))
                    {
                        if (d is Light) d.Receive("TurnOn");
                        if (d is Thermostat) d.Receive("SetComfortMode");
                    }
                    break;

                case "TemperatureHigh":
                    // e.g., turn on AC via Thermostat
                    foreach (var d in _devices.Where(d => d != sender && d is Thermostat))
                        d.Receive("CoolDown");
                    break;

                // add more cases as needed

                default:
                    Console.WriteLine($"[Hub] No handling for '{eventCode}'");
                    break;
            }
        }


    }

    public class Light : SmartDevice
    {
        public Light(string name, IHomeMediator mediator) : base(name, mediator)
        {
        }

        public override void Receive(string message)
        {
            if (message == "TurnOn")
                Console.WriteLine($"[{Name}] Light is now ON.");
            else if (message == "TurnOff")
                Console.WriteLine($"[{Name}] Light is now OFF.");
        }
    }

    public class Thermostat : SmartDevice
    {
        public Thermostat(string name, IHomeMediator mediator) : base(name, mediator)
        {
        }

        public override void Receive(string message)
        {
            if (message == "SetComfortMode")
                Console.WriteLine($"[{Name}] Thermostat set to COMFORT mode.");
            else if (message == "CoolDown")
                Console.WriteLine($"[{Name}] Cooling down to lower temperature.");
        }
    }

    public class DoorSensor : SmartDevice
    {
        public DoorSensor(string name, IHomeMediator mediator) : base(name, mediator)
        {
        }
        public void OpenDoor()
    {
        Console.WriteLine($"[{Name}] Door was opened!");
        Send("DoorOpened");
    }

        public override void Receive(string message)
        {
            Console.WriteLine($"[{Name}] (ignored message '{message}')");
        }
    }
}
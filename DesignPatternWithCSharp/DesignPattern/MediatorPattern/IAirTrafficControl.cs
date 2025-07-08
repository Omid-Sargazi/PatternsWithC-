namespace DesignPattern.MediatorPattern
{
    public interface IAirTrafficControl
    {
        void RegisterAircraft(Aircraft aircraft);
        void SendMessage(string message, Aircraft aircraft);
    }

    public class ControlTower : IAirTrafficControl
    {
        private List<Aircraft> _aircraft = new List<Aircraft>();
        public void RegisterAircraft(Aircraft aircraft)
        {
            _aircraft.Add(aircraft);
        }

        public void SendMessage(string message, Aircraft aircraft)
        {
            foreach (var air in _aircraft)
            {
                if (air != aircraft)
                {
                    air.ReceiveMessage(message);
                }
            }
        }
    }

    public class Aircraft
    {
        private readonly IAirTrafficControl _controlTower;
        public string CallSign { get; }

        public Aircraft(string callSign, IAirTrafficControl controlTower)
        {
            CallSign = callSign;
            _controlTower = controlTower;
            _controlTower.RegisterAircraft(this);
        }

        public void RequestLanding()
        {
            Console.WriteLine($"{CallSign} requesting landing.");
            _controlTower.SendMessage($"{CallSign} is requesting landing.", this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{CallSign} received {message}");
        }
    }
}
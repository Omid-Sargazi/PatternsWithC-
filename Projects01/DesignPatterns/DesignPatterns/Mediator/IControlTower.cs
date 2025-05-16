namespace DesignPatterns.Mediator
{
    public interface IControlTower
    {
        void RegisterAirPlane(Airplane airplane);
        void RequestLanding(Airplane requester);
    }

    public class ControlTower : IControlTower
    {
        private List<Airplane> _airplanes = new List<Airplane>();

        public void RegisterAirPlane(Airplane airplane)
        {
            _airplanes.Add(airplane);
        }

        public void RequestLanding(Airplane requester)
        {
            Console.WriteLine($"{requester.Name} requests landing.");
            foreach(var plane in _airplanes)
            {
                plane.ReceiveNotification($"{requester.Name} is requesting landing.");
            }
         Console.WriteLine($"Control Tower approves landing for {requester.Name}.");
        }
    }

    public class Airplane
    {
        private IControlTower _controlTower;
        private string _name;
        public string Name => _name;
        public Airplane(string name)
        {
            _name = name;
        }
        public void SetControlTower(IControlTower controlTower)
        {
            _controlTower = controlTower;
        }

        public void RequestLanding()
        {
            _controlTower.RegisterAirPlane(this);
        }

        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"{_name} received: {message}");
        }
        
    }
}
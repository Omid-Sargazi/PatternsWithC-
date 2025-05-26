namespace CommandPattern.MediatorPattern
{
    public interface IControlTower
    {
        void RegisterAirplane(Airplane airplane);
        void SendMessgae(string message, Airplane sender);
        void RequestAltitudeChange(Airplane airplane, int newAltitude);
    }

    public class ControlTower : IControlTower
    {
        private readonly List<Airplane> _airplanes = new List<Airplane>();
        public void RegisterAirplane(Airplane airplane)
        {
            _airplanes.Add(airplane);
            Console.WriteLine($"Airplane {airplane.Id} registered with control tower.");
        }

        public void RequestAltitudeChange(Airplane airplane, int newAltitude)
        {
            bool isSafe = true;
            foreach (var otherPlane in _airplanes)
            {
                if (otherPlane != airplane && Math.Abs(otherPlane.Altitude - newAltitude) < 1000) ;
                if (isSafe)
            {
                airplane.UpdateAltitude(newAltitude);
                Console.WriteLine($"Control Tower approved altitude change for {airplane.Id} to {newAltitude} feet.");
            }
            else
            {
                Console.WriteLine($"Control Tower denied altitude change for {airplane.Id} due to potential collision.");
            }
            }
        }

        public void SendMessgae(string message, Airplane sender)
        {
            throw new NotImplementedException();
        }
    }

    public class Airplane
    {
        public string Id { get; }
        public int Altitude { get; private set; }
        private IControlTower controlTower;
        public Airplane(string id, int initialAltitude, IControlTower controlTower)
        {
            Id = id;
            Altitude = initialAltitude;
            this.controlTower = controlTower;
        }
            public void SendMessage(string message)
        {
            Console.WriteLine($"{Id} sends: {message}");
            controlTower.SendMessgae(message, this);
        }

        public void ReceiveMessage(string message, Airplane sender)
        {
            Console.WriteLine($"{Id} received from {sender.Id}: {message}");
        }

        public void RequestAltitudeChange(int newAltitude)
        {
            Console.WriteLine($"{Id} requesting altitude change to {newAltitude} feet.");
            controlTower.RequestAltitudeChange(this, newAltitude);
        }

        public void UpdateAltitude(int newAltitude)
        {
            Altitude = newAltitude;
        }
    }
}
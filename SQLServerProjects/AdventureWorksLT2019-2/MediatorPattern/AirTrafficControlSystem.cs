namespace AdventureWorksLT2019_2.MediatorPattern
{
    public interface IAirTrafficControl
    {
        void Register(AirPlane airPlane);
        void SendWarning(string message, AirPlane airPlane);
    }


    public class AirTrafficControl : IAirTrafficControl
    {
        private List<AirPlane> _airPlanes = new List<AirPlane>();
        public void Register(AirPlane airplane)
        {
            _airPlanes.Add(airplane);
            Console.WriteLine($"[ATC] {airplane._name} has entered controlled airspace.");
        }

        public void SendWarning(string message, AirPlane airPlane)
        {
            Console.WriteLine($"[ATC] Alert from {airPlane._name}: {message}");
            foreach (var airplane in _airPlanes)
            {
                if (airplane != airPlane)
                {
                    airPlane.ReceiveWarning(message);
                }
            }
        }
    }


    public class AirPlane
    {
        private IAirTrafficControl _airTrafficControl;
        public string _name;

        public AirPlane(IAirTrafficControl airTrafficControl, string name)
        {
            _airTrafficControl = airTrafficControl;
            _name = name;
            _airTrafficControl.Register(this);
        }
       

        public void SendWarning(string message)
        {
            Console.WriteLine($"{_name} sends warning: {message}");
            _airTrafficControl.SendWarning(message, this);
        }

        public void ReceiveWarning(string message)
        {
            Console.WriteLine($"{_name} received warning: {message}");
        }


    }

}
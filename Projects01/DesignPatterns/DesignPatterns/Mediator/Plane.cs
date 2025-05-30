namespace DesignPatterns.Mediator
{
    public class Plane
    {
        public string CallSign {get; set;}
        private IControlTowerr _tower;
        public Plane(string callSign, IControlTowerr tower)
        {
            CallSign = callSign;
            _tower = tower;
            (_tower as ControlTowerr)?.RegisterPlane(this);
        }
         public void RequestLanding()
        {
            Console.WriteLine($"{CallSign}: Requesting to land...");
            _tower.RequestLanding(this);
        }
        public void Land(Plane otherPlane)
        {
            Console.WriteLine($"{CallSign} requesting to land. Checking with {otherPlane.CallSign}...");
        }

    }

    public interface IControlTowerr
    {
         void RequestLanding(Plane plane);
    }

    public class ControlTowerr
    {
         private List<Plane> _planesInAir = new();

    public void RegisterPlane(Plane plane)
    {
        _planesInAir.Add(plane);
    }

    public void RequestLanding(Plane plane)
    {
        if (_planesInAir.Count == 0 || _planesInAir[0] == plane)
        {
            Console.WriteLine($"[Tower] {plane.CallSign} cleared to land.");
            _planesInAir.Remove(plane);
        }
        else
        {
            Console.WriteLine($"[Tower] {plane.CallSign}, hold position. Runway busy.");
        }
    }
    }
}
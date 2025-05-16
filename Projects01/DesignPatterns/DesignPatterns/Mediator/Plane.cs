namespace DesignPatterns.Mediator
{
    public class Plane
    {
        public string CallSign {get; set;}
        public Plane(string callSign)
        {
            CallSign = callSign;
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
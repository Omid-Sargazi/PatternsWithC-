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
}
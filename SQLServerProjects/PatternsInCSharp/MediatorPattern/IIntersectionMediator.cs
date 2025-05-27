namespace PatternsInCSharp.MediatorPattern
{
    public enum Direction
    {
        NorthSouth,
        EastWest
    }

    public enum Crossing
    {
        NorthSouth,
        EastWest
    }
    public interface IIntersectionMediator
    {
        void RegisterComponent(IntersectionComponent component);
        void Notify(IntersectionComponent component, string eventCode);
    }

    public abstract class IntersectionComponent
    {
        protected readonly IIntersectionMediator _mediator;
        public string Name;
        public IntersectionComponent(string name, IIntersectionMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.RegisterComponent(this);
        }

        public void Send(string eventCode)
        {
            _mediator.Notify(this, eventCode);
        }

        public abstract void Receive(string message);

    }

    public class IntersectionController : IIntersectionMediator
    {
        private readonly List<IntersectionComponent> _components = new();

        public void Notify(IntersectionComponent sender, string eventCode)
        {
            Console.WriteLine($"[Controller] Received '{eventCode}' from {sender.Name}");
            switch (eventCode)
            {
                // North–South green cycle ended
                case "NSGreenElapsed":
                    // Turn NS red, EW green
                    foreach (var c in _components)
                    {
                        if (c is TrafficLight tl)
                        {
                            if (tl.Direction == Direction.NorthSouth)
                                tl.Receive("TurnRed");
                            else if (tl.Direction == Direction.EastWest)
                                tl.Receive("TurnGreen");
                        }
                        if (c is PedestrianSignal ps && ps.Crossing == Crossing.EastWest)
                            ps.Receive("Walk");
                    }
                    break;

                // East–West green cycle ended
                case "EWGreenElapsed":
                    // Turn EW red, NS green
                    foreach (var c in _components)
                    {
                        if (c is TrafficLight tl)
                        {
                            if (tl.Direction == Direction.EastWest)
                                tl.Receive("TurnRed");
                            else if (tl.Direction == Direction.NorthSouth)
                                tl.Receive("TurnGreen");
                        }
                        if (c is PedestrianSignal ps && ps.Crossing == Crossing.NorthSouth)
                            ps.Receive("Walk");
                    }
                    break;

                // Pedestrian presses button
                case "PedestrianRequestNS":
                    // if NS red, schedule next NS walk
                    Console.WriteLine("[Controller] Pedestrian requested North–South walk; will allow at next NS green.");
                    break;

                case "PedestrianRequestEW":
                    Console.WriteLine("[Controller] Pedestrian requested East–West walk; will allow at next EW green.");
                    break;

                default:
                    Console.WriteLine($"[Controller] No handling for '{eventCode}'");
                    break;
            }
        }

        public void RegisterComponent(IntersectionComponent component)
        {
            if (_components.Contains(component))
                _components.Add(component);
        }
    }

    public class TrafficLight : IntersectionComponent
    {
        public Direction Direction { get; }
        public TrafficLight(string name, IIntersectionMediator mediator) : base(name, mediator)
        {
        }

        public override void Receive(string message)
        {
            switch (message)
        {
            case "TurnGreen":
                Console.WriteLine($"[{Name}] ✅ GREEN ({Direction})");
                // After some time, signal green elapsed
                Task.Delay(2000).ContinueWith(_ => Send(
                    Direction == Direction.NorthSouth ? "NSGreenElapsed" : "EWGreenElapsed"
                ));
                break;
            case "TurnRed":
                Console.WriteLine($"[{Name}] ❌ RED ({Direction})");
                break;
        }
        }
    }

    public class PedestrianSignal : IntersectionComponent
    {
        public Crossing Crossing { get; }
        public PedestrianSignal(string name, IIntersectionMediator mediator) : base(name, mediator)
        {
        }

        public override void Receive(string message)
    {
        switch (message)
        {
            case "Walk":
                Console.WriteLine($"[{Name}] 🚶‍♂️ WALK ({Crossing})");
                // After walk period, automatically clear
                Task.Delay(1500).ContinueWith(_ => Console.WriteLine($"[{Name}] 🚫 DON’T WALK ({Crossing})"));
                break;
        }
    }

        
    }
}
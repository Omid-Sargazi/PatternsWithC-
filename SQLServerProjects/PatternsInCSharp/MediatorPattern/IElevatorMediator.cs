using System.Security.Cryptography;

namespace PatternsInCSharp.MediatorPattern
{
    public enum Directionn
    {
        Up,
        Down
    }
    public interface IElevatorMediator
    {
        void RegisterComponent(ElevatorComponent component);
        void RequestElevator(int floor, Directionn direction);
        void Notify(ElevatorComponent sender, string eventCode);
    }

    public abstract class ElevatorComponent
    {
        protected IElevatorMediator _mediator;
        public string Name { get; }
        protected ElevatorComponent(string name, IElevatorMediator mediator)
        {
            _mediator = mediator;
            Name = name;
        }

        protected void Send(string eventCode)
        {
            _mediator.Notify(this, eventCode);
        }

        public abstract void Receive(string message);
    }

    public class ElevatorMediator : IElevatorMediator
    {
        private readonly List<ElevatorComponent> _components = new();
        private readonly List<ElevatorCar> _cars = new();
        private readonly List<DisplayPanel> _panels = new();

        public void Notify(ElevatorComponent sender, string eventCode)
        {
            if (sender is ElevatorCar car && eventCode.StartsWith("Arrived:"))
        {
            var floor = int.Parse(eventCode.Split(':')[1]);
            Console.WriteLine($"[Mediator] {car.Name} arrived at floor {floor}");
            BroadcastToPanels($"{car.Name} arrived at floor {floor}");
            car.IsIdle = true;
        }
        }

        public void RegisterComponent(ElevatorComponent component)
        {
            if (_components.Contains(component)) return;
            _components.Add(component);

            if (component is ElevatorCar car) _cars.Add(car);
            if (component is DisplayPanel panel) _panels.Add(panel);
        }

        public void RequestElevator(int floor, Directionn direction)
        {
            Console.WriteLine($"[Mediator] Request at floor {floor} to go {direction}");
            var car = _cars.FirstOrDefault(c => c.IsIdle);
            if (car != null)
            {
                car.Receive($"MoveTo:{floor}");
                BroadcastToPanels($"Elevator {car.Name} dispatched to floor {floor}");
            }
            else
            {
                Console.WriteLine("[Mediator] No idle cars available – request queued");
                // (In Part 3 we’ll handle queuing)
            }
        }

        private void BroadcastToPanels(string message)
        {
            foreach (var panel in _panels)
                panel.Receive(message);
        }
    }

    public class ElevatorCar : ElevatorComponent
    {
        public bool IsIdle { get; set; } = true;
        public int CurrentFloor { get; private set; }

        public ElevatorCar(string name, IElevatorMediator mediator)
            : base(name, mediator) { }

        public override void Receive(string message)
        {
            if (message.StartsWith("MoveTo:"))
            {
                var target = int.Parse(message.Split(':')[1]);
                MoveTo(target);
            }
        }
        
         private async void MoveTo(int floor)
    {
        IsIdle = false;
        Console.WriteLine($"[{Name}] moving from {CurrentFloor} to {floor}");
        // Simulate travel time
        await Task.Delay(Math.Abs(floor - CurrentFloor) * 500);
        CurrentFloor = floor;
        Console.WriteLine($"[{Name}] reached floor {floor}");
        // Notify mediator
        Send($"Arrived:{floor}");
    }
    }

    public class DisplayPanel : ElevatorComponent
    {
        public DisplayPanel(string name, IElevatorMediator mediator) : base(name, mediator)
        {
        }

        public override void Receive(string message)
    {
        Console.WriteLine($"[{Name}] DISPLAY ▶ {message}");
    }
    }

    public class FloorButton : ElevatorComponent
    {
        public int Floor { get; }
        public Directionn Directionn { get; }
         public FloorButton(int floor, Directionn dir, IElevatorMediator mediator)
        : base($"Button[{floor},{dir}]", mediator)
    {
        Floor = floor;
        Directionn = dir;
    }

    public void Press()
    {
        Console.WriteLine($"[{Name}] pressed");
        (_mediator as IElevatorMediator)!.RequestElevator(Floor, Directionn);
    }

        public override void Receive(string message)
        {
            throw new NotImplementedException();
        }
    }
}
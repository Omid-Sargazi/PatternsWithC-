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
}
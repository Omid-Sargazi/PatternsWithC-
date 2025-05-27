namespace PatternsInCSharp.MediatorPattern
{
    public interface IIntersectionMediator
    {
        void RegisterComponent(IntersectionComponent component);
        void Notify(IntersectionComponent component,string eventCode);
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
}
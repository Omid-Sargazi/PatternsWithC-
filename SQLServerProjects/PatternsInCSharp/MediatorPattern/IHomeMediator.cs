namespace PatternsInCSharp.MediatorPattern
{
    public interface IHomeMediator
    {
        void RegisterDevice(SmartDevice device);
        void Notify(SmartDevice device,string eventCode);
    }

    public class HomeMediator : IHomeMediator
    {
        public void Notify(SmartDevice device, string eventCode)
        {
            throw new NotImplementedException();
        }

        public void RegisterDevice(SmartDevice device)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SmartDevice
    {
        protected IHomeMediator _mediator;
        public string Name { get; }
        public SmartDevice(string name, IHomeMediator mediator)
        {
            _mediator = mediator;
            Name = name;
        }

        public void Send(string eventCode)
        {
            _mediator.RegisterDevice(this);
        }

        public abstract void Receive(string message);
    }
}
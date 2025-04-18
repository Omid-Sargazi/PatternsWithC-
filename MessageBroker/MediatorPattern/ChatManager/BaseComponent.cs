namespace MessageBroker.MediatorPattern.ChatManager
{
    public abstract class BaseComponent : IUser
    {
        protected IChatMediator _mediator;
        public string Name {get;}
        public BaseComponent(string name, IChatMediator mediator=null)
        {
            _mediator = mediator;
            Name = name;
            _mediator.Register(this);
        }

        public void SetMediator(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract void ReceiveMessage(string message);
    }
}
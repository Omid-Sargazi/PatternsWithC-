namespace MessageBroker.MediatorPattern.ChatManager
{
    public abstract class BaseComponent
    {
        protected IChatMediator _mediator;
        public BaseComponent(IChatMediator mediator=null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IChatMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
namespace MessageBroker.MediatorPattern.Form
{
    public class BaseComponent
    {
        protected IFormMediator _mediator;
        public BaseComponent(IFormMediator mediator = null)
        {
            _mediator = mediator;
        }
        public void SetMediator(IFormMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
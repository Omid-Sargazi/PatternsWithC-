namespace Patterns.MediatorPattern.Controllers
{
    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Notify(string eventName)
        {
            _mediator.Notify(this, eventName);
        }
    }
}
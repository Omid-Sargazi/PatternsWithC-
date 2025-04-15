namespace Patterns.MediatorPattern.Controllers
{
    public class Light : BaseComponent
    {
        public Light(IMediator mediator) : base(mediator)
        {
        }

        public void TurnOn()
        {
            Console.WriteLine("Light turned on");
            _mediator?.Notify(this, "TurnOn");
        }
        public void TurnOff()
        {
            Console.WriteLine("Light turned off");
            _mediator?.Notify(this, "TurnOff");
        }
    }
}
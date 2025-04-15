namespace Patterns.MediatorPattern.Controllers
{
    public class Thermostat : BaseComponent
    {
        public void AdjustTemperature()
        {
            Console.WriteLine("Thermostat adjusting temperature");
            _mediator?.Notify(this, "TemperatureAdjusted");
        }
        public Thermostat(IMediator mediator) : base(mediator)
        {
        }
    }
}
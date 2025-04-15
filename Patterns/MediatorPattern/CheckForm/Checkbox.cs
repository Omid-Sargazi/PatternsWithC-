namespace Patterns.MediatorPattern.CheckForm
{
    public class Checkbox
    {
        private IMediator _mediator;
        public bool _isChecked;
        public Checkbox(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Toggle(bool value)
    {
        _isChecked = value;
        Console.WriteLine($"Checkbox toggled: {value}");
        _mediator.Notify(this, "InputChanged");
    }
    }
}
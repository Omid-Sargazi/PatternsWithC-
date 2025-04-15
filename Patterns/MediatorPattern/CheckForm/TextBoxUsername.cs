namespace Patterns.MediatorPattern.CheckForm
{
    public class TextBoxUsername
    {
        private IMediator _mediator;
        public TextBoxUsername(IMediator mediator)
        {
            _mediator = mediator;
        }
        public string _username;
        public void Input(string value)
    {
        _username = value;
        Console.WriteLine($"Username Input: {value}");
        _mediator.Notify(this, "InputChanged");
    }
    }
}
namespace Patterns.MediatorPattern.CheckForm
{
    public class TextBoxPassword
    {
        private IMediator _mediator;
        
        private string _password;
        public TextBoxPassword(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void Input(string value)
        {
            _password = value;
            // Render the password text box
            Console.WriteLine($"Password Input: {value}");
            _mediator.Notify(this, "InputChanged");
        }
         public bool IsValid()
        {
            return !string.IsNullOrEmpty(_password) && _password.Length >= 3;
        }
    }
}
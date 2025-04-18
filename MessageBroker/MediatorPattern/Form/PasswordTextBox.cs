namespace MessageBroker.MediatorPattern.Form
{
    public class PasswordTextBox : BaseComponent
    {
       private string _text = "";
       public string Text
       {
            get => _text;
            set
            {
                _text = value;
                Console.WriteLine($"PasswordTextBox: Text changed to '{_text}'");
                _mediator?.Notify(this, "TextChanged");
            }
       }
    }
}
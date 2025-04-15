using Patterns.MediatorPattern.CheckForm;
namespace Patterns.MediatorPattern.CheckForm
{
    public class FormMediator : IMediator
    {
        private TextBoxPassword _textBoxPassword;
        private TextBoxUsername _textBoxUsername;
        private Checkbox _checkbox;
        private Button _button;
        public FormMediator(TextBoxPassword textBoxPassword, TextBoxUsername textBoxUsername, Checkbox checkbox, Button button)
        {
            _textBoxPassword = textBoxPassword;
            _textBoxUsername = textBoxUsername;
            _checkbox = checkbox;
            _button = button;
        }
        
        public void Notify(object sender, string @event)
        {
            if (@event == "InputChanged")
        {
            if (!string.IsNullOrWhiteSpace(_textBoxUsername._username) &&
                _textBoxPassword.IsValid() &&
                _checkbox._isChecked)
            {
                _button.Enable();
            }
            else
            {
                _button.Disable();
            }
        }
        }
    }
}
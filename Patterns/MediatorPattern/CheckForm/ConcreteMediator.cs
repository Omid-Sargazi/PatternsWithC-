using Patterns.MediatorPattern.Chat;

namespace Patterns.MediatorPattern.CheckForm
{
    public class ConcreteMediator : IMediator
    {
        private TextBoxPassword PasswordBox;
        private TextBoxUsername UsernameBox;
        private Checkbox AgreementCheck;
        private Button SubmitButton;


        public void Notify(object sender, string ev)
        {
            if (ev == "Changed")
        {
            if (!string.IsNullOrEmpty(UsernameBox) &&
                PasswordBox.IsValid() &&
                AgreementCheck.IsChecked)
            {
                SubmitButton.Enable();
            }
            else
            {
                SubmitButton.Disable();
            }
        }
        }
    }
}
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
            
        }
    }
}
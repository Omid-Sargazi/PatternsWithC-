namespace MessageBroker.MediatorPattern.Form
{
    public class LoginButton : BaseComponent
    {
       private bool _isEnabled = false;
       public bool IsEnabled
       {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                Console.WriteLine($"LoginButton: IsEnabled changed to '{_isEnabled}'");
                _mediator?.Notify(this, "IsEnabledChanged");
            }

       }

       public void Click()
       {
            if(_isEnabled)
            {
                Console.WriteLine("LoginButton: Login clicked!");
            }
            else
            {
                Console.WriteLine("LoginButton: Login button is disabled.");
            }
       }
    }
}
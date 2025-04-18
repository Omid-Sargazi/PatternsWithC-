namespace MessageBroker.MediatorPattern.Form
{
    public class LoginDialogMediator : IFormMediator
    {
        private UsernameTextBox _usernameTextBox;
        private PasswordTextBox _passwordTextBox;
        private LoginButton _loginButton;
        public LoginDialogMediator(UsernameTextBox usernameTextBox, PasswordTextBox passwordTextBox, LoginButton loginButton)
        {
            _usernameTextBox = usernameTextBox;
            _passwordTextBox = passwordTextBox;
            _loginButton = loginButton;

            _usernameTextBox.SetMediator(this);
            _passwordTextBox.SetMediator(this);
            _loginButton.SetMediator(this);
        }
        
        public void Notify(object sender, string eventName)
        {
            if (eventName == "TextChanged" && (sender == _usernameTextBox || sender == _passwordTextBox))
        {
            // ارزیابی وضعیت دکمه
            bool isUsernameNonEmpty = !string.IsNullOrEmpty(_usernameTextBox.Text);
            bool isPasswordNonEmpty = !string.IsNullOrEmpty(_passwordTextBox.Text);
            _loginButton.IsEnabled = isUsernameNonEmpty && isPasswordNonEmpty;
        }
        }
    }
}

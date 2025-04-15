namespace Patterns.MediatorPattern.CheckForm
{
    public class TextBoxPassword
    {
        private int _password;
        public TextBoxPassword(int password)
        {
            _password = password;
        }
        
        public void Render()
        {
            // Render the password text box
            Console.WriteLine($"Rendering TextBoxPassword{_password}");
        }
    }
}
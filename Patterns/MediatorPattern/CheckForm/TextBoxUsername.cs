namespace Patterns.MediatorPattern.CheckForm
{
    public class TextBoxUsername
    {
        private string _username;
        public TextBoxUsername(string username)
        {
            _username = username;
        }
        public void Render()
        {  
            // Render the username text box
            Console.WriteLine($"Rendering TextBoxUsername{_username}");
        }
    }
}
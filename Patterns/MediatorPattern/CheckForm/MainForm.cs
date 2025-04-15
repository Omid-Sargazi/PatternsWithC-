namespace Patterns.MediatorPattern.CheckForm
{
    public class MainForm
    {
        private TextBoxUsername _textBoxUsername;
        private TextBoxPassword _textBoxPassword;
        private Checkbox _checkbox;
        private Button _button;

        public MainForm()
        {
            _textBoxUsername = new TextBoxUsername("omid");
            _textBoxPassword = new TextBoxPassword(123);
            _checkbox = new Checkbox(true);
            _button = new Button("Submit");
        }
    public void Render()
    {
        // Render the main form
        Console.WriteLine("Rendering MainForm");
        _textBoxUsername.Render();
        _textBoxPassword.Render();
        _checkbox.Render();
        _button.Render();
    }
    }
    
}
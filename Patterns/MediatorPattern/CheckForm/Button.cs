namespace Patterns.MediatorPattern.CheckForm
{
    public class Button
    {
        private string _label;
        public Button(string label)
        {
            _label = label;
        }
        
        public void Render()
        {
            // Render the button
            Console.WriteLine($"Rendering Button{_label}");
        }
    }
}
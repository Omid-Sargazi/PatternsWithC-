namespace Patterns.MediatorPattern.CheckForm
{
    public class Checkbox
    {
        private bool _isChecked;
        public Checkbox(bool isChecked)
        {
            _isChecked = isChecked;
        }
        
        public void Render()
        {
            // Render the checkbox
            Console.WriteLine($"Rendering Checkbox{_isChecked}");
        }
    }
}
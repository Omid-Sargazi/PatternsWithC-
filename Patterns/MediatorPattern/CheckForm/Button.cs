namespace Patterns.MediatorPattern.CheckForm
{
    public class Button
    {
       public string Label { get; }
    private bool _enabled;

    public Button(string label)
    {
        Label = label;
    }

    public void Enable()
    {
        _enabled = true;
        Console.WriteLine($"Button [{Label}] is ENABLED");
    }

    public void Disable()
    {
        _enabled = false;
        Console.WriteLine($"Button [{Label}] is DISABLED");
    }
    }
}
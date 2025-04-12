namespace CompositePattern.CommandPattern
{
    public class Canvas
    {
        private List<string> _shapes = new List<string>(); // لیست اشکال برای نمایش ساده

    public void Draw(string shapeType, params int[] parameters)
    {
        string shape = $"{shapeType}: {string.Join(", ", parameters)}";
        _shapes.Add(shape);
        Console.WriteLine($"Canvas: Drew {shape}");
        Console.WriteLine($"Canvas shapes: [{string.Join(" | ", _shapes)}]");
    }

    public void Erase(string shapeType, params int[] parameters)
    {
        string shape = $"{shapeType}: {string.Join(", ", parameters)}";
        _shapes.Remove(shape);
        Console.WriteLine($"Canvas: Erased {shape}");
        Console.WriteLine($"Canvas shapes: [{string.Join(" | ", _shapes)}]");
    }
    }
}
namespace CompositePattern.Composite.WithoutPattern
{
    public class FileSystemItem
    {
        public string Name { get; set; }
        public string GetInfo() => $"{Name}";
    }
}
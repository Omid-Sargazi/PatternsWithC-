namespace CompositePattern.Composite
{
    public interface IFileSystemItem
    {
        string Name { get; set; }
        string GetInfo();
        int GetSize();
    }
}
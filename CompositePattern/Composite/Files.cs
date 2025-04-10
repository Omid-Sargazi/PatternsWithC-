namespace CompositePattern.Composite
{
    public class Files : IFileSystemItem
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Size { get; set;}

        public string GetInfo()
        {
            return $"File: {Name}";
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
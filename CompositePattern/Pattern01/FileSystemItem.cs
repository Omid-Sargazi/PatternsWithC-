namespace CompositePattern.Pattern01
{
    public abstract class FileSystemItem
    {
        public string Name {get; set;}
        public FileSystemItem(string name)
        {
            Name = name;
        }
        public abstract int GetSize();
        public abstract void Search(string keyword);
    }
}
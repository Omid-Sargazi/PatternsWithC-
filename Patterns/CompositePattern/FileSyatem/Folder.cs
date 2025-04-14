namespace Patterns.CompositePattern.FileSyatem
{
    public class Folder : IFileSystemComponent
    {
        private List<IFileSystemComponent> _components;
        private string _name;
        public Folder(string name)
        {
            _name = name;
            _components = new List<IFileSystemComponent>();
        }
        public long GetSize()
        {
            long totalSize = 0;
            foreach(var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }
    }
}
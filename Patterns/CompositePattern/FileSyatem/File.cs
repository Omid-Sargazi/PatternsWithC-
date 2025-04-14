namespace Patterns.CompositePattern.FileSyatem
{
    public class File : IFileSystemComponent
    {
        private string _name;
        private long _size;
        public File(string name, long size)
        {
            _name = name;
            _size = size;
        }

        public long GetSize()
        {
            return _size;
        }
    }
}
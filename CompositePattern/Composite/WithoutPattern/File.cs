using System.Globalization;

namespace CompositePattern.Composite.WithoutPattern
{
    public class File : FileSystemItem
    {
        
        public int Size { get; set; }
        public string GetInfo() =>  $"File: {Name}, Size: {Size} bytes";
    }
}

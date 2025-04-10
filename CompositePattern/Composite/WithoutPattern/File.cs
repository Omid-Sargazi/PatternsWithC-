using System.Globalization;

namespace CompositePattern.Composite.WithoutPattern
{
    public class File
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public string GetInfo() =>  $"File: {Name}, Size: {Size} bytes";
    }
}

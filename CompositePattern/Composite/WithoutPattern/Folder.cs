namespace CompositePattern.Composite.WithoutPattern
{
    public class Folder : FileSystemItem
    {
        public List<FileSystemItem> files = new List<FileSystemItem>();

        public string GetInfo()
        {
            string info = $"{Name}:\n";
            foreach(var file in files)
            {
                info += $"{file.GetInfo()}";
            }
            return info;
        }
    }
}
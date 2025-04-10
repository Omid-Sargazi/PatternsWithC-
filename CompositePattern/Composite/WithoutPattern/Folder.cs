namespace CompositePattern.Composite.WithoutPattern
{
    public class Folder
    {
        public string Name { get; set; }
        public List<File> files = new List<File>();

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
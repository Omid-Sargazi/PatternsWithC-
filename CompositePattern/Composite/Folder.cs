namespace CompositePattern.Composite
{
    public class Folder : IFileSystemItem
    {
        public List<Files> Items = new List<Files>();
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetInfo()
        {
            string info = $"{Name}\n";
            foreach(var item in Items)
            {
                info += item.GetInfo() + "\n";
            }
            return info;
        }


        public int GetSize()
        {
            int totalSize = 0;
            foreach(var item in Items)
            {
                totalSize += item.GetSize();
            }
            return totalSize;
        }
    }
}
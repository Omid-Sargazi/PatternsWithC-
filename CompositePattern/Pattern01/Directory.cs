namespace CompositePattern.Pattern01
{
    public class Directory : FileSystemItem
    {
        public List<FileSystemItem> Items {get; set;} = new List<FileSystemItem>();
        public Directory(string name) : base(name)
        {

        }
        public void AddFile(FileSystemItem item)
        {
            Items.Add(item);
        }

        public void Remove(FileSystemItem item)
        {
            Items.Remove(item);
        }

        // public string Name {get; set;}
        // public List<File> files {get; set;} = new List<File>();
        // public List<Directory> SubDirectories {get; set;} = new List<Directory>();

        // public Directory(string name)
        // {
        //     Name = name;
        // }

        // public void AddFile(File file)
        // {
        //     files.Add(file);
        // }

        // public void AddDirectory(Directory directory)
        // {
        //     SubDirectories.Add(directory);
        // }

        // public int GetSize()
        // {
        //     int totalSize = 0;
        //     foreach(var file in files)
        //     {
        //         totalSize += file.GetSize();
        //     }

        //     foreach(var directory in SubDirectories)
        //     {
        //         totalSize += directory.GetSize();
        //     }
        //     return totalSize;
        // }
        public override int GetSize()
        {
            int totalSize = 0;
            foreach(var item in Items)
            {
                totalSize += item.GetSize();
            }
            return totalSize;
        }

        public override void Search(string keyword)
        {
            if(Name.Contains(keyword))
            {
                Console.WriteLine($"دایرکتوری پیدا شد: {Name}");
            }
            foreach(var item in Items)
            {
                item.Search(keyword);
            }
        }
    }
}
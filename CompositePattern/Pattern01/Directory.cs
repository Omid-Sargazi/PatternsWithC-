namespace CompositePattern.Pattern01
{
    public class Directory
    {
        public string Name {get; set;}
        public List<File> files {get; set;} = new List<File>();
        public List<Directory> SubDirectories {get; set;} = new List<Directory>();

        public Directory(string name)
        {
            Name = name;
        }

        public void AddFile(File file)
        {
            files.Add(file);
        }

        public void AddDirectory(Directory directory)
        {
            SubDirectories.Add(directory);
        }

        public int GetSize()
        {
            int totalSize = 0;
            foreach(var file in files)
            {
                totalSize += file.GetSize();
            }

            foreach(var directory in SubDirectories)
            {
                totalSize += directory.GetSize();
            }
            return totalSize;
        }
    }
}
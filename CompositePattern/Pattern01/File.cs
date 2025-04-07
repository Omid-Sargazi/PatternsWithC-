namespace CompositePattern.Pattern01
{
    public class File : FileSystemItem
    {
        public int Size { get; set; }
        public File(string name, int size) : base(name)
        {
            Size = size;
        }

        // public string Name {get; set;}
        // public int Size {get; set;}

        // public File(string Name, int Size)
        // {
        //     this.Name = Name;
        //     this.Size = Size;
        // }

        // public int GetSize()
        // {
        //     return Size;
        // }
        public override int GetSize()
        {
            return Size;
        }

        public override void Search(string keyword)
        {
            if(Name.Contains(keyword))
            {
                Console.WriteLine($"فایل پیدا شد: {Name}");
            }
        }
    }
}
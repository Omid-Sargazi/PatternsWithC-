namespace CompositePattern.Pattern01
{
    public class File
    {
        public string Name {get; set;}
        public int Size {get; set;}

        public File(string Name, int Size)
        {
            this.Name = Name;
            this.Size = Size;
        }
        
        public int GetSize()
        {
            return Size;
        }
    }
}
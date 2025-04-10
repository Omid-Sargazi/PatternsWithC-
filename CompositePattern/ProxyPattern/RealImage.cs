namespace CompositePattern.ProxyPattern
{
    public class RealImage : IImage
    {
        public string FileName {get; set;}
        public RealImage(string fileName)
        {
            FileName = fileName;
            Console.WriteLine($"Loading {FileName} from disk...");   
        }
        public void Display()
        {
            Console.WriteLine($"Displaying {FileName}");
        }
    }
}
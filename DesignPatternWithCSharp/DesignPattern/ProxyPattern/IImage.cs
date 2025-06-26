namespace DesignPattern.ProxyPattern
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        public string FileName { get; set; }

        public RealImage(string fileName)
        {
            FileName = fileName;
            LoadFromDisk(fileName);
        }
        public void Display()
        {
            Console.WriteLine($"Displaying image: {FileName}");
        }

        private void LoadFromDisk(string fileName)
        {
            Console.WriteLine($"Loading image: {fileName}");
            Thread.Sleep(1000); // simulate delay
        }
    }

    public class VirtualImageProxy : IImage
    {
        private string FileName { get; set; }
        private RealImage realImage;

        public VirtualImageProxy(string fileName)
        {
            FileName = fileName;
        }
        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(FileName);
            }
            realImage.Display();
        }
    }
}
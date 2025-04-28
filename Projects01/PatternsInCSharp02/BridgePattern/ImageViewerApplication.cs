namespace PatternsInCSharp02.BridgePattern
{
    public interface IRenderer
    {
        void Render(string fileName);
    }

    public class SoftwareRendering : IRenderer
    {
        public void Render(string fileName)
        {
            Console.WriteLine($"Software rendering: {fileName}");
        }
    }

    public class HardwareRenderer : IRenderer
    {
        public void Render(string fileName)
        {
            Console.WriteLine($"Hardware accelerated rendering: {fileName}");
        }
    }

    public abstract class Image
    {
        protected IRenderer _renderer;
        protected string _fileName;

        public Image(IRenderer renderer, string fileName)
        {
            _renderer = renderer;
            _fileName = fileName;
        }

        public abstract void Draw();
    }
    public class RealImage : Image
    {
         private byte[] _imageData;
        public RealImage(IRenderer renderer, string fileName) : base(renderer, fileName)
        {
        }
        private void LoadImage()
        {
            Console.WriteLine($"Loading image {_fileName} (expensive operation)");
            _imageData = new byte[10000000];
        }

        public override void Draw()
        {
            Console.WriteLine($"Displaying image {_fileName}");
            _renderer.Render(_fileName);
        }
    }

    public class ImageProxy : Image
    {
        private RealImage _realImage;
        
        public ImageProxy(IRenderer renderer, string fileName) : base(renderer, fileName)
        {
        }

        public override void Draw()
        {
            if(_realImage == null)
                _realImage = new RealImage(_renderer, _fileName);
            _realImage.Draw();
        }
    }
}
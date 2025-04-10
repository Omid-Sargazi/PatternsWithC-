namespace CompositePattern.ProxyPattern
{
    public class ImageProxy : IImage
    {
        private RealImage _image;
        private string _fileName;
        public ImageProxy(string fileName)
        {
            _fileName = fileName;
        }
        public void Display()
        {
            if(_image == null)
            {
                _image = new RealImage(_fileName);
            }
            _image.Display();
        }
    }
}
namespace CompositePattern.ProxyPattern
{
    public class ProtectedImageProxy : IImage
    {
        private RealImage _image;
        private string _fileName;
        private bool _hasAccess = false;
        public ProtectedImageProxy(string fileName, bool hasAccess)
        {
            _fileName = fileName;
            _hasAccess = hasAccess;
        }
        
        public void Display()
        {
            if(!_hasAccess)
            {
                Console.WriteLine("Access denied!");
                return;
            }
            if(_image == null)
            {
                _image = new RealImage(_fileName);
            }
            _image.Display();
        }
    }
}
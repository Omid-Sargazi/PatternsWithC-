namespace CompositePattern.ProxyPattern.WithoutPattern
{
    public class ImageProxy
    {
       private Image _image;
       private string _fileName;
       public ImageProxy(string fileName)
       {
            _fileName = fileName;
       }

       public void Display()
       {
            if(_image == null)
            {
                _image = new Image { FileName = _fileName };
                Console.WriteLine($"Loading {_fileName} from disk...");
            }
            _image.Display();
            
       }
    }
}
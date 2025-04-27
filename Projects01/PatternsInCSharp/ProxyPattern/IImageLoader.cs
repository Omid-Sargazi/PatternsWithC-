namespace PatternsInCSharp.ProxyPattern;
public interface IImageLoader
{
    string GetImageName();
    string GetResolution();
    byte[] GetImageDate();
}

public class Image
{
    public string Name {get;}
    public string Resolution {get;}
    public byte[] Data {get;}

    public Image(string name, string resolution, byte[] data)
    {
        Name = name;
        Resolution = resolution;
        Data = data;
    }
}

public class ImageLoader : IImageLoader
{
    private readonly string _imageId;
    private Image _image;
    public ImageLoader(string imageId)
    {
        _imageId = imageId;
        _image = LoadImageFromServer();
    }

    private Image LoadImageFromServer()
    {
        Console.WriteLine($"Loading image {_imageId} from server...");
        Thread.Sleep(2000); // Simulate network delay
        return new Image("Sample Image", "1920x1080", new byte[1024]); // Simulated image data
    }
    public byte[] GetImageDate()
    {
        return _image.Data;
    }

    public string GetImageName()
    {
        return _image.Name;
    }

    public string GetResolution()
    {
        return _image.Resolution;
    }
}

public class ImageLoaderProxy : IImageLoader
{
    private  ImageLoader _imageLoader;
    private Image _image;
    private readonly string _imageId;
    public ImageLoaderProxy(string imageId)
    {
        _imageId = imageId;
       _image = new Image("Photo.jpg","1920*1587",null);
        
    }
    public byte[] GetImageDate()
    {
        _imageLoader ??= new ImageLoader(_imageId);
        return _imageLoader.GetImageDate();
    }

    public string GetImageName()
    {
        return _image.Name;
    }

    public string GetResolution()
    {
        return _image.Resolution;
    }
}

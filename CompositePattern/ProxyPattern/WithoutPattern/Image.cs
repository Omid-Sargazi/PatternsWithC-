namespace CompositePattern.ProxyPattern.WithoutPattern
{
    public class Image
    {
      public string FileName {get; set;}
      private bool _isLoaded = false;
      private string _data;
      public void Display()
      {
           Console.WriteLine($"Displaying {FileName} (loaded from disk)");
      }
     
    }
}
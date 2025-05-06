using BehavioralPattern.VisitorPattern;

public class Program
{
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

       var document = new List<Document>
       {
            new TextDocument{Name = "ReadMe", Content = "this is a sample document.", CreatedDate = DateTime.Now},
            new PdfDocument{Name = "ReadMe", Content = "this is a sample document.", CreatedDate = DateTime.Now},
            new ImageDocument{Name = "ReadMe", Resolution = "1920x1080", CreatedDate = DateTime.Now},
       };

       foreach(var item in document)
       {
        item.ExportToJson();
        item.ExportToPlainText();
        item.ExportToXml();
       }
        
      
    }

   
}
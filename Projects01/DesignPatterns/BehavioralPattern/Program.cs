using BehavioralPattern.VisitorPattern;

public class Program
{
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        var document = new List<Document>
        {
            new TextDocument {Name = "ReadMe",Content = "This is a sample document", CreatedDate = DateTime.Now},
            new PdfDocument { Name = "Report", Content = "Pdf content", CreatedDate = DateTime.Now},
            new ImageDocument {Name="Logo", pixel="1986,1523", CreatedDate = DateTime.Now}
        };

        var xmlExporter = new XmlExportVisitor();
        var JsonExport = new JsonExportVisitor();
        var plainTextExport = new PlainTextExportVisitor();

        foreach(var item in document)
        {
            item.Accept(xmlExporter);
        }

        foreach(var item in document)
        {
            item.Accept(JsonExport);
        }
        
      
    }

   
}
namespace  BehavioralPattern.VisitorPattern
{
    public abstract class Document
    {
        public string Name {get; set;}
        public DateTime CreatedDate {get; set;}

        public abstract void ExportToXml();
        public abstract void ExportToJson();
        public abstract void ExportToPlainText();

    }

    public class TextDocument : Document
    {
        public string Content {get; set;}
        public override void ExportToJson()
        {
            Console.WriteLine($"Exporting TextDocumnet {Content} to JSON format");
        }

        public override void ExportToPlainText()
        {
            Console.WriteLine($"Exporting textDocumnet {Content} to Plain Text");
        }

        public override void ExportToXml()
        {
            Console.WriteLine($"Exporting textDocument {Content} to Xml format");
        }
    }

    public class PdfDocument : Document
    {
        public string Content {get; set;}
        public override void ExportToJson()
        {
            Console.WriteLine($"Exporting PdfCocumnet {Content} to Json format.");
        }

        public override void ExportToPlainText()
        {
            Console.WriteLine($"Expotnig PdfCocumnet {Content} to PlainText.");
        }

        public override void ExportToXml()
        {
            Console.WriteLine($"Exporting PdfCocumnet {Content} to Xml format.");
        }
    }

    public class ImageDocument : Document
    {
        public string Resolution {get; set;}
        public override void ExportToJson()
        {
            Console.WriteLine($"Exporting ImageDocument {Resolution} to Json format.");
        }

        public override void ExportToPlainText()
        {
            Console.WriteLine($"Exporting ImageDocumnet {Resolution} to PlainText format.");
        }

        public override void ExportToXml()
        {
            Console.WriteLine($"Exporting ImageDocumnet {Resolution} to Xml format.");
        }
    }
}
namespace  BehavioralPattern.VisitorPattern
{
    public abstract class Document
    {
        public string Name {get; set;}
        public DateTime CreatedDate {get; set;}

       public abstract void Accept(IVisitor visitor);

    }

    public class TextDocument : Document
    {
        public string Content {get; set;}

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class PdfDocument : Document
    {
        public string Content {get; set;}

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ImageDocument : Document
    {
        public string pixel {get; set;}
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

 
    public interface IVisitor
    {
        void Visit(TextDocument document);
        void Visit(PdfDocument pdfDocument);
        void Visit(ImageDocument imageDocument);
    }

    public class XmlExportVisitor : IVisitor
    {
        public void Visit(TextDocument document)
        {
            Console.WriteLine($"Exporting TextDocument {document.Name} to Xml format");
        }

        public void Visit(PdfDocument pdfDocument)
        {
            Console.WriteLine($"Expoting PdfDocument {pdfDocument.Name} to Xml format.");
        }

        public void Visit(ImageDocument imageDocument)
        {
            Console.WriteLine($"Exporting ImageDocumnet {imageDocument} to Xml format.");
        }
    }

    public class JsonExportVisitor : IVisitor
    {
        public void Visit(TextDocument document)
        {
            Console.WriteLine($"Exporting TextDocumnet {document.Name} to Json format.");
        }

        public void Visit(PdfDocument pdfDocument)
        {
            Console.WriteLine($"Expoting PdfDocument {pdfDocument.Content} to Json format.");
        }

        public void Visit(ImageDocument imageDocument)
        {
            Console.WriteLine($"Exportnig ImageDocument {imageDocument.pixel} to json format.");
        }
    }

    public class PlainTextExportVisitor : IVisitor
    {
        public void Visit(TextDocument document)
        {
            Console.WriteLine($"Exporting TetxDocument {document.Name} to Plain Text Format.");
        }

        public void Visit(PdfDocument pdfDocument)
        {
            Console.WriteLine($"Exporting PdfDocumnet {pdfDocument.Content} to Plain Text Format.");
        }

        public void Visit(ImageDocument imageDocument)
        {
            Console.WriteLine($"Exporting imageDocument {imageDocument.pixel} to Plain text Format.");
        }
    }
}

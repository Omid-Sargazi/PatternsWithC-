namespace BehavioralPattern.VisitorPattern
{
    public interface IVisitorDocument
    {
        void Visit(TextDocuments textDocuments);
        void Visit(PdfDocuments pdfDocuments);
        void Visit(ImageDocuments imageDocuments);
    }
    public abstract class Documents
    {
        public string Name {get; set;}
        public DateTime CreateDate {get; set;}

        public abstract void Accept(IVisitorDocument visitor);
    }

    public class TextDocuments : Documents
    {
        public string Content {get; set;}

        public override void Accept(IVisitorDocument visitor)
        {
            visitor.Visit(this);
        }
    }

    public class PdfDocuments : Documents
    {
        public int PageCount {get; set;}

        public override void Accept(IVisitorDocument visitor)
        {
           visitor.Visit(this);
        }
    }

    public class ImageDocuments : Documents
    {
        public string Resolution {get; set;}

        public override void Accept(IVisitorDocument visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ExportToXmlVisitor : IVisitorDocument
    {
        public void Visit(TextDocuments textDocuments)
        {
            Console.WriteLine($"Exporting Textdocument {textDocuments.Name} in to Xml format.");
        }

        public void Visit(PdfDocuments pdfDocuments)
        {
            Console.WriteLine($"Exporting PdfDocumnet{pdfDocuments.PageCount} in to Xml format.");
        }

        public void Visit(ImageDocuments imageDocuments)
        {
            Console.WriteLine($"Exporting ImageDocument {imageDocuments} in to xml format.");
        }
    }

    public class ExportToJsonVisitor : IVisitorDocument
    {
        public void Visit(TextDocuments textDocuments)
        {
            Console.WriteLine($"Exporting TextDocument {textDocuments.Name} in to Json Format.");
        }

        public void Visit(PdfDocuments pdfDocuments)
        {
            Console.WriteLine($"Exporting PdfDocument {pdfDocuments.PageCount} in to Json format.");
        }

        public void Visit(ImageDocuments imageDocuments)
        {
            Console.WriteLine($"Exporting PdfDocument {imageDocuments.Resolution} in to Json format.");
            
        }
    }

    public class ExportToPlainTextVisitor : IVisitorDocument
    {
        public void Visit(TextDocuments textDocuments)
        {
            throw new NotImplementedException();
        }

        public void Visit(PdfDocuments pdfDocuments)
        {
            throw new NotImplementedException();
        }

        public void Visit(ImageDocuments imageDocuments)
        {
            throw new NotImplementedException();
        }
    }

}
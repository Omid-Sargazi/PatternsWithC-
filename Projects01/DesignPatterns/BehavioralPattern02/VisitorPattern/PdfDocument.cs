using Microsoft.VisualBasic;

namespace BehavioralPattern02.VisitorPattern
{
    public interface IDocument
    {
        void Accept(IDocumentVisitor visitor);
    }

    public interface IDocumentVisitor
    {
        void Visit(PdfDocument pdfDocument);
        void Visit(WordDocument wordDocument);
    }
    public abstract class Document
    {
        
    }

    public class PdfDocument : IDocument
    {
        public int PageCount {get;}

        public PdfDocument(int pageCount)
        {
            PageCount = pageCount;
        }

        public void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class WordDocument : IDocument
    {
        public int WordCount {get;}

        public WordDocument(int wordCount)
        {
            WordCount = wordCount;
        }

        public void Accept(IDocumentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

   
  
    

    public class CalculateCompressedSize : IDocumentVisitor
    {
        public double result; 
        public void Visit(PdfDocument pdfDocument)
        {
             var result = pdfDocument.PageCount * 0.1 * 0.5;

        }

        public void Visit(WordDocument wordDocument)
        {
            var result = (wordDocument.WordCount / 1000.0) * 0.2 * 0.5;
        }
    }

    public class ConvertFormat : IDocumentVisitor
    {
        public void Visit(PdfDocument pdfDocument)
        {
            Console.WriteLine($"PDF Document with {pdfDocument.PageCount} pages");
        }

        public void Visit(WordDocument wordDocument)
        {
            Console.WriteLine($"Word Document with {wordDocument.WordCount} words");
        }
    }
}
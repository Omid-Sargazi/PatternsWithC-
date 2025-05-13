using System.Globalization;

namespace BehavioralPattern02.VisitorPattern
{
    public interface IAllDocuments
    {
        void Accept(IAllDocumentsVisitor visitor);
    }

    public interface IAllDocumentsVisitor
    {
        void Visit(PdfAllDocument pdf);
        void Visit(WordAllDocumnet word);
        void Visit(HtmlDocument html);
    }

    public interface ICompressionStrategy
    {
        string Compress(string context);
    }

    public class FastCompression : ICompressionStrategy
    {
        public string Compress(string context)
        {
            throw new NotImplementedException();
        }
    }

    public class HighQualityCompression : ICompressionStrategy
    {
        public string Compress(string context)
        {
            throw new NotImplementedException();
        }
    }

    public class PdfAllDocument : IAllDocuments
    {
        public string Content { get; }
        public void Accept(IAllDocumentsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class HtmlDocument : IAllDocuments
    {
        public string Content;
        public void Accept(IAllDocumentsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class WordAllDocumnet : IAllDocuments
    {
        public string Content { get; }
        public void Accept(IAllDocumentsVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CompressionVisitor : IAllDocumentsVisitor
    {
        private readonly ICompressionStrategy _compressionStrategy;
        public CompressionVisitor(ICompressionStrategy strategy)
        {
            _compressionStrategy = strategy;
        }
        public void Visit(PdfAllDocument pdf)
        {
            Console.WriteLine($"Compressing PDF: {_compressionStrategy.Compress(pdf.Content)}");
        }

        public void Visit(WordAllDocumnet word)
        {
            Console.WriteLine($"Compressing Word: {_compressionStrategy.Compress(word.Content)}");
        }

        public void Visit(HtmlDocument html)
        {
            Console.WriteLine($"Compressing html: {_compressionStrategy.Compress(html.Content)}");
        }
    }

    public class TextExtractionVisitor : IAllDocumentsVisitor
    {

        public void Visit(PdfAllDocument pdf)
        {
            throw new NotImplementedException();
        }

        public void Visit(WordAllDocumnet word)
        {
            throw new NotImplementedException();
        }

        public void Visit(HtmlDocument html)
        {
            throw new NotImplementedException();
        }
    }

    public class AllSizeCalculatorVisitor : IAllDocumentsVisitor
    {
        public int TotalSize { get; private set; }
        public void Visit(PdfAllDocument pdf)
        {
            TotalSize += pdf.Content.Length;
        }

        public void Visit(WordAllDocumnet word)
        {
            TotalSize += word.Content.Length;
        }

        public void Visit(HtmlDocument html)
        {
            throw new NotImplementedException();
        }
    }
}
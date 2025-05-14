namespace BehavioralPattern02.VisitorPattern
{
    public interface IDocumentt
    {
        void Accept(IDocumentVisitorr visitor);
    }

    public interface IDocumentVisitorr
    {
        void Visit(PdfDocumentt documentt);
        void Visit(WordDocumentt documentt);
    }

    public class PdfDocumentt : IDocumentt
    {
        public int PageCount { get; }

        public PdfDocumentt(int pageCount)
        {
            PageCount = pageCount;
        }
        public void Accept(IDocumentVisitorr visitor)
        {
            visitor.Visit(this);
        }
    }

    public class WordDocumentt : IDocumentt
    {
        public int WordCount { get; }

        public WordDocumentt(int wordCount)
        {
            WordCount = wordCount;
        }
        public void Accept(IDocumentVisitorr visitor)
        {
            visitor.Visit(this);
        }
    }

    public class DisplayInfoVisitor : IDocumentVisitorr
    {
        public void Visit(PdfDocumentt documentt)
        {
            Console.WriteLine($"PDF Document with {documentt.PageCount} pages");
        }

        public void Visit(WordDocumentt documentt)
        {
            Console.WriteLine($"Word Document with {documentt.WordCount} words");
        }
    }

    public class CompressionVisitorr : IDocumentVisitorr
    {
        public double CompressedSize { get; private set; }
        public void Visit(PdfDocumentt documentt)
        {
             CompressedSize = documentt.PageCount * 0.1 * 0.5; // هر صفحه 0.1 مگابایت، فشرده‌سازی 50%
        }

        public void Visit(WordDocumentt documentt)
        {
            CompressedSize = (documentt.WordCount / 1000.0) * 0.2 * 0.5; // هر 1000 کلمه 0.2 مگابایت
        }
    }
}
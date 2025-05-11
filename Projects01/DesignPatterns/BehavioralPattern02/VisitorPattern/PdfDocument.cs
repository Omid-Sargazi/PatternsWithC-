namespace BehavioralPattern02.VisitorPattern
{
    public abstract class Document
    {
        public abstract void DisplayInfo();
        public abstract double CalculateCompressedSize();
        public abstract string ConvertFormat();
    }

    public class PdfDocument : Document
    {
        public int PageCount {get;}

        public PdfDocument(int pageCount)
        {
            PageCount = pageCount;
        }
        public override double CalculateCompressedSize()
        {
            return PageCount * 0.1 * 0.5;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"PDF Document with {PageCount} pages");
        }

        public override string ConvertFormat()
        {
            return "Converted PDF to Word format";
        }
    }

    public class WordDocument : Document
    {
        public int WordCount {get;}

        public WordDocument(int wordCount)
        {
            WordCount = wordCount;
        }
        public override double CalculateCompressedSize()
        {
           return (WordCount / 1000.0) * 0.2 * 0.5;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Word Document with {WordCount} words");
        }

        public override string ConvertFormat()
        {
            return "Converted Word to PDF format";
        }
    }

}
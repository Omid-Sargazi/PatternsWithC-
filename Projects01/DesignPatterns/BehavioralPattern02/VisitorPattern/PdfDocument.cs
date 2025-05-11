namespace BehavioralPattern02.VisitorPattern
{
    public abstract class Document
    {
        
    }

    public class PdfDocument : Document
    {
        public int PageCount {get;}

        public PdfDocument(int pageCount)
        {
            PageCount = pageCount;
        }
      
    }

    public class WordDocument : Document
    {
        public int WordCount {get;}

        public WordDocument(int wordCount)
        {
            WordCount = wordCount;
        }
       
    }

    public class DocumentOperations
    {
        public void DisplayInfo(Document doc)
        {
            if(doc is PdfDocument pdfDocument)
            {
                Console.WriteLine($"PDF Document with {pdfDocument.PageCount} pages");
            }
            else if(doc is WordDocument wordDocument)
            {
                Console.WriteLine($"Word Document with {wordDocument.WordCount} words");
            }
            else
            {
                throw new NotSupportedException("Document not supported");
            }
        }

        public double CalculateCompressedSize(Document doc)
        {
            if(doc is PdfDocument pdfDocument)
            {
                return pdfDocument.PageCount * 0.1 * 0.5;
            }
            else if(doc is WordDocument wordDocument)
            {
                return (wordDocument.WordCount / 1000.0) * 0.2 * 0.5;
            }
            throw new NotSupportedException("Document not supported");
        }

        public string ConvertFormat(Document doc)
        {
            if(doc is PdfDocument)
            {
                return "Converted PDF to Word format";
            }
            else if(doc is WordDocument)
            {
                return "Converted Word to PDF format";
            }

            throw new NotSupportedException("Document not supported");
        }
    }

}
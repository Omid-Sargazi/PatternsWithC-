using System.Drawing;

namespace VisitorPattern.LibrarySystem
{
    public interface IDocumentItem
    {
        void Accept(IVisitor visitor);
    }

    public class PDFDocument : IDocumentItem
    {
       public int Pages { get; set; }
         public bool IsEncrypted { get; set; }

        public PDFDocument(int pages, bool isEncrypted)
        {
            Pages = pages;
            IsEncrypted = isEncrypted;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class WordDocument : IDocumentItem
    {
         public int WordCount { get; set; }
        public bool HasTrackedChanges { get; set; }
        public WordDocument(int wordCount, bool hasTrackedChanges)
        {
            WordCount = wordCount;
            HasTrackedChanges = hasTrackedChanges;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class SpreadsheetDocument : IDocumentItem
    {
         public int Sheets { get; set; }
        public int Cells { get; set; }
        public SpreadsheetDocument(int sheets, int cells)
        {
            Sheets = sheets;
            Cells = cells;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(PDFDocument pDFDocument);
        void Visit(WordDocument wordDocument);
        void Visit(SpreadsheetDocument spreadsheetDocument);
    }

    public class PrintVisitor : IVisitor
    {
        public void Visit(PDFDocument pDFDocument)
        {
            Console.WriteLine($"Printing PDF: {pDFDocument.Pages}");
        }

        public void Visit(WordDocument wordDocument)
        {
            Console.WriteLine($"Printing Word document: {wordDocument.WordCount}");
        }

        public void Visit(SpreadsheetDocument spreadsheetDocument)
        {
            Console.WriteLine($"Printing Spreadsheet: {spreadsheetDocument.Sheets}");
        }
    }

    public class Documents
    {
        public readonly List<IDocumentItem> _items = new List<IDocumentItem>();
        public void AddItem(IDocumentItem item)
        {
            _items.Add(item);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (var item in _items)
            {
                item.Accept(visitor);
            }
        }
    }


}
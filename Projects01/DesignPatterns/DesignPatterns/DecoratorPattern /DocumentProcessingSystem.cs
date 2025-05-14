namespace DesignPatterns.DecoratorPattern_
{   
    public interface  IDocument
    {
        string GetContent();
        void SetContent(string content);
        string Process();
    }
    public class TextDocument : IDocument
    {
        protected string _content;
        public TextDocument(string content = "")
        {
            _content = content;
        }

        public string GetContent()
        {
            return _content;
        }

        public virtual string Process()
        {
            return $"Processed on {_content}";
        }

        public void SetContent(string content)
        {
            _content = content;
        }
    }

    public abstract class DocumentDecorator : IDocument
    {
        protected IDocument _document;
        public DocumentDecorator(IDocument document)
        {
            _document = document;
        }
        public virtual string GetContent()
        {
            return _document.GetContent();
        }

        public virtual string Process()
        {
            return _document.Process();
        }

        public virtual void SetContent(string content)
        {
            _document.SetContent(content);
        }
    }

    public class HtmlFormatterDecorator : DocumentDecorator
    {
        public HtmlFormatterDecorator(IDocument document) : base(document)
        {
        }
        public override string Process()
        {
            string process = _document.Process();
            return $"<html><body>{process}</body></html>";
        }
    }

    public class MarkdownFormatterDecorator : DocumentDecorator
    {
        public MarkdownFormatterDecorator(IDocument document) : base(document)
        {
        }
        public override string Process()
        {
            string process = _document.Process();
             process = process.Replace("*", "**");
            return process;
        }
    }

    public class SpellCheckDecorator : DocumentDecorator
    {
        public SpellCheckDecorator(IDocument document) : base(document)
        {
        }

        public override string Process()
        {

           string processed = _document.Process();
            // Simple spell checking example
            processed = processed.Replace("teh", "the");
            processed = processed.Replace("occured", "occurred");
            return processed;
        }
    }

    public class CompressionDecorator : DocumentDecorator
    {
        public CompressionDecorator(IDocument document) : base(document)
        {
        }

        public override string Process()
        {
            string processed = _document.Process();
            // Simulate compression by removing extra spaces
            processed = System.Text.RegularExpressions.Regex.Replace(processed, @"\s+", " ");
            return processed;
        }
    }

    public class EncryptionDecorator : DocumentDecorator
    {
        public EncryptionDecorator(IDocument document) : base(document)
        {
        }

        public override string Process()
        {
            string processed = _document.Process();
            // Simple "encryption" (just a placeholder)
            return $"ENCRYPTED[{processed}]";
        }
    }
}
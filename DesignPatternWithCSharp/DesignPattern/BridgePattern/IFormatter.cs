namespace DesignPattern.BridgePattern
{
    public interface IFormatter
    {
        string Format(string content);
    }

    public class PdfFormatter : IFormatter
    {
        public string Format(string content)
        {
            return $"[PDF]: {content}";
        }
    }

    public class HTMLFormatter : IFormatter
    {
        public string Format(string content)
        {
            return $"<html>{content}</html>";
        }
    }

    public abstract class Printer
    {
        protected IFormatter _formatter;
        public Printer(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public abstract void Print(string content);
    }

    public class LaserPrinter : Printer
    {
        public LaserPrinter(IFormatter formatter) : base(formatter)
        {
        }

        public override void Print(string content)
        {
            _formatter.Format(content);
        }
    }


    public class InkjetPrinter : Printer
    {
        public InkjetPrinter(IFormatter formatter) : base(formatter)
        {
        }

        public override void Print(string content)
        {
            _formatter.Format(content);
        }
    }
}
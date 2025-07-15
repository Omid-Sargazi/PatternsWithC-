using System.Formats.Tar;

namespace DesignPattern.BridgePattern
{
   

    public interface IPrinter
    {
        void Print();
    }
    public class PdfPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Pdf print.");
        }
    }

    public class HtmlPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("html print.");

        }
    }

    public abstract class BaseReport
    {
        protected IPrinter _printer;
        protected string Content { get; set;}
        protected BaseReport(IPrinter printer)
        {
            _printer = printer;
        }
        public abstract void Print();
    }

    public class SalesReport : BaseReport
    {
        public SalesReport(IPrinter printer) : base(printer)
        {
        }

        public override void Print()
        {
            Content = "Sales Report Content";
            _printer.Print();
        }
    }

    public class EmployeeReport : BaseReport
    {
        public EmployeeReport(IPrinter printer) : base(printer)
        {
        }

        public override void Print()
        {
            _printer.Print();
        }
    }

    public class ClientBridge
    {
        public void Run()
        {
            var pdf = new PdfPrinter();
            var employee = new EmployeeReport(pdf);
        }
    }
}
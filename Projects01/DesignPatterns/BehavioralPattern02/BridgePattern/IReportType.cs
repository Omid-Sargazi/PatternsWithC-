namespace BehavioralPattern02.BridgePattern
{
    public interface IReportType
    {
        void GenerateReport(string content);
    }

    public class PdfReport : IReportType
    {
        public void GenerateReport(string content)
        {
            Console.WriteLine($"Generating PDF report with content: {content}");
        }
    }

    public class ExcelReport : IReportType
    {
        public void GenerateReport(string content)
        {
            Console.WriteLine($"Generating Excel report with content: {content}");
        }
    }

    public interface IRenderFormat
    {
        void ApplyFormat(string content);
    }

    public class PortraitFormat : IRenderFormat
    {
        public void ApplyFormat(string content)
        {
            Console.WriteLine($"Applying Portrait format to content: {content}");
        }
    }

    public class LandscapeFormat : IRenderFormat
    {
        public void ApplyFormat(string content)
        {
            Console.WriteLine($"Applying Landscape format to content: {content}");
        }
    }
    public abstract class Reportt
    {
        protected IRenderFormat _renderFormat;
        protected IReportType _reportType;
        public Reportt(IReportType reportType, IRenderFormat renderFormat)
        {
            _reportType = reportType;
            _renderFormat = renderFormat;
        }
        public abstract void Generate(string content);
    }
    public class StandardReport : Reportt
    {
        public StandardReport(IReportType reportType, IRenderFormat renderFormat) : base(reportType, renderFormat)
        {
        }

        public override void Generate(string content)
        {
           _renderFormat.ApplyFormat(content);
           _reportType.GenerateReport(content);
        }
    }
}
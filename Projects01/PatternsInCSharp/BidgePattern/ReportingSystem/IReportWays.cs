namespace PatternsInCSharp.BidgePattern.ReportingSystem
{
    public interface IReportOutput
    {
        void PresentReport(string formattedReport, string reportName);
    }

    public class FileOutput : IReportOutput
    {
        public void PresentReport(string formattedReport, string reportName)
        {
            Console.WriteLine($"Output to File: Saved {formattedReport} to {reportName}.txt");
        }
    }
    public class ConsoleOutput : IReportOutput
    {
        public void PresentReport(string formattedReport, string reportName)
        {
            Console.WriteLine($"Output to Console : {formattedReport}");
        }
    }

    public abstract class ReportFormat 
    {
        protected IReportOutput _reportOutput;
        protected ReportFormat(IReportOutput reportOutput)
        {
            _reportOutput = reportOutput;
        } 
        public abstract void GenerateReport(string reportContent, string reportName);
    }

    public class PdfReportFormat : ReportFormat
    {
        public PdfReportFormat(IReportOutput reportOutput) : base(reportOutput)
        {
        }

        public override void GenerateReport(string reportContent, string reportName)
        {
           string formatReport = $"[PDF] {reportContent}";
           _reportOutput.PresentReport(formatReport,reportName);
        }
    }

    public class ExcelReportFormat : ReportFormat
    {
        public ExcelReportFormat(IReportOutput reportOutput) : base(reportOutput)
        {
        }

        public override void GenerateReport(string reportContent, string reportName)
        {
            string fomattedReport = $"[Excel] {reportContent}";
            _reportOutput.PresentReport(fomattedReport, reportName);
        }
    }
}
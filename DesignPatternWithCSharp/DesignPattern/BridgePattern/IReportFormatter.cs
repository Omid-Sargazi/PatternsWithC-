using System.Text;

namespace DesignPattern.BridgePattern
{
    public interface IReportFormatter
    {
        void GenerateHeader(string title);
        void GenerateBody(string data);
        void GenerateFooter(string footerText);
        byte[] GetFormatRepoter();
    }

    public class PdfReportFormatter : IReportFormatter
    {
        private readonly List<string> _content = new List<string>();

        public void GenerateBody(string data)
        {
            _content.AddRange(data.Select(item => $"PDF Data: {item}"));
        }

        public void GenerateFooter(string footerText)
        {
            _content.Add($"PDF Footer: {footerText}");
        }

        public void GenerateHeader(string title)
        {
            _content.Add($"PDF Header: {title}");
        }

        public byte[] GetFormatRepoter()
        {
            Console.WriteLine("Generating PDF report...");
            return Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, _content));
        }
    }

    public class ExcelReportFormatter : IReportFormatter
    {
        private readonly List<string> _content = new();
        public void GenerateBody(string data)
        {
            _content.AddRange(data.Select(item => $"Excel Row: {item}"));
        }

        public void GenerateFooter(string footerText)
        {
             _content.Add($"Excel Footer: {footerText}");
        }

        public void GenerateHeader(string title)
        {
            _content.Add($"Excel Header: {title}");
        }

        public byte[] GetFormatRepoter()
        {
             Console.WriteLine("Generating Excel report...");
             return Encoding.UTF8.GetBytes(string.Join("\t", _content));
        }
    }
}
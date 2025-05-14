namespace BehavioralPattern02.BridgePattern
{
    public interface IDocRenderer
    {
        void Render(string title, string content);
    }

    public class PdfRender : IDocRenderer
    {
        public void Render(string title, string content)
        {
           Console.WriteLine($"[PDF] {title}: {content}");
        }
    }

    public class HtmlRenderer : IDocRenderer
    {
        public void Render(string title, string content)
        {
            Console.WriteLine($"<html><h1>{title}</h1><p>{content}</p></html>");
        }
    }

    public class Invoice
    {
        private readonly IDocRenderer _docRenderer;
        public Invoice(IDocRenderer docRenderer)
        {
            _docRenderer = docRenderer;
        }
        public string Title {get; set;}  ="Invoice";
        public string Content {get; set;}  ="Invoice details ...";

        public void Render()
        {
            _docRenderer.Render(Title, Content);
        }
    }

    public class Report
    {
        public IDocRenderer _docRenderer;
        public Report(IDocRenderer docRenderer)
        {
            _docRenderer = docRenderer;
        }
         public string Title { get; set; } = "Report";
        public string Content { get; set; } = "Monthly stats...";

        public void Render()
        {
            _docRenderer.Render(Title, Content);
        }
    }
}
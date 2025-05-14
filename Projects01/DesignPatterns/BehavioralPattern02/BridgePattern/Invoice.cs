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
        public string Title {get; set;}  ="Invoice";
        public string Content {get; set;}  ="Invoice details ...";

        public void RenderAsPdf()
        {
            Console.WriteLine($"[PDF] {Title}: {Content}");
        }

        public void RenderAsHtml()
        {
            Console.WriteLine($"<html><h1>{Title}</h1><p>{Content}</p></html>");
        }
    }

    public class Report
    {
         public string Title { get; set; } = "Report";
        public string Content { get; set; } = "Monthly stats...";

         public void RenderAsPdf()
        {
            Console.WriteLine($"[PDF] {Title}: {Content}");
        }

        public void RenderAsHtml()
        {
            Console.WriteLine($"<html><h1>{Title}</h1><p>{Content}</p></html>");
        }
    }
}
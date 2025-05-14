namespace BehavioralPattern02.BridgePattern
{
    public abstract class Documentt
    {
        protected readonly IDocRenderer _renderer;
        protected Documentt(IDocRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Render();
    }
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

    public class Invoice : Documentt
    {
        private readonly IDocRenderer _docRenderer;

        public Invoice(IDocRenderer renderer) : base(renderer)
        {
        }

        public string Title {get; set;}  ="Invoice";
        public string Content {get; set;}  ="Invoice details ...";

       

        public override void Render()
        {
            _docRenderer.Render(Title, Content);
        }
    }

    public class Report : Documentt
    {
        public IDocRenderer _docRenderer;

        public Report(IDocRenderer renderer) : base(renderer)
        {
        }

        public string Title { get; set; } = "Report";
        public string Content { get; set; } = "Monthly stats...";

        public override void Render()
        {
            _docRenderer.Render(Title, Content);
        }
    }
}
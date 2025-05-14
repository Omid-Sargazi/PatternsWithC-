namespace BehavioralPattern02.BridgePattern
{
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
}
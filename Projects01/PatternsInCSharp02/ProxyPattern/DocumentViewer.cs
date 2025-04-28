namespace PatternsInCSharp02.ProxyPattern
{
    public interface IDocument
    {
        public void View();
    }

    public class RealDocument : IDocument
    {
        public void View()
        {
            Console.WriteLine("Viewing the document.");
            DownloadFromServer();

        }

        private void DownloadFromServer()
        {
            Console.WriteLine("Downloading the document from the server.");
        }
    }

    public class ProxyDocument : IDocument
    {
        private RealDocument _realDocument;
        private string _title;
        private string _level;

        public ProxyDocument(string title, string level)
        {
            _title = title;
            _level = level;
        }
        public void View()
        {
            if(_level != "high")
            {
                Console.WriteLine("You don't have permission to view this document.");
            }
            else
            {
                if (_realDocument == null)
                {
                    _realDocument = new RealDocument();
                }
                _realDocument.View();
            }
        }
    }
}
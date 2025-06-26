using System.Linq.Expressions;

namespace DesignPattern.ProxyPattern
{
    public interface IDocument
    {
        void Read();
        void Delete();
    }

    public class RealDocument : IDocument
    {
        public string FileName { get; set; }

        public RealDocument(string fileName)
        {
            FileName = fileName;
        }
        public void Delete()
        {
            Console.WriteLine($"Deleting document: {FileName}");
        }

        public void Read()
        {
            Console.WriteLine($"Reading document: {FileName}");
        }
    }

    public class ProtectionProxy : IDocument
    {
        private RealDocument realDocument;
        private string role { get; set; }

        public ProtectionProxy(string fileName,string userRole)
        {
            role = userRole;
            realDocument = new RealDocument(fileName);
        }
        public void Delete()
        {
            if (role == "Admin")
            {
                realDocument.Delete();
            }
            Console.WriteLine("Access Denied: You are not allowed to delete this document.");
        }

        public void Read()
        {
            realDocument.Read();
        }
    }
}
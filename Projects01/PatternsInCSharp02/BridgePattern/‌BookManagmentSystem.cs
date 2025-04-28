namespace PatternsInCSharp02.BridgePattern
{
    public interface IAccessMode
    {
        void Access(string title, string memberName);
        void Return(string title);
    }

    public class PhysicalAccess : IAccessMode
    {
        public void Access(string title, string memberName)
        {
           Console.WriteLine($"{memberName} has borrowed the printed book '{title}'.");
        }

        public void Return(string title)
        {
            Console.WriteLine($"The printed book '{title}' has been returned.");
        }
    }

    public class PrintedBook
    {
        private readonly string _title; 
        private readonly IAccessMode _accessMode;

        public PrintedBook(string title, IAccessMode accessMode)
        {
            _title = title;
            _accessMode = accessMode;
        }

        public void Borrow(string memberName)
        {
            _accessMode.Access(_title, memberName);
        }

        public void Return()
        {
            _accessMode.Return(_title);
        }
    }

    public class DownloadAccess : IAccessMode
    {
        public void Access(string title, string memberName)
        {
            Console.WriteLine($"[DownloadAccess] {memberName} downloaded the eBook: {title}");
        }

        public void Return(string title)
        {
            Console.WriteLine($"[DownloadAccess] The eBook '{title}' license was revoked.");
        }
    }
}
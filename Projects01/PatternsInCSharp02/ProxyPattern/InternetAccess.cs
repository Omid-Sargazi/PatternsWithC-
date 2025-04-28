namespace PatternsInCSharp02.ProxyPattern
{
    public interface IInternet
    {
        void ConnectTo(string serverHost);
    }

    public class RealInternet : IInternet
    {
        public void ConnectTo(string serverHost)
        {
            Console.WriteLine($"Connecting to {serverHost}...");
        }
    }

    public class ProxyInternet : IInternet
    {
        protected RealInternet _real;
        private string _employeeRole;
        private static List<string> _bannedSites = new List<string> { "abc.com", "xyz.com" };

        public ProxyInternet(string employeeRole)
        {
            _employeeRole = employeeRole;
            _real = new RealInternet();
        }
        public void ConnectTo(string serverHost)
        {
            if(_employeeRole.ToLower() !="manager")
            {
                Console.WriteLine("Internet access denied. Only managers are allowed.");
                return;
            }
            if(_bannedSites.Contains(serverHost.ToLower()))
            {
                Console.WriteLine($"Access denied to {serverHost}");
                return;
            }
            _real.ConnectTo(serverHost);
        }
    }
}
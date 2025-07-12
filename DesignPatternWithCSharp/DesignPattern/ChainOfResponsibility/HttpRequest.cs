namespace DesignPattern.ChainOfResponsibility
{
    public enum FirewallResult
    {
        Allowed,
        BlockeByIP,
        BlockeByPath,
        BlockedByratelimit,
    };

    public delegate FirewallResult FirewallCheck(HttpRequest request);

    public class Firewall
    {
        private readonly List<FirewallCheck> _handlers = new();
        public Firewall Addhandler(FirewallCheck handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public FirewallResult Handle(HttpRequest request)
        {
            foreach (var handler in _handlers)
            {
                var result = handler(request);
                if (result != FirewallResult.Allowed)
                {
                    return result;
                }
            }
            return FirewallResult.Allowed;
        }
    }

    public class HttpRequest
    {
        public string IP { get; set; }
        public string Path { get; set; }
        public int RequestsPerMinute { get; set; }
    }


    public abstract class FirewallHandler
    {
        protected FirewallHandler _next;
        public void SetNext(FirewallHandler next)
        {
            _next = next;
        }

        public abstract FirewallResult Handle(HttpRequest request);
    }

    public class IPHandler : FirewallHandler
    {
        private readonly List<string> _allowedIPs;
        public IPHandler(IEnumerable<string> allowedIPs)
        {
             _allowedIPs = allowedIPs.ToList();
        }
        public override FirewallResult Handle(HttpRequest request)
        {
            if (!_allowedIPs.Contains(request.IP))
            {
                return FirewallResult.BlockeByIP;
            }
            return _next?.Handle(request) ?? FirewallResult.Allowed;
        }
    }
}
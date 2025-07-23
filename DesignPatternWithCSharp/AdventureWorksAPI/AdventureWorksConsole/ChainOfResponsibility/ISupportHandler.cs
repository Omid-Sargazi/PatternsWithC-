namespace AdventureWorksConsole.ChainOfResponsibility
{
    public interface ISupportHandler
    {
        void HandleRequest(SupportRequest request);
    }

    public class SupportRequest
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public SupportRequest(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }

    public abstract class SupportHandler : ISupportHandler
    {
        protected SupportHandler _nextHandler;
        protected void SetNextHandler(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(SupportRequest request);
    }

    public class Level1SupportHandler : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Type == "technical1")
            {
                Console.WriteLine($"L2 Support handled the request: {request.Description}");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("L2 cannot handle this request, passing to next level...");
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No handler available for this request!");
            }
        }
    }

    public class Level2SupportHandler : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Type == "technical1")
            {
                Console.WriteLine($"L2 Support handled the request: {request.Description}");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("L2 cannot handle this request, passing to next level...");
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No handler available for this request!");
            }
        }
    }

    public class Level3SupportHandler : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.Type == "advanced")
            {
                Console.WriteLine($"L3 Support handled the request: {request.Description}");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("L3 cannot handle this request, passing to next level...");
                _nextHandler.HandleRequest(request);
            }

            else
            {
                Console.WriteLine("No handler available for this request!");
            }
        }
    }

    
}
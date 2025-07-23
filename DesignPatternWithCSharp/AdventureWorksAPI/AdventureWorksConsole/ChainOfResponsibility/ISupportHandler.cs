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
        public void SetNextHandler(SupportHandler nextHandler)
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

    public class HandleRequest
    {
        public static void Run()
        {
            var l1Support = new Level1SupportHandler();
            var l2Support = new Level2SupportHandler();
            var l3Support = new Level3SupportHandler();

            l1Support.SetNextHandler(l2Support);
            l2Support.SetNextHandler(l3Support);

            var request1 = new SupportRequest("General", "Customer needs help with account setup");
            var request2 = new SupportRequest("Technical", "Customer reports a server error");
            var request3 = new SupportRequest("Advanced", "Customer needs custom integration");
            var request4 = new SupportRequest("Unknown", "Unknown issue");

                Console.WriteLine("Processing request 1:");
            l1Support.HandleRequest(request1);

            Console.WriteLine("\nProcessing request 2:");
            l1Support.HandleRequest(request2);

            Console.WriteLine("\nProcessing request 3:");
            l1Support.HandleRequest(request3);

            Console.WriteLine("\nProcessing request 4:");
            l1Support.HandleRequest(request4);
        }
    }


}
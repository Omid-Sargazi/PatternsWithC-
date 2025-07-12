namespace DesignPattern.ChainOfResponsibility
{
    public abstract class SupportHandler
    {
        protected SupportHandler _next;
        public void SetNext(SupportHandler nextHandler)
        {
            _next = nextHandler;
        }

        public abstract void Handle(string requestType);
    }

    public class Level1Support : SupportHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "General")
                Console.WriteLine($"Technical Engineer handle the request.");
            else if (_next != null)
                _next.Handle(requestType);
        }
    }

    public class TechnicalSupport : SupportHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "Technical")
                Console.WriteLine($"Technical Engineer handled the request");
            else if (_next != null)
                _next.Handle(requestType);
        }
    }

    public class ManagerSupport : SupportHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "Complaint")
                Console.WriteLine($"Manager Handle the request.");
            else
                Console.WriteLine("Unknown request. No handler could process it.");
        }
    }
}
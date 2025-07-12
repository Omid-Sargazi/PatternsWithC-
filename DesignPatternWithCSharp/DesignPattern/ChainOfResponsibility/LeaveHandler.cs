using System.Linq.Expressions;

namespace DesignPattern.ChainOfResponsibility
{
     public enum LeaveReason
    {
        Personal,
        Study,
        Medical,
        Vacation,
        Other
    };
    public class LeaveRequestt
    {
        public string EmployeeName { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveReason Reason { get; set; }
    }
    public class LeaveHandler
    {
        private readonly Func<LeaveRequestt, bool> _canHandle;
        private readonly string _handlerName;
        private LeaveHandler _next;

        public LeaveHandler(string handlerName, Func<LeaveRequestt, bool> canHandle)
        {
            _handlerName = handlerName;
            _canHandle = canHandle;
        }

        public LeaveHandler SetNext(LeaveHandler nexHandler)
        {
            _next = nexHandler;
            return nexHandler;
        }


        public void Handle(LeaveRequestt request)
        {
            if (_canHandle(request))
                Console.WriteLine($"✅ {_handlerName} approved {request.EmployeeName}'s leave for {request.NumberOfDays} days. Reason: {request.Reason}");
            else if (_next != null)
                _next.Handle(request);
            else
            {
                Console.WriteLine($"❌ No handler could approve {request.EmployeeName}'s leave request.");
            }
        }
    }
}
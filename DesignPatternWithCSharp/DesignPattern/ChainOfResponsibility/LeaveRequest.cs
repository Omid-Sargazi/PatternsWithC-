namespace DesignPattern.ChainOfResponsibility
{
   
    public class LeaveRequest
    {
        public string EmployeeName { get; set; }
        public int NumberOfDays { get; set; }
        public string Reason { get; set; }
    }

    public abstract class LeaveRequestHandler
    {
        protected LeaveRequestHandler _next;
        public void SetNext(LeaveRequestHandler nextHandler)
        {
            _next = nextHandler;
        }

        public abstract void Handle(LeaveRequest request);
    }

    public class TeamLeadHandler : LeaveRequestHandler
    {
        public override void Handle(LeaveRequest request)
        {
            if (request.NumberOfDays <= 2 && request.Reason.ToLower() != "medical")
                Console.WriteLine($"✅ TeamLead approved {request.EmployeeName}'s leave for {request.NumberOfDays} days.");
            else
            {
                _next?.Handle(request);
            }
        }
    }

    public class ProjectManagerHandler : LeaveRequestHandler
    {
        public override void Handle(LeaveRequest request)
        {
            if (request.NumberOfDays <= 5 && request.Reason.ToLower() != "medical")
                Console.WriteLine($"✅ TeamLead approved {request.EmployeeName}'s leave for {request.NumberOfDays} days.");
            else
            {
                _next?.Handle(request);
            }
        }
    }

    public class HRManagerHandler : LeaveRequestHandler
    {
        public override void Handle(LeaveRequest request)
        {
            if (request.NumberOfDays > 5 || request.Reason.ToLower() == "medical")
                Console.WriteLine($"✅ HRManager approved {request.EmployeeName}'s leave for {request.NumberOfDays} days. Reason: {request.Reason}");

            else
            {
                _next?.Handle(request);
            }
        }
    }
}
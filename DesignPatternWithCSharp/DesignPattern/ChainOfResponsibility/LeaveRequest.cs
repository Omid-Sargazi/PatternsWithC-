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

        public abstract void Handler(LeaveRequest request);
    }

    public class TeamLeadHandler : LeaveRequestHandler
    {
        public override void Handler(LeaveRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
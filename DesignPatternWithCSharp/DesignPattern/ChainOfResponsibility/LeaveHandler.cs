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
        
    }
}
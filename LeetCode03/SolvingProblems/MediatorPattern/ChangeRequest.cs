namespace SolvingProblems.MediatorPattern
{
    public class ChangeRequest
    {
        public int Id { get; set; }
        public string Description { get; }
        public ChangeRequest(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public class ProgressReport
    {
        public int TaskId { get; }
        public string Status { get; }
        public ProgressReport(int taskId, string status)
        {
            TaskId = taskId;
            Status = status;
        }
    }
}
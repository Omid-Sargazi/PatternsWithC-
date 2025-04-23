namespace RabbitMQ.StatePattern
{
    public interface ITaskState
    {
        void Assign(TaskContext context, string developer, string changedBy);
        void StartProgress(TaskContext context, string developer, string changedBy);
        void SubmitForReview(TaskContext context, string developer, string changedBy);
        void Review(TaskContext context, string developer, string changedBy);
        void Test(TaskContext context, string developer, string changedBy);
        void EditDescription(TaskContext context, string developer, string changedBy);
        void UpdateProgress(TaskContext context, string developer, string changedBy);
    }
}
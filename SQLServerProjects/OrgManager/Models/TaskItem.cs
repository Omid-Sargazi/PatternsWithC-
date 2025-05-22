namespace OrgManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? ParentTaskId { get; set; }
        public TaskItem? parentTask { get; set; }
        public ICollection<TaskItem>? SubTasks { get; set; }
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
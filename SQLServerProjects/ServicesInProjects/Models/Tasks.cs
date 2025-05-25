namespace ServicesInProjects.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
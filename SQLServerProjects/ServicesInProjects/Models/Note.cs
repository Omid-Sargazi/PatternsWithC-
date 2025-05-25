namespace ServicesInProjects.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
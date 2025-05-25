namespace ServicesInProjects.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tasks> Taskss { get; set; } = new List<Tasks>();
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
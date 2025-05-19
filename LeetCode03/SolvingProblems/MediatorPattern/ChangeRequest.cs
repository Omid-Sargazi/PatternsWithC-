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

   
}
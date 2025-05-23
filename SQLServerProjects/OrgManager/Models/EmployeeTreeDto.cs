namespace OrgManager.Models
{
    public class EmployeeTreeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? ManagerId { get; set; }
        public List<EmployeeTreeDto>? Subordinates { get; set; }
    }
}
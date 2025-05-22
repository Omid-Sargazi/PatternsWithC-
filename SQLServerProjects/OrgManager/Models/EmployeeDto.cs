namespace OrgManager.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }
}
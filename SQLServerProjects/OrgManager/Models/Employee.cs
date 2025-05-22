namespace OrgManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee>? Subordinates { get; set; }
    }
}
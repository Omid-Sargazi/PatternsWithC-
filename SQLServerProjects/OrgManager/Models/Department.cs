namespace OrgManager.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }
        public Department? ParentDepartment { get; set; }
        public ICollection<Department>? SubDepartments { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
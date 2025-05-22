namespace OrgManager.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public List<SubCategoryDto>? SubCategories { get; set; }
    }


    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
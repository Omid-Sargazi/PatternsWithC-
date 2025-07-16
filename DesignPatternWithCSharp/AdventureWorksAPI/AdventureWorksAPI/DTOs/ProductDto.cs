namespace AdventureWorksAPI.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal? ListPrice { get; set; }
    }

    public class ProductWithSubcategoryDto
    {
        public string ProductName { get; set; }
        public string SubcategoryName { get; set; }
    }
}
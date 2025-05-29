using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("ProductCategory", Schema = "SalesLT")]
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
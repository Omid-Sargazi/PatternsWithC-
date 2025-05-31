using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("ProductModel", Schema = "SalesLT")]
    public class ProductModel
    {
        [Key]
        public int ProductModelID { get; set; }
        public string? Name { get; set; }
    }
}
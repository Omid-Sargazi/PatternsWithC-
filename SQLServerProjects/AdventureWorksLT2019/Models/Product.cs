using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("Product", Schema = "SalesLT")]
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public decimal? ListPrice { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ProductModelID { get; set; }

        [ForeignKey("ProductCategoryID")]
        public ProductCategory? ProductCategory { get; set; }
        [ForeignKey("ProductModelID")]
         public ProductModel? ProductModel { get; set; }
    }

    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public string? SalesOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
       

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
        
    }
}
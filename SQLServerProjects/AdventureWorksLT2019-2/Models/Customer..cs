using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019_2.Models
{
    [Table("Customer", Schema = "SalesLT")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? CompanyName { get; set; }
    }

    [Table("Product", Schema = "SalesLT")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
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
        public string? SalesOrderNumber { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalDue { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
    }
}
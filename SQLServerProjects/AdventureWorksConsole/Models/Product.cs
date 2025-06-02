using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksConsole.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal ListPrice { get; set; }
        public bool MakeFlag { get; set; }
        public DateTime SellStartDate { get; set; }
    }

    [Table("ProductModel", Schema = "Production")]
    public class ProductModel
    {
        [Key]
        public int ProductModelId { get; set; }
        public string? Name { get; set; }
    }

    [Table("SalesOrderDetail", Schema = "Sales")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
    }

    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? AccountNumber { get; set; }
    }
}
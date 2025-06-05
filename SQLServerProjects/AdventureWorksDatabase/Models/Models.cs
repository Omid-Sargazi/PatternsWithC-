using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace AdventureWorksDatabase.Models
{
    [Table("ProductReview", Schema = "Production")]
    public class ProductReview
    {
        [Key]
        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; }
        public string Comments { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

    }

    [Table("Product", Schema = "Production")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }

    }

    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

    }
    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [Table("SalesOrderHeader", Schema = "Sales")]
    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int SalesOrderNumber { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int? SalesPersonID { get; set; }
    }

    [Table("SalesOrderDetail", Schema = "Sales")]
    public class SalesOrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int SalesOrderID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SalesOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }

        public decimal LineTotal { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [ForeignKey("SalesOrderID")]
        public SalesOrderHeader SalesOrderHeader { get; set; }
    }


}
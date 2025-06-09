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
        public string? ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? Comments { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

    }

    [Table("Product", Schema = "Production")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails = new List<SalesOrderDetail>();

    }

    [Table("Customer", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("PersonId")]
        public int? PersonId { get; set; }
        public Person Person { get; set; }
        public string AccountNumber { get; set; }
        public ICollection<SalesOrderHeader> SalesOrdersHeaders { get; set; } = new List<SalesOrderHeader>();

    }
    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }

    [Table("SalesOrderHeader", Schema = "Sales")]
    public class SalesOrderHeader
    {
        [Key]
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string SalesOrderNumber { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? SalesPersonID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDue { get; set; }
        public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
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
        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
        [ForeignKey("SalesOrderID")]
        public SalesOrderHeader? SalesOrderHeader { get; set; }
    }

   [Table("BusinessEntityAddress", Schema = "Person")]
    public class BusinessEntityAddress
    {
        [Key]
        [Column(Order = 0)]
        public int BusinessEntityId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int AddressId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AddressTypeId { get; set; }

        // ⛓ Navigation Properties
        public virtual BusinessEntity BusinessEntity { get; set; }  // مثل Person
        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
    [Table("Address", Schema = "Person")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        [MaxLength(60)]
        public string AddressLine1 { get; set; }

        [MaxLength(60)]
        public string AddressLine2 { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        public int StateProvinceId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PostalCode { get; set; }

        public System.Guid RowGuid { get; set; }

        public DateTime ModifiedDate { get; set; }

        // 🔁 Navigation
        // public virtual StateProvince StateProvince { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    }
    [Table("AddressType", Schema = "Person")]
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public System.Guid RowGuid { get; set; }

        public DateTime ModifiedDate { get; set; }

        // 🔁 Navigation
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    }
    [Table("BusinessEntity", Schema = "Person")]
    public class BusinessEntity
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public bool RowGuid { get; set; }

        public DateTime ModifiedDate { get; set; }

        //  Navigation
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

        // اگر این BusinessEntity درواقع Person هست:
        public virtual Person Person { get; set; }
    }


}
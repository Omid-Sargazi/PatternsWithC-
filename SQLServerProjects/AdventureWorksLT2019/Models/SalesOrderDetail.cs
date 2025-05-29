using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksLT2019.Models
{
    [Table("SalesOrderDetail", Schema = "SalesLT")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductID { get; set; }

        [ForeignKey("SalesOrderID")]
        public SalesOrderHeader? SalesOrderHeader { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    }   
}
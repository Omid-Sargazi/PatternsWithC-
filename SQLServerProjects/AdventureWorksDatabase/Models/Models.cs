using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
    }

    [Table("Product", Schema = "Production")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }

    }
}
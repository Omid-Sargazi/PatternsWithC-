namespace AdventureWorksAPI.DTOs
{
    public class CustomerSpendingDto
    {
        public int? CustomerId { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
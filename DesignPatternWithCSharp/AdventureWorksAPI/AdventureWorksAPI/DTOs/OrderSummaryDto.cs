namespace AdventureWorksAPI.DTOs
{
    public class OrderSummaryDto
    {
        public int SalesOrderId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
    }
}
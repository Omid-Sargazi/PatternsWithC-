using AdventureWorksAPI.DTOs;

namespace AdventureWorksAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderSummaryDto>> GetOrdersWithQtyOver10Async();
        Task<int> GetTotalOrderCountAsync();
        Task<decimal> GetHighValueOrderSumAsync();
    }
}
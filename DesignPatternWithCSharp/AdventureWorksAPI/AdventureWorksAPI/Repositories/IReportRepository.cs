using AdventureWorksAPI.DTOs;

namespace AdventureWorksAPI.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<CategoryProductCountDto>> GetProductCountsPerCategoryAsync();
        Task<IEnumerable<CustomerSpendingDto>> GetTotalSpentPerCustomerAsync();
        Task<IEnumerable<ProductNoOrderDto>> GetProductWithNoOrderAsync();
        Task<IEnumerable<ProductAvgQtyDto>> GetAvgOrderQtyPerProductAsync();
        Task<IEnumerable<TopOrderDto>> GetTop10OrdersAsync();
    }
}
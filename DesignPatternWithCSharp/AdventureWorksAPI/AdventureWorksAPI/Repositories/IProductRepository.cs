using AdventureWorksAPI.DTOs;

namespace AdventureWorksAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetTop10ProductsAsync();
        Task<IEnumerable<ProductDto>> GetProductsOver1000Async();
        Task<IEnumerable<ProductDto>> GetOrderedByPriceDescAsync();
        Task<int> GetTotalProductCountAsync();
        Task<IEnumerable<ProductWithSubcategoryDto>> GetProductsWithSubcategoryAsync();
    }
}
using AdventureWorksAPI.DTOs;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorks2019Context _context;
        public ProductRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDto>> GetOrderedByPriceDescAsync()
        {
            return await _context.Products
            .OrderByDescending(p => p.ListPrice)
            .Select(p => new ProductDto
            {
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                ListPrice = p.ListPrice,
            }).ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsOver1000Async()
        {
            return await _context.Products
            .Where(p => p.ListPrice > 1000)
            .Select(p => new ProductDto
            {
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                ListPrice = p.ListPrice
            }).ToListAsync();
        }

        public async Task<IEnumerable<ProductWithSubcategoryDto>> GetProductsWithSubcategoryAsync()
        {
            return await (from p in _context.Products
                          join ps in _context.ProductSubcategories
                          on p.ProductSubcategoryId equals ps.ProductSubcategoryId
                          select new ProductWithSubcategoryDto
                          {
                              ProductName = p.Name,
                              SubcategoryName = p.Name
                          }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetTop10ProductsAsync()
        {
            return await _context.Products
            .Select(p => new ProductDto
            {
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                ListPrice = p.ListPrice,
            }).Take(10).ToListAsync();
        }

        public async Task<int> GetTotalProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
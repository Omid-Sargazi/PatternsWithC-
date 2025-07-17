using AdventureWorksAPI.DTOs;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AdventureWorks2019Context _context;
        public ReportRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductAvgQtyDto>> GetAvgOrderQtyPerProductAsync()
        {
            return await _context.SalesOrderDetails
            .GroupBy(o => o.ProductId)
            .Select(g => new ProductAvgQtyDto
            {
                ProductId = g.Key,
                AvgQty = g.Average(x => x.OrderQty)
            }).OrderByDescending(x => x.AvgQty)
            .ToListAsync();
        }

        public async Task<IEnumerable<CategoryProductCountDto>> GetProductCountsPerCategoryAsync()
        {
            return await _context.Products
            .Where(p => p.ProductSubcategoryId != null)
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductSubcategoryId,
                (p, ps) => new { p, ps }
            )
            .Join(_context.ProductCategories,
                temp => temp.ps.ProductCategoryId,
                pc => pc.ProductCategoryId,
                (temp, pc) => new { pc.Name }
            )
            .GroupBy(x => x.Name)
            .Select(g => new CategoryProductCountDto
            {
                Category = g.Key,
                ProductCount = g.Count()
            })
            .OrderByDescending(x => x.ProductCount).ToListAsync();
        }

        public async Task<IEnumerable<ProductNoOrderDto>> GetProductWithNoOrderAsync()
        {
            return await _context.Products
            .GroupJoin(_context.SalesOrderDetails,
                p => p.ProductId,
                sod => sod.ProductId,
                (p, sods) => new { p, sods }
            ).Where(x => !x.sods.Any())
            .Select(x => new ProductNoOrderDto
            {
                ProductId = x.p.ProductId,
                Name = x.p.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<TopOrderDto>> GetTop10OrdersAsync()
        {
            return await _context.SalesOrderHeaders
           .OrderByDescending(o => o.TotalDue)
           .Take(10)
           .Select(o => new TopOrderDto
           {
               SalesOrderId = o.SalesOrderId,
               TotalDue = o.TotalDue
           }).ToListAsync();
        }

        public async Task<IEnumerable<CustomerSpendingDto>> GetTotalSpentPerCustomerAsync()
        {
            return await _context.SalesOrderHeaders
            .GroupBy(o => o.CustomerId)
            .Select(g => new CustomerSpendingDto
            {
                CustomerId = g.Key,
                TotalSpent = g.Sum(x => x.TotalDue)
            })
            .OrderByDescending(x => x.TotalSpent)
            .ToListAsync();
        }
    }

}
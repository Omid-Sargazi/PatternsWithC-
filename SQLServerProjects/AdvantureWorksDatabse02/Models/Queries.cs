using System.ComponentModel.DataAnnotations;
using System.Net;
using AdvantureWorksDatabse02.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvantureWorksDatabse02.Models
{
    public class AdventureWorksQueries
    {
        private readonly AdventureWorksContext _context;
        public AdventureWorksQueries(AdventureWorksContext context)
        {
            _context = context;
        }
    public class CategorySalesResult
    {
        public string CategoryName { get; set; }
        public int ProductsSold { get; set; }
        public decimal TotalSales { get; set; }
        public decimal PercentageOfTotalSales { get; set; }

    }
        public async Task<List<CategorySalesResult>> GetCategorySalesAsync()
        {
            var totalSales = await _context.SalesOrderDetails.SumAsync(sod => sod.LineTotal);
            return await _context.SalesOrderDetails
            .Include(sod => sod.Product)
            .ThenInclude(p => p.ProductSubcategory)
            .ThenInclude(psc => psc.ProductCategory)
            .Where(sod => sod.Product.ProductSubcategory != null)
            .GroupBy(sod => sod.Product.ProductSubcategory.ProductCategory.Name)
            .Select(g => new CategorySalesResult
            {
                CategoryName = g.Key,
                ProductsSold = g.Select(sod => sod.ProductID).Distinct().Count(),
                TotalSales = g.Sum(sod => sod.LineTotal),
                PercentageOfTotalSales = Math.Round(g.Sum(sod => sod.LineTotal) * 100 / totalSales)
            }).OrderByDescending(x => x.TotalSales)
            .ToListAsync();
        }
    }

}
using System.Threading.Tasks;
using AdventureWorksAPI.Models;

namespace AdventureWorksConsole.QueriesExample
{
    public class ProductRanked
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();

        public static void RunProductRanked()
        {
            var result = _context.Products
            .Join(_context.ProductSubcategories,
            p => p.ProductSubcategoryId,
            ps => ps.ProductSubcategoryId,
            (p, ps) => new { p, ps }
            ).Join(_context.ProductCategories,
                temp => temp.ps.ProductCategoryId,
                pc => pc.ProductCategoryId,
                (temp, pc) => new
                {
                    temp.p.Name,
                    temp.p.ListPrice,
                    Category = pc.Name
                }
            ).GroupBy(x => x.Category)
            .SelectMany(g => g.OrderByDescending(x => x.ListPrice))
            .Take(3).Select((item, index) => new
            {
                item.Name,
                item.ListPrice,
                item.Category,
                RowNum = index + 1,
            }).ToList();
            
        }
    }
}
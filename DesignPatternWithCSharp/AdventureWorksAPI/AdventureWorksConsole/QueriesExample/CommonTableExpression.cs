using AdventureWorksAPI.Models;

namespace AdventureWorksConsole.QueriesExample
{
    public class CommonTableExpression
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();

        public static void RunQuery()
        {
            var products = _context.Products
            .Join(_context.ProductSubcategories,
                p => p.ProductSubcategoryId,
                ps => ps.ProductSubcategoryId,
                (p, ps) => new { p, ps }
            )
            .Join(_context.ProductCategories,
                temp => temp.ps.ProductCategoryId,
                pc => pc.ProductCategoryId,
                (temp, pc) => new
                {
                    Product = temp.p.Name,
                    temp.p.ListPrice,
                    Category = pc.Name
                }
            ).OrderByDescending(x => x.ListPrice)
            .ToList();

            foreach (var item in products)
            {
                Console.WriteLine($"Product:{item.Product},Category:{item.Category},ListPrice:{item.ListPrice}");
            }
        }
    }
}
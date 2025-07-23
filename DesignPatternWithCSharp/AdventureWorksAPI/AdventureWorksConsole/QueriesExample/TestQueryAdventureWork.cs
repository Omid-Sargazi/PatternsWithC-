using System.Threading.Tasks;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.QueriesExample
{
    public class TestQueryAdventureWork
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();

        public static async Task Run()
        {
            var query = await _context.Products
           .Include(p => p.ProductSubcategory)
           .Where(p => p.ProductSubcategory != null)
           .Take(3).ToListAsync();


            var query2 = await _context.Products
            .Include(p => p.ProductSubcategory)
            .Where(p => p.ListPrice > 1000)
            .Take(3).ToListAsync();

            foreach (var item in query2)
            {
                Console.WriteLine($"Product: {item.Name},ListPrice:{item.ListPrice} Subcategory: {item.ProductSubcategory.Name}");
            }
        }
         
    }
}
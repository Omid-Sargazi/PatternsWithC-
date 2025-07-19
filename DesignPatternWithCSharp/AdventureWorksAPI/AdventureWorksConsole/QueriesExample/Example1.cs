using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksConsole.QueriesExample
{
    public class Example1
    {
        protected static readonly AdventureWorks2019Context _context = new AdventureWorks2019Context();
        // public Example1(AdventureWorks2019Context context)
        // {
        //     _context = context;
        // }
        public static async Task Run()
        {
            var result = await _context.SalesOrderDetails.Where(x => x.ProductId == 870)
            .Select(x => new { x.SalesOrderId, x.OrderQty })
            .ToListAsync();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.SalesOrderId},{item.OrderQty}");
            }
            
        }
    }
}
using AdventureWorksAPI.DTOs;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AdventureWorks2019Context _context;
        public OrderRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public async Task<decimal> GetHighValueOrderSumAsync()
        {
            return await _context.SalesOrderHeaders
            .Where(o => o.TotalDue > 1000)
            .SumAsync(o => o.TotalDue);
        }

        public async Task<IEnumerable<OrderSummaryDto>> GetOrdersWithQtyOver10Async()
        {
            return await _context.SalesOrderDetails
            .Where(o => o.OrderQty > 10)
            .Select(o => new OrderSummaryDto
            {
                SalesOrderId = o.SalesOrderId,
                OrderQty = o.OrderQty,
                ProductId = o.ProductId
            }).ToListAsync();
        }

        public async Task<int> GetTotalOrderCountAsync()
        {
            return await _context.SalesOrderHeaders.CountAsync();
        }
    }

}


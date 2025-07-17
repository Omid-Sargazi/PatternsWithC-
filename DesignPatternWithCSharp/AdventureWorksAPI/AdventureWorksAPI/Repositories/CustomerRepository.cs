using AdventureWorksAPI.DTOs;
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AdventureWorks2019Context _context;
        public CustomerRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerDto>> GetTop5CustomersAsync()
        {
            return await _context.Customers
            .Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                AccountNumber = c.AccountNumber,
            }).Take(5)
            .ToListAsync();
        }
    }
}
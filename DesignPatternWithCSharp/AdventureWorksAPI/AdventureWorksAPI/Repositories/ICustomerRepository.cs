using AdventureWorksAPI.DTOs;

namespace AdventureWorksAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetTop5CustomersAsync();
    }
}
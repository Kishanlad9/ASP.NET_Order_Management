using Order_management.DTOs.Customer;
using Order_management.Models;

namespace Order_management.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllAsync();
        public Task<Customer?> CreateAsync(CreateCustomerDTO customerDto);
        public Task<Customer?> DeleteAsync(int id);
        public Task<Customer?> UpdateAsync(int id, UpdateCustomerDTO customerDto);
        public Task<Customer?> DisableCustomerAsync(int id);
        public Task<Customer?> GetByEmailAsync(string email);
    }
}

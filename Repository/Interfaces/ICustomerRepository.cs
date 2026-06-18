using Order_management.DTOs.Customer;
using Order_management.Models;

namespace Order_management.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllAsync();
        public Task<Customer?> CreateAsync(Customer customer);
        public Task<Customer?> DeleteAsync(int id);
        public Task<Customer?> UpdateAsync(int id, UpdateCustomerDTO dto);
        public Task<Customer?> DisableCustomerAsync(int id);
        public Task<Customer?> GetByEmailAsync(string email);
    }
}

using Microsoft.EntityFrameworkCore;
using Order_management.Data;
using Order_management.DTOs.Customer;
using Order_management.Models;
using Order_management.Repository.Interfaces;

namespace Order_management.Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext)   
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            List<Customer> customers = await _dbContext.Customers.Where(record => record.IsDeleted == false).ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetByEmailAsync(String email)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email && c.IsDeleted == false);
            return customer;
        }

        public async Task<Customer?> CreateAsync(Customer customer) 
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var deletedCustomer = await _dbContext.Customers.FindAsync(id);
            if (deletedCustomer == null) return null;
            _dbContext.Customers.Remove(deletedCustomer);
            await _dbContext.SaveChangesAsync();
            return deletedCustomer;
        }

        public async Task<Customer?> UpdateAsync(int id, UpdateCustomerDTO dto)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null) return null;
            if (!string.IsNullOrWhiteSpace(dto.Name)) customer.Name = dto.Name;
            if (!string.IsNullOrWhiteSpace(dto.Contact)) customer.Contact = dto.Contact;
            if (!string.IsNullOrWhiteSpace(dto.Address)) customer.Address = dto.Address;
            customer.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer?> DisableCustomerAsync(int id)
        {
            var disabledCustomer = await _dbContext.Customers.FindAsync(id);
            if (disabledCustomer == null) return null;
            disabledCustomer.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return disabledCustomer;
        }
    }
}

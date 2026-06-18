using Order_management.DTOs.Customer;
using Order_management.Models;
using Order_management.Repository.Interfaces;
using Order_management.Services.Interfaces;

namespace Order_management.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetByEmailAsync(String email)
        {
            return await _customerRepository.GetByEmailAsync(email);
        }
        public async Task<Customer?> CreateAsync(CreateCustomerDTO customerDto)
        {
            var existingCustomer = await _customerRepository.GetByEmailAsync(customerDto.Email);

            if (existingCustomer != null)
                return null;

            var customer = new Customer
            {
                Name = customerDto.Name,
                Contact = customerDto.Contact,
                Address = customerDto.Address,
                Email = customerDto.Email,
                Password = customerDto.Password
            };

            return await _customerRepository.CreateAsync(customer);
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<Customer?> UpdateAsync(int id, UpdateCustomerDTO customerDto)
        {
            
            return await _customerRepository.UpdateAsync(id, customerDto);
        }

        public async Task<Customer?> DisableCustomerAsync(int id)
        {
            return await _customerRepository.DisableCustomerAsync(id); 
        }
    }
}

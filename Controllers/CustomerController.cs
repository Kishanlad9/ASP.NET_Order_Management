using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_management.DTOs.Customer;
using Order_management.Helpers;
using Order_management.Models;
using Order_management.Services.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            if (!customers.Any())
            {
                return NotFound(
                    ApiResponse<IEnumerable<Customer>>
                    .ErrorResponse("No Data Found."));
            }
            return Ok(ApiResponse<IEnumerable<Customer?>>.SuccessResponse("Data fetched successfully", customers));
        }

        [HttpGet("/CheckEmail/{email}")]
        public async Task<IActionResult> GetByEmailAsync(String email)
        {
            var customer = await _customerService.GetByEmailAsync(email);
            if (customer == null)
            {
                return NotFound(
                    ApiResponse<Customer>
                    .ErrorResponse("Customer not found."));
            }
            return Ok(ApiResponse<Customer>.SuccessResponse("Customer fetched successfully", customer));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDTO customerDto)
        {
            var customer = await _customerService.CreateAsync(customerDto);
            if (customer == null)
            {
                return BadRequest(ApiResponse<Customer?>.ErrorResponse("Error in customer creation."));
            }
            return Ok(ApiResponse<Customer?>.SuccessResponse("Data created successfully", customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var DeletedCustomer = await _customerService.DeleteAsync(id);
            if (DeletedCustomer == null)
            {
                return NotFound(ApiResponse<IEnumerable<Customer?>>.ErrorResponse("Error in data deletion."));
            }
            return Ok(ApiResponse<Customer?>.SuccessResponse("Data deleted successfully", DeletedCustomer));
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerDTO dto)
        {
            var UpdatedCustomer = await _customerService.UpdateAsync(id, dto);
            if (UpdatedCustomer == null) return NotFound(ApiResponse<Customer?>.ErrorResponse("Error in data Updation."));
            return Ok(ApiResponse<Customer?>.SuccessResponse("Customer updated successfully.", UpdatedCustomer));
        }

        [HttpPatch("{id}/disable")]
        public async Task<IActionResult> DisableCustomer(int id)
        {
            var customer = await _customerService.DisableCustomerAsync(id);
            if (customer == null)
            {
                return BadRequest(ApiResponse<Customer>.ErrorResponse("Error in customer deleting."));
            }
            return Ok(ApiResponse<Customer>.SuccessResponse("Data disabled successfully", customer));
        }
    }
}


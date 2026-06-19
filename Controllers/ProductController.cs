using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_management.DTOs.Products;
using Order_management.Service.Interface;

namespace Order_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productservice.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productservice.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductdto dto)
        {
            var response = await _productservice.CreateAsync(dto);
            return Created("", response);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(UpdateProductdto dto,int id)
        {
            return Ok(await _productservice.UpdateAsync(dto, id));
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            return Ok(await _productservice.DeleteAsync(id));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_management.DTOs.Category;
using Order_management.Service.Interface;

namespace Order_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCategoryById(int id)
        {
            var response  = await _categoryService.GetCategoryByIdAsync(id);
            if (!response.Success) return NotFound(response);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategorydto dto)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }
            var response = await _categoryService.CreateCategoryAsync(dto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        
        public async Task<IActionResult>DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);
            if (!response.Success) return NotFound(response);

            return Ok(response);
        }
        private object GenericResponseError (List<string> errors)
        {
            return new
            {
                success = false,
                Message = "Validation failed",
                Errors = errors
            };
        }
    }
}

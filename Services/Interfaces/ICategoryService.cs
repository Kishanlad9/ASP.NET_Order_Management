using Order_management.DTOs.Category;
using Order_management.Helper;
using Order_management.Models;

namespace Order_management.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<GenricResponse<List<CategoryResponsedto>>> GetAllCategoriesAsync();
        Task<GenricResponse<CategoryResponsedto>> GetCategoryByIdAsync(int id);
        Task<GenricResponse<CategoryResponsedto>> CreateCategoryAsync(CreateCategorydto dto);
        Task<GenricResponse<CategoryResponsedto>> UpdateCategoryAsync(int id, UpdateCategorydto dto);
        Task<GenricResponse<bool>> DeleteCategoryAsync(int id);
    }
}

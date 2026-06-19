using Order_management.DTOs.Category;
using Order_management.Helper;
using Order_management.Models;
using Order_management.Repository.Interfaces;
using Order_management.Services.Interfaces;

namespace Order_management.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GenricResponse<List<CategoryResponsedto>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var result = categories.Select(c => new CategoryResponsedto
            {
                Id = c.Id,
                categoryName = c.categoryName,
                Description = c.Description,
                createdAt = c.CreatedAt
            }).ToList();

            return GenricResponse<List<CategoryResponsedto>>.SuccessResponse(result, "Categories retrieved successfully");
        }

        public async Task<GenricResponse<CategoryResponsedto>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return GenricResponse<CategoryResponsedto>.FailureResponse("Category not found");

            var result = new CategoryResponsedto
            {
                Id = category.Id,
                categoryName = category.categoryName,
                Description = category.Description,
                createdAt = category.CreatedAt
            };

            return GenricResponse<CategoryResponsedto>.SuccessResponse(result, "Category retrieved successfully");
        }

        public async Task<GenricResponse<CategoryResponsedto>> CreateCategoryAsync(CreateCategorydto dto)
        {
            var category = new Category
            {
                categoryName = dto.CategoryName,
                Description = dto.Description
            };

            var created = await _categoryRepository.AddAsync(category);

            var result = new CategoryResponsedto
            {
                Id = created.Id,
                categoryName = created.categoryName,
                Description = created.Description,
                createdAt = created.CreatedAt
            };

            return GenricResponse<CategoryResponsedto>.SuccessResponse(result, "Category created successfully");
        }

        public async Task<GenricResponse<CategoryResponsedto>> UpdateCategoryAsync(int id, UpdateCategorydto dto)
        {
            var exists = await _categoryRepository.ExistAsync(id);
            if (!exists)
                return GenricResponse<CategoryResponsedto>.FailureResponse("Category not found");

            var category = new Category
            {
                Id = id,
                categoryName = dto.CategoryName,
                Description = dto.Description
            };

            var updated = await _categoryRepository.UpdateAsync(category);

            if (updated == null)
                return GenricResponse<CategoryResponsedto>.FailureResponse("Category not found");

            var result = new CategoryResponsedto
            {
                Id = updated.Id,
                categoryName = updated.categoryName,
                Description = updated.Description,
                createdAt = updated.CreatedAt
            };

            return GenricResponse<CategoryResponsedto>.SuccessResponse(result, "Category updated successfully");
        }

        public async Task<GenricResponse<bool>> DeleteCategoryAsync(int id)
        {
            var deleted = await _categoryRepository.DeleteAsync(id);

            if (!deleted)
                return GenricResponse<bool>.FailureResponse("Category not found");

            return GenricResponse<bool>.SuccessResponse(true, "Category deleted successfully");
        }
    }
}
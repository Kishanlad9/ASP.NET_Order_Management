using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Order_management.Data;
using Order_management.Models;
using Order_management.Repository.Interfaces;

namespace Order_management.Repository.Implementations
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .OrderByDescending(c => c.CreatedAt).ToListAsync();       
        }
        public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        public async Task<Category>AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?>UpdateAsync(Category category)
        {
            var existing = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (existing == null) return null;
            existing.categoryName = category.categoryName;
            existing.Description = category.Description;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool>DeleteAsync(int id)
        {
            var existing = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (existing == null) return false;
            existing.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool>ExistAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}


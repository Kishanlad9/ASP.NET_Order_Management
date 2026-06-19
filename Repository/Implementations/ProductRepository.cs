using Microsoft.EntityFrameworkCore;
using Order_management.Data;
using Order_management.Models;
using Order_management.Repository.Interfaces;

namespace Order_management.Repository.Implementations
{
    public class ProductRepository : IProdcutRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> UpdateAsync(Product product)
        {
            var existing = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);
            if (existing == null) return null;
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            existing.Category_Id = product.Category_Id;
            await _dbContext.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return false;
            product.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _dbContext.Products.AnyAsync(x => x.Id == id);

        }
    }
}

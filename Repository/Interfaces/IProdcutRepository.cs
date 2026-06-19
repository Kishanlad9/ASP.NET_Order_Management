using Order_management.Models;

namespace Order_management.Repository.Interfaces
{
    public interface IProdcutRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product>UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}

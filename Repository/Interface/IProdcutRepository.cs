using Order_management.Models;


namespace Order_management.Repository.Interface
{
    public interface IProdcutRepository
    {
        Task<List<Products>> GetAllAsync();
        Task<Products?> GetByIdAsync(int id);
        Task<Products> AddAsync(Products product);
        Task<Products>UpdateAsync(Products product);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);

    }
}

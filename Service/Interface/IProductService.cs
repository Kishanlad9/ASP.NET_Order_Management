
using Order_management.DTOs.Products;

using Order_management.Helper;

namespace Order_management.Service.Interface
{
    public interface IProductService
    {
        public Task<GenricResponse<List<ProductResponseDto>>> GetAllAsync();
        public Task<GenricResponse<ProductResponseDto>> GetByIdAsync(int id);
        public Task<GenricResponse<ProductResponseDto>> CreateAsync(CreateProductdto dto);
        public Task<GenricResponse<ProductResponseDto>> UpdateAsync(UpdateProductdto dto, int id);
        public Task<GenricResponse<bool>> DeleteAsync(int id);

    }
}

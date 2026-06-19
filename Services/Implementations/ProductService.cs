using Order_management.DTOs.Products;
using Order_management.Helper;
using Order_management.Models;
using Order_management.Repository.Implementations;
using Order_management.Repository.Interfaces;
using Order_management.Services.Interfaces;

namespace Order_management.Services.Implementations
{
    public class ProductService :IProductService
    {
        private readonly IProdcutRepository _prodcutRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProdcutRepository prodcutRepository, ICategoryRepository categoryRepository)
        {
            _prodcutRepository = prodcutRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<GenricResponse<List<ProductResponseDto>>> GetAllAsync()
        {
            var products = await _prodcutRepository.GetAllAsync();
            var result = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category_Id = p.Category_Id,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName= p.Category?.categoryName ?? "",
                CreatedAt = p.createdAt,

            }).ToList();
            return GenricResponse<List<ProductResponseDto>>.SuccessResponse(result, "Products Fetched Successfully");

        }
        public async Task<GenricResponse<ProductResponseDto>> GetByIdAsync(int id)
        {
            var product = await _prodcutRepository.GetByIdAsync(id);
            if (product == null) return GenricResponse<ProductResponseDto>.FailureResponse("Product Not Found");
            var result = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category_Id = product.Category_Id,
                CategoryName = product.Category?.categoryName ?? "" ,
                CreatedAt = product.createdAt,
            };
            return GenricResponse<ProductResponseDto>
                .SuccessResponse(result, "Product Fetched Successfully");
        }
        public async Task<GenricResponse<ProductResponseDto>> CreateAsync(CreateProductdto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.Category_Id);
            if (category == null) return GenricResponse<ProductResponseDto>.FailureResponse("Category Not Found");

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = (decimal)dto.Price,
                Stock = dto.stock,
                Category_Id = dto.Category_Id
            };

            var createdProduct = await _prodcutRepository.AddAsync(product);
            var result = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category_Id = product.Category_Id,
                CategoryName = category.categoryName,
                CreatedAt = product.createdAt,
            };
            return GenricResponse<ProductResponseDto>.SuccessResponse(result, "Product Created Successfully");
        }
        public async Task<GenricResponse<ProductResponseDto>> UpdateAsync(UpdateProductdto dto, int id)
        {
            var Productexist = await _prodcutRepository.GetByIdAsync(id);
            if (Productexist == null)
            {
                return GenricResponse<ProductResponseDto>.FailureResponse("Product Not Found");
            }
            var category = await _categoryRepository.GetByIdAsync(dto.Category_Id);
            if (category == null)
            {
                return GenricResponse<ProductResponseDto>.FailureResponse("Category Not Found");
            }
            Productexist.Name = dto.Name;
            Productexist.Price = (decimal)dto.Price;
            Productexist.Description = dto.Description;
            Productexist.Category_Id = dto.Category_Id;
            Productexist.Stock = dto.Stock;
            var updatedProduct = await _prodcutRepository.UpdateAsync(Productexist);
            var result = new ProductResponseDto
            {
                Name = updatedProduct.Name,
                Id = updatedProduct.Id,
                Category_Id = updatedProduct.Category_Id,
                Description = updatedProduct.Description,
                Stock = updatedProduct.Stock,
                Price = updatedProduct.Price,
                CategoryName = category.categoryName,
                CreatedAt = updatedProduct.createdAt,
            };
            return GenricResponse<ProductResponseDto>.SuccessResponse(result, "Product Updated Successfully");
        }
        public async Task <GenricResponse<bool>> DeleteAsync(int id)
        {
            var deleted = await _prodcutRepository.DeleteAsync(id);
            if(!deleted)
            {
                return GenricResponse<bool>.FailureResponse("Product Not Found");
            }
            return GenricResponse<bool>.SuccessResponse(true, "Product Deleted Successfully");
        }
    }
}


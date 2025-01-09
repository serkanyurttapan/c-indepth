using Services.Products.Create;
using Services.Products.Update;

namespace Services.Products;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductDto>>> GetTopSellerProductsAsync(int count);
    Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateProductAsync(
        CreateProductRequest createProductRequest);

    Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest updateProductRequest);
    Task<ServiceResult> DeleteProductAsync(int id);
    Task<ServiceResult<IEnumerable<ProductDto>>> GetPaggedAllListAsync(int pageNumber,int pageSize);
}
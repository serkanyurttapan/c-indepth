namespace Services.Products;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductDto>>> GetTopSellerProductsAsync(int count);
    Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateProductAsync(
        CreateProductRequest createProductRequest);
}
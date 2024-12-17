using Repositories.Products;

namespace Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<Product>> GetTopSellerProductsAsync(int count)
    {
        return await _productRepository.GetTopSellerProductsAsync(count);
    }
    
}
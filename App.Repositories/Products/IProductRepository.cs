namespace Repositories.Products;

public interface IProductRepository :IGenericRepository<Product>
{
    public Task <IEnumerable<Product>> GetTopSellerProductsAsync(int count);
}
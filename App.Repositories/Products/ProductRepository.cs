using Microsoft.EntityFrameworkCore;

namespace Repositories.Products;

public class ProductRepository(AppDBContext context) :GenericRepository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetTopSellerProductsAsync(int count)
    {
        return await _context.Products.OrderByDescending(p => p.Stock).Take(count).ToListAsync();
    }
}
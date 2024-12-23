using System.Net;
using Repositories;
using Repositories.Products;

namespace Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetTopSellerProductsAsync(int count)
    {
        var productList = await _productRepository.GetTopSellerProductsAsync(count);
        
        var productDtoList = productList.Select(product => new ProductDto
        {
            Id = product.Id,
            ProductName = product.Name ?? string.Empty
        });
        return new ServiceResult<IEnumerable<ProductDto>>() { Data = productDtoList };
    }
    public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            return ServiceResult<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);
        
        var productDto = new ProductDto
        {
            Id = product.Id,
            ProductName = product.Name ?? string.Empty
        };
        
        return ServiceResult<ProductDto>.Success(productDto);
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(
        CreateProductRequest createProductRequest)
    {
        var product = new Product
        {
            Name = createProductRequest.Name,
            Price = createProductRequest.Price,
            Stock = createProductRequest.Stock
        };
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        
        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse { Id = product.Id },
            HttpStatusCode.Created);
    }
    
    public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest updateProductRequest)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            return ServiceResult.FailNoContent("Product not found", HttpStatusCode.NotFound);
        
        product.Name = updateProductRequest.Name;
        product.Price = updateProductRequest.Price;
        product.Stock = updateProductRequest.Stock;
        
        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        
        return ServiceResult.SuccessNoContent(HttpStatusCode.NoContent);
    }
    public async Task<ServiceResult> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            return ServiceResult.FailNoContent("Product not found", HttpStatusCode.NotFound);
        
        _productRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync();
        
        return ServiceResult.SuccessNoContent();
    }
}

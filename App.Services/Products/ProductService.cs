using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Products;
using Services.Products.Create;
using Services.Products.Update;

namespace Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _map;
    public ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork,IMapper map)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _map = map;
    }
    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetTopSellerProductsAsync(int count)
    {
        var productList = await _productRepository.GetTopSellerProductsAsync(count);
        var result= _map.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(productList);
        return new ServiceResult<IEnumerable<ProductDto>>() { Data = result };
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

    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetPaggedAllListAsync(int pageNumber,int pageSize)
    {
        var size = (pageNumber - 1) * pageSize; 
         var productList= await _productRepository.GetAll().Skip(size).Take(pageSize).ToListAsync();
        var productListDto= (productList.Select(product => new ProductDto()
         {
             Id = product.Id,
             ProductName = product.Name ?? string.Empty,
         }));
        return  ServiceResult<IEnumerable<ProductDto>>.Success(productListDto);
    }
}

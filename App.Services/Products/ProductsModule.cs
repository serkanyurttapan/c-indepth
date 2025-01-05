using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Services.Products;

public static class ProductsModule
{
    public static void AddProductsModule(this IEndpointRouteBuilder services)
    {
        services.MapGet("/getproductbyid/{id}", async (IProductService productService, int id) =>
        {
            var result = await productService.GetProductByIdAsync(id);
            return result;
        }).WithName("GetProductById");

        services.MapPost("/createproduct", async (IProductService productService, CreateProductRequest createProductRequest) =>
        {
            var result = await productService.CreateProductAsync(createProductRequest);
            return result;
        }).WithName("CreateProduct");

        services.MapPut("/updateproduct/{id}", async (IProductService productService, int id, UpdateProductRequest updateProductRequest) =>
        {
            var result = await productService.UpdateProductAsync(id, updateProductRequest);
            return result;
        }).WithName("UpdateProduct");

        services.MapDelete("/deleteproduct/{id}", async (IProductService productService, int id) =>
        {
            var result = await productService.DeleteProductAsync(id);
            return result;
        }).WithName("DeleteProduct");
        
        services.MapGet("/getpagedalllist/{pageNumber}/{pageSize}", async (IProductService productService, int pageNumber, int pageSize) =>
        {
            var result = await productService.GetPaggedAllListAsync(pageNumber, pageSize);
            return result;
        }).WithName("GetPaggedAllList");
    }
}
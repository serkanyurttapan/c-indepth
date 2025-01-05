using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Products;
using FluentValidation.AspNetCore;

namespace Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
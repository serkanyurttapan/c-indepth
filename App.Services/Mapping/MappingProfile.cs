using AutoMapper;
using Repositories.Products;

namespace Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}
using AutoMapper;
using Store.Catalog.Entities;
using Store.Catalog.Services.Dtos;

namespace Store.Catalog.ObjectMapping;

public class CatalogAutoMapperProfile : Profile
{
    public CatalogAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}

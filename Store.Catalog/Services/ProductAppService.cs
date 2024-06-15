using Microsoft.EntityFrameworkCore;
using Store.Catalog.Data;
using Store.Catalog.Entities;
using Store.Catalog.Services.Dtos;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Store.Catalog.Services;

[RemoteService(false)]
public class ProductAppService : CatalogAppService
{
    private readonly CatalogDbContext DbContext;

    public ProductAppService(
        CatalogDbContext dbContext
        )
    {
        DbContext = dbContext;
    }

    // get
    public async Task<ProductDto> GetProductAsync(Guid id)
    {
        var entity = await DbContext.Products.FindAsync(id);
        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }
        // auto mapper
        var dto = ObjectMapper.Map<Product, ProductDto>(entity);
        return dto;
    }

    // create
    public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
    {
        var entity = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);

        await DbContext.Products.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        var dto = ObjectMapper.Map<Product, ProductDto>(entity);
        return dto;
    }

    // update
    public async Task<ProductDto> UpdateProductAsync(Guid id, CreateUpdateProductDto input)
    {
        var entity = await DbContext.Products.FindAsync(id);
        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }
        ObjectMapper.Map(input, entity);
        await DbContext.SaveChangesAsync();
        var dto = ObjectMapper.Map<Product, ProductDto>(entity);
        return dto;
    }

    // delete
    public async Task DeleteProductAsync(Guid id)
    {
        var entity = await DbContext.Products.FindAsync(id);
        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }
        DbContext.Products.Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    // list
    public async Task<List<ProductDto>> GetProductsAsync()
    {
        var entities = await DbContext.Products.ToListAsync();
        var dtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(entities);
        return dtos;
    }
}

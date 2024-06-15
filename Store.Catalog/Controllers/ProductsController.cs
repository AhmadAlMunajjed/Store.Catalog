using Microsoft.AspNetCore.Mvc;
using Store.Catalog.Services;
using Store.Catalog.Services.Dtos;

namespace Store.Catalog.Controllers;

[Route("api/product")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductAppService ProductAppService;

    public ProductsController(
               ProductAppService productAppService
               )
    {
        ProductAppService = productAppService;
    }

    [HttpGet]
    public async Task<List<ProductDto>> GetProductsAsync()
    {
        return await ProductAppService.GetProductsAsync();
    }


    [HttpGet("{id}")]
    public async Task<ProductDto> GetProductAsync(Guid id)
    {
        return await ProductAppService.GetProductAsync(id);
    }

    [HttpPost]
    public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
    {
        return await ProductAppService.CreateProductAsync(input);
    }

    [HttpPut("{id}")]
    public async Task<ProductDto> UpdateProductAsync(Guid id, CreateUpdateProductDto input)
    {
        return await ProductAppService.UpdateProductAsync(id, input);
    }

    [HttpDelete("{id}")]
    public async Task DeleteProductAsync(Guid id)
    {
        await ProductAppService.DeleteProductAsync(id);
    }
}

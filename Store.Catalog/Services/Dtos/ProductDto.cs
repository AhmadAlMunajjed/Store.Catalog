using Volo.Abp.Application.Dtos;

namespace Store.Catalog.Services.Dtos;

public class ProductDto : EntityDto<Guid>
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
}

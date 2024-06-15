using Volo.Abp.Domain.Entities;

namespace Store.Catalog.Entities;

public class Product : Entity<Guid>
{
    public Product()
    {
        Id = Guid.NewGuid();
    }

    public required string Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
}

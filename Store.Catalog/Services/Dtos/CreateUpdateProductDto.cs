using System.ComponentModel.DataAnnotations;

namespace Store.Catalog.Services.Dtos;

public class CreateUpdateProductDto
{
    [Required]
    public string? Name { get; set; }
    
    
    public string? Description { get; set; }
    
    [Required]
    public double? Price { get; set; }
}

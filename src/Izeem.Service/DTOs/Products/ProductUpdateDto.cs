using Izeem.Service.DTOs.Assets;
using Microsoft.AspNetCore.Http;

namespace Izeem.Service.DTOs.Products;

public class ProductUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public IFormFile Asset { get; set; } = null;
}
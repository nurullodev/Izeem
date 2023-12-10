using Izeem.Service.DTOs.Products;

namespace Izeem.Service.DTOs.ProductCategories;

public class ProductCategoryResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductResultDto> Products { get; set; }
}

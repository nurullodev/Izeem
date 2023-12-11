using Izeem.Service.DTOs.Assets;
using Izeem.Service.DTOs.ProductCategories;

namespace Izeem.Service.DTOs.Products;

public class ProductResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int SaleCount { get; set; }
    public ProductCategoryResultDto Category { get; set; }
    public AssetResultDto Attachment { get; set; }
}
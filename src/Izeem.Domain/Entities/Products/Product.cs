using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Assets;

namespace Izeem.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public long? AssetId { get; set; }
    public Asset Asset { get; set; }
}
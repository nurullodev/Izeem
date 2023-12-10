namespace Izeem.Service.DTOs.Products;

public class ProductUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
}

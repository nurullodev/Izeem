using Izeem.Service.DTOs.Products;

namespace Izeem.Service.DTOs.Orders;

public class OrderItemResultDto
{
    public long Id { get; set; }
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderResultDto Order { get; set; }
    public ProductResultDto Product { get; set; }
}

namespace Izeem.Service.DTOs.Orders;

public class OrderItemUpdateDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
}

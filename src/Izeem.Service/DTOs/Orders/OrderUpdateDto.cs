using Izeem.Domain.Enums;

namespace Izeem.Service.DTOs.Orders;

public class OrderUpdateDto
{
    public long Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Status Status { get; set; }
    public PaymentType Payment { get; set; }
    public decimal DeliveryFee { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public long SupplierId { get; set; }
}
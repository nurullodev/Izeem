using Izeem.Domain.Enums;
using Izeem.Service.DTOs.Addresses;
using Izeem.Service.DTOs.Suppliers;
using Izeem.Service.DTOs.Users;

namespace Izeem.Service.DTOs.Orders;

public class OrderResultDto
{
    public long Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Status Status { get; set; }
    public PaymentType Payment { get; set; }
    public decimal DeliveryFee { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserResultDto User { get; set; }
    public AddressResultDto Address { get; set; }
    public SupplierResultDto Supplier { get; set; }
}

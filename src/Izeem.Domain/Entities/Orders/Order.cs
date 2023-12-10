using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Addresses;
using Izeem.Domain.Entities.Payments;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Domain.Entities.Users;
using Izeem.Domain.Enums;

namespace Izeem.Domain.Entities.Orders;

public class Order : Auditable
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public Status Status { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal TotalPrice { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
}

using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Carts;
using Izeem.Domain.Entities.Products;

namespace Izeem.Domain.Entities.Orders;

public class OrderItem : Auditable
{
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Summ { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public Product Product { get; set; }
    public long ProductId { get; set; }

    public long CartItemId { get; set; }
    public CartItem CartItem { get; set; }
}
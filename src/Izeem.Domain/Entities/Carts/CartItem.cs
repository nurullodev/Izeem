using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Products;

namespace Izeem.Domain.Entities.Carts;

public class CartItem : Auditable
{
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Summ { get; set; }
    public long CartId { get; set; }
    public Cart Cart { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}

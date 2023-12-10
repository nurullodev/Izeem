namespace Izeem.Service.DTOs.Carts;

public class CartItemUpdateDto
{
    public long Id { get; set; }
    public double Quantity { get; set; }
    public decimal Price { get; set; }
    public int CartId { get; set; }
    public long ProductId { get; set; }
}
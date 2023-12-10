namespace Izeem.Service.DTOs.Carts;

public class CartItemCreationDto
{
    public ICollection<CartItemDetail> Details { get; set; }
}
using Izeem.Service.DTOs.Users;

namespace Izeem.Service.DTOs.Carts;

public class CartResultDto
{
    public long Id { get; set; }
    public decimal TotalPrice { get; set; }
    public UserResultDto User { get; set; }
}

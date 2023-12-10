using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Users;

namespace Izeem.Domain.Entities.Carts;

public class Cart : Auditable
{
    public decimal TotalPrice { get; set; }
    public long? UserId { get; set; }
    public User User { get; set; }
}

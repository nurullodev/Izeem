using Izeem.Service.DTOs.Carts;

namespace Izeem.Service.Interfaces.Carts;

public interface ICartService
{
    Task<CartResultDto> RetrieveByUserIdAsync(long userId);
}
using Izeem.Service.DTOs.Carts;

namespace Izeem.Service.Interfaces.Carts;

public interface ICartItemService
{
    Task<IEnumerable<CartItemResultDto>> AddAsync(CartItemCreationDto dto);
    Task<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<bool> RemoveAllAsync(long cartId);
    Task<CartItemResultDto> RetrieveByIdAsync(long id);
    IEnumerable<CartItemResultDto> RetrieveAll(long? cartId = null);
}
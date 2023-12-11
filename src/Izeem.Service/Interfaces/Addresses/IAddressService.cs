using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Addresses;

namespace Izeem.Service.Interfaces.Addresses;

public interface IAddressService
{
    Task<AddressResultDto> AddAsync(AddressCreationDto dto);
    Task<AddressResultDto> ModifyAsync(AddressUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<AddressResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<AddressResultDto>> RetrieveAllAsync(PaginationParams pagination);
}
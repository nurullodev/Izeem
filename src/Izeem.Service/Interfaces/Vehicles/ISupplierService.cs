using Izeem.Service.DTOs.Suppliers;

namespace Izeem.Service.Interfaces.Vehicles;

public interface ISupplierService
{
    Task<SupplierResultDto> AddAsync(SupplierCreationDto dto);
    Task<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<SupplierResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<SupplierResultDto>> RetrieveAllAsync();
}
using Izeem.Service.DTOs.Vehicles;

namespace Izeem.Service.Interfaces.Vehicles;

public interface IVehicleService
{
    Task<VehicleResultDto> AddAsync(VehicleCreationDto dto);
    Task<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<VehicleResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<VehicleResultDto>> RetrieveAllAsync();
}
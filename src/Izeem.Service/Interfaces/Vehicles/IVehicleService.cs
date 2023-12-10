using Izeem.Service.DTOs.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Vehicles;

public interface IVehicleService
{
    Task<VehicleResultDto> AddAsync(VehicleCreationDto dto);
    Task<VehicleResultDto> ModifyAsync(VehicleUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<VehicleResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<VehicleResultDto>> RetrieveAllAsync();
}
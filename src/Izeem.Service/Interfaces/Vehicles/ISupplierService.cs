using Izeem.Service.DTOs.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Vehicles;

public interface ISupplierService
{
    Task<SupplierResultDto> AddAsync(SupplierCreationDto dto);
    Task<SupplierResultDto> ModifyAsync(SupplierUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<SupplierResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<SupplierResultDto>> RetrieveAllAsync();
}
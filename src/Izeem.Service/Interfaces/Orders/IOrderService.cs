using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Orders;

public interface IOrderService
{
    Task<OrderResultDto> AddAsync(OrderCreationDto dto);
    Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<OrderResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<OrderResultDto>> RetrieveAllAsync(PaginationParams pagination);
}
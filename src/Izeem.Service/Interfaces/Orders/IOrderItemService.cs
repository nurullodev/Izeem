using Izeem.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Orders;

public interface IOrderItemService
{
    Task<OrderItemResultDto> AddAsync(OrderItemCreationDto dto);
    Task<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<OrderItemResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<OrderItemResultDto>> RetrieveAllAsync();
}
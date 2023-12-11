using Izeem.Service.DTOs.Orders;
using Izeem.Service.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Services.Orders;

public class OrderItemService : IOrderItemService
{
    public Task<OrderItemResultDto> AddAsync(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItemResultDto>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
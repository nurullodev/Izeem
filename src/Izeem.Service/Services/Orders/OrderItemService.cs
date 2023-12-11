using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Orders;
using Izeem.Service.DTOs.Orders;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Orders;

namespace Izeem.Service.Services.Orders;

public class OrderItemService : IOrderItemService
{
    private readonly IRepository<OrderItem> _orderItemRepository;
    private readonly IMapper _mapper;

    public OrderItemService(IRepository<OrderItem> orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<OrderItemResultDto> AddAsync(OrderItemCreationDto dto)
    {
        var orderItem = _mapper.Map<OrderItem>(dto);
        await _orderItemRepository.AddAsync(orderItem);
        await _orderItemRepository.SaveAsync();

        return _mapper.Map<OrderItemResultDto>(orderItem);
    }

    public async Task<OrderItemResultDto> ModifyAsync(OrderItemUpdateDto dto)
    {
        var existingOrderItem = await _orderItemRepository.SelectAsync(order => order.Id.Equals(dto.Id))
             ?? throw new IzeemException(404, "Order item not found");

        _mapper.Map(dto, existingOrderItem);
        _orderItemRepository.Update(existingOrderItem);
        await _orderItemRepository.SaveAsync();

        return _mapper.Map<OrderItemResultDto>(existingOrderItem);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existingOrderItem = await _orderItemRepository.SelectAsync(order => order.Id.Equals(id))
            ?? throw new IzeemException(404, "Order item not found");

        _orderItemRepository.Delete(existingOrderItem);
        await _orderItemRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<OrderItemResultDto>> RetrieveAllAsync()
    {
        var orderItems = _orderItemRepository.SelectAll();
        return _mapper.Map<IEnumerable<OrderItemResultDto>>(orderItems);
    }

    public async Task<OrderItemResultDto> RetrieveByIdAsync(long id)
    {
        var orderItem = await _orderItemRepository.SelectAsync(order => order.Id.Equals(id))
            ?? throw new IzeemException(404, "Order item not found");

        return _mapper.Map<OrderItemResultDto>(orderItem);
    }
}

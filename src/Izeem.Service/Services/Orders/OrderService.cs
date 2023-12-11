using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Configurations;
using Izeem.Domain.Entities.Orders;
using Izeem.Service.DTOs.Orders;
using Izeem.Service.Exceptions;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Orders;

namespace Izeem.Service.Services.Orders;


public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _repository;
    public OrderService(IMapper mapper, IRepository<Order> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<OrderResultDto> AddAsync(OrderCreationDto dto)
    {
        var mappedOrder = _mapper.Map<Order>(dto);
        await _repository.AddAsync(mappedOrder);
        await _repository.SaveAsync();

        return _mapper.Map<OrderResultDto>(mappedOrder);
    }

    public async Task<OrderResultDto> ModifyAsync(OrderUpdateDto dto)
    {
        Order order = await _repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new IzeemException(404, $"This Order is not found with ID = {dto.Id}");

        _mapper.Map(dto, order);
        _repository.Update(order);
        await _repository.SaveAsync();

        return _mapper.Map<OrderResultDto>(order);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Order order = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This Order is not found with ID = {id}");

        _repository.Delete(order);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<OrderResultDto> RetrieveByIdAsync(long id)
    {
        Order order = await _repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new IzeemException(404, $"This Order is not found with ID = {id}");

        return _mapper.Map<OrderResultDto>(order);
    }

    public async Task<IEnumerable<OrderResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        var orders = _repository.SelectAll()
            .ToPagedList(pagination);

        return _mapper.Map<List<OrderResultDto>>(orders);
    }
}
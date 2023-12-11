using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Carts;
using Izeem.Service.DTOs.Carts;
using Izeem.Service.Interfaces.Carts;

namespace Izeem.Service.Services.Carts;

public class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Cart> _repository;
    public CartService(IMapper mapper, IRepository<Cart> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CartResultDto> RetrieveByUserIdAsync(long userId)
    {
        var cart = await _repository.SelectAsync(cart => cart.UserId.Equals(userId));
        return _mapper.Map<CartResultDto>(cart);
    }
}
using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Carts;
using Izeem.Domain.Entities.Products;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.DTOs.Carts;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Carts;

namespace Izeem.Service.Services.Carts;


public class CartItemService : ICartItemService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Cart> _cartRepository;
    private readonly IRepository<CartItem> _cartItemRepository;
    public CartItemService(IMapper mapper, IRepository<CartItem> repository, IRepository<Cart> cartRepository)
    {
        _mapper = mapper;
        _cartItemRepository = repository;
        _cartRepository = cartRepository;
    }

    public async Task<IEnumerable<CartItemResultDto>> AddAsync(CartItemCreationDto dto)
    {
        if (HttpContextHelper.UserId != 0)
            throw new IzeemException(401, "This user is not authorized");

        var cart = await _cartRepository.SelectAsync(cart => cart.UserId.Equals(HttpContextHelper.UserId));

        var product = await _productRepository.SelectAsync(product => product.Id.Equals(HttpContextHelper.UserId));

        var result = new List<CartItemResultDto>();
        foreach (var item in dto.Details)
        {
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                Price = product.Price,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Summ = (decimal)item.Quantity * product.Price
            };

            await _cartItemRepository.AddAsync(cartItem);
            result.Add(_mapper.Map<CartItemResultDto>(cartItem));
        }
        await _cartItemRepository.SaveAsync();

        return result;
    }

    public async Task<CartItemResultDto> ModifyAsync(CartItemUpdateDto dto)
    {
        var cartItem = await _cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(dto.Id))
            ?? throw new IzeemException(404, "Cart item is not found");

        var mappedCartItem = _mapper.Map(dto, cartItem);
        _cartItemRepository.Update(mappedCartItem);
        await _cartItemRepository.SaveAsync();

        return _mapper.Map<CartItemResultDto>(mappedCartItem);
    }

    public async Task<bool> RemoveAllAsync(long cartId)
    {
        var cartItems = _cartItemRepository.SelectAll(cartItem => cartItem.CartId.Equals(cartId));
        foreach (var cartItem in cartItems)
            _cartItemRepository.Destroy(cartItem);

        await _cartItemRepository.SaveAsync();
        return true;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var cartItem = await _cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(id))
            ?? throw new IzeemException(404, "Cart item is not found");

        _cartItemRepository.Destroy(cartItem);
        await _cartItemRepository.SaveAsync();
        return true;
    }

    public IEnumerable<CartItemResultDto> RetrieveAll(long? cartId = null)
    {
        var carts = _cartItemRepository.SelectAll(includes: new[] { "Product" });
        if (cartId is not null)
            carts = carts.Where(cartItem => cartItem.CartId.Equals(cartId));

        return _mapper.Map<IEnumerable<CartItemResultDto>>(carts);
    }

    public async Task<CartItemResultDto> RetrieveByIdAsync(long id)
    {
        var cartItem = await _cartItemRepository.SelectAsync(cartItem => cartItem.Id.Equals(id), includes: new[] { "Product" });

        if (cartItem is null)
            throw new IzeemException(404, "This cart item is not found");

        return _mapper.Map<CartItemResultDto>(cartItem);
    }
}

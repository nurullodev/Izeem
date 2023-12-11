using Izeem.API.Models;
using Izeem.Service.DTOs.Carts;
using Izeem.Service.Interfaces.Carts;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class CartItemsController : BaseController
{
    private readonly ICartItemService _cartItemService;
    public CartItemsController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }


    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(CartItemCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _cartItemService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(CartItemUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _cartItemService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _cartItemService.RemoveAsync(id)
        });


    [HttpDelete("delete-all/{id:long}")]
    public async Task<IActionResult> DeleteAllAsync(long cartId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _cartItemService.RemoveAllAsync(cartId)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _cartItemService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-list")]
    public IActionResult GetAll(long? cartId = null)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = _cartItemService.RetrieveAll(cartId)
        });
}

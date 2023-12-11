using Izeem.API.Models;
using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Orders;
using Izeem.Service.Interfaces.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(OrderCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _orderService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(OrderUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _orderService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _orderService.RemoveAsync(id)
       });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _orderService.RetrieveByIdAsync(id)
       });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(PaginationParams @params)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _orderService.RetrieveAllAsync(@params)
       });
}

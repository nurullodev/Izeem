using Izeem.API.Models;
using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Payments;
using Izeem.Service.Interfaces.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(PaymentCreationDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _paymentService.AddAsync(dto)
       });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _paymentService.RemoveAsync(id)
       });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(PaymentUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _paymentService.ModifyAsync(dto)
       });

    [HttpPut("get/{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _paymentService.RetrieveByIdAsync(id)
       });

    [HttpPut("get-all")]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams pagination,
        [FromQuery] string search)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _paymentService.RetrieveAllAsync(pagination, search)
       });
}

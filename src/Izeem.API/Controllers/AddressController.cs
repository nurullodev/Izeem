using Izeem.API.Models;
using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Addresses;
using Izeem.Service.Interfaces.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class AddressController : BaseController
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AddressCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _addressService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AddressUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _addressService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _addressService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _addressService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _addressService.RetrieveAllAsync(pagination)
        });
}

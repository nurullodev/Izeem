using Izeem.API.Models;
using Izeem.Service.DTOs.Vehicles;
using Izeem.Service.Interfaces.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class VehicleController : BaseController
{
    private readonly IVehicleService _vehicleService;
    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(VehicleCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _vehicleService.AddAsync(dto)
        });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(VehicleUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _vehicleService.ModifyAsync(dto)
        });

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _vehicleService.RemoveAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _vehicleService.RetrieveAllAsync()
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _vehicleService.RetrieveByIdAsync(id)
        });
}

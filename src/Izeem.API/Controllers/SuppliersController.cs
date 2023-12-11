using Izeem.API.Models;
using Izeem.Service.DTOs.Suppliers;
using Izeem.Service.Interfaces.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class SuppliersController : BaseController
{
    private readonly ISupplierService _supplierService;
    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(SupplierCreationDto dto)
    => Ok(new Response
    {
        StatusCode = 200,
        Message = "Success",
        Data = await _supplierService.AddAsync(dto)
    });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(SupplierUpdateDto dto)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await _supplierService.ModifyAsync(dto)
   });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await _supplierService.RemoveAsync(id)
   });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await _supplierService.RetrieveByIdAsync(id)
   });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
   => Ok(new Response
   {
       StatusCode = 200,
       Message = "Success",
       Data = await _supplierService.RetrieveAllAsync()
   });
}

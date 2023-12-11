using Izeem.API.Models;
using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.DTOs.Products;
using Izeem.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ProductCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ProductUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.ModifyAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.RemoveAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.RetrieveByIdAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams pagination)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.RetrieveAllAsync(pagination)
        });


    [HttpPost("image-upload")]
    public async Task<IActionResult> ImageUploadAsync(long productId, [FromForm] AssetCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.ImageUploadAsync(productId, dto)
        });


    [HttpPost("update-image")]
    public async Task<IActionResult> UpdateImageAsync(long productId, [FromForm] AssetCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productService.ModifyImageAsync(productId, dto)
        });
}

using Izeem.API.Models;
using Izeem.Service.DTOs.ProductCategories;
using Izeem.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class ProductCategoriesController : BaseController
{
    private readonly IProductCategoryService _productCategoryService;
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ProductCategoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _productCategoryService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(ProductCategoryUpdateDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _productCategoryService.ModifyAsync(dto)
       });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _productCategoryService.RemoveAsync(id)
       });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _productCategoryService.RetrieveByIdAsync(id)
       });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await _productCategoryService.RetrieveAllAsync()
       });
}

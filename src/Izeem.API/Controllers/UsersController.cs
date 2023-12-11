using Izeem.API.Models;
using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("update/{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserUpdateDto dto)
     => Ok(new Response
     {
         StatusCode = 200,
         Message = "Success",
         Data = await _userService.ModifyAsync(id, dto)
     });


    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userService.RetrieveByIdAsync(id)
        });


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userService.RemoveAsync(id)
        });


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] PaginationParams pagination,
        [FromQuery] string search)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _userService.RetrieveAllAsync(pagination, search)
        });
}
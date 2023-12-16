using Izeem.API.Models;
using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Register;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm] UserRegisterDto dto)
         => Ok(new Response
         {
             StatusCode = 200,
             Message = "Success",
             Data = await _authService.RegisterAsync(dto)
         });

    [HttpPost("send/code")]
    public async Task<IActionResult> SendCodeAsyncI(string email)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _authService.SendCodeForRegisterAsync(email)
        });

    [HttpPost("email/verficode")]
    public async Task<IActionResult> VerifyRegisterAsync([FromForm] VerfiCodeDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _authService.VerifyRegisterAsync(dto)
        });


    [HttpPost("login")]
    public async Task<IActionResult> LogindssdAsync([FromForm] LoginDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _authService.LoginAsync(dto)
        });
}
using Izeem.Service.DTOs;
using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

[Route("api/auth")]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService service)
    {
        _authService = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm]UserRegisterDto dto)
        => Ok(await _authService.RegisterAsync(dto));

    [HttpPost("send/code")]
    public async Task<IActionResult> SendCodeAsyncI(string email)
        =>Ok(await _authService.SendCodeForRegisterAsync(email));

    [HttpPost("register/verify")]
    public async Task<IActionResult> VerifyRegisterAsync([FromForm] VerfyCode dto)
    {
        var srResult = await _authService.VerifyRegisterAsync(dto.Email, dto.Code);
        
        return Ok(new { srResult.Result, srResult.Token });
    }


    [HttpPost("login")]
    public async Task<IActionResult> LogindssdAsync([FromForm] LoginDto dto)
        => Ok( await _authService.LoginAsync(dto));
}
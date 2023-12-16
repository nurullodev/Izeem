using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService service)
    {
        _authService = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogindssdAsync([FromForm] LoginDto dto)
        => Ok( await _authService.LoginAsync(dto));
}
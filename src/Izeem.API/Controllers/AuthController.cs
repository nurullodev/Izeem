using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService service)
    {
        _authService = service;
    }

    [HttpPost]
    public async Task<IActionResult> LogindssdAsync([FromForm] LoginDto dto)
        => Ok( await _authService.LoginAsync(dto));
}

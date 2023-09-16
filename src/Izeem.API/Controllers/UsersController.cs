using Microsoft.AspNetCore.Mvc;

namespace Izeem.API.Controllers;

[Route("a")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAsync(long id)
    {
        return Ok(id);
    }
}

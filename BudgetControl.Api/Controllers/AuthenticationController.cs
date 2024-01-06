using BudgetControl.Contracts.Authentication.Request;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return Ok(request);
    }
}
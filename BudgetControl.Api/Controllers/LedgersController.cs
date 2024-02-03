using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers;
[Route("[controller]")]
[Authorize]
public class LedgersController : ApiController
{
  [HttpGet]
  public IActionResult ListLedgers()
  {
    return Ok(Array.Empty<string>());
  }
}
using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Application.Ledgers.Queries.List;
using BudgetControl.Contracts.Ledgers.Response;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers;
[Route("[controller]")]
[Authorize]
public class LedgersController : ApiController
{
  private readonly IMapper _mapper;

  private readonly ISender _mediator;

  public LedgersController(IMapper mapper, ISender mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }
  [HttpGet]
  public async Task<IActionResult> ListLedgers()
  {
    var userId = HttpContext.User.Claims.First(x => x.Type == "jti").Value;
    ErrorOr<LedgerListResult> ledgerListResult = await _mediator.Send(new LedgerListQuery(userId));
    return ledgerListResult.Match(
      ledgerListResult => Ok(_mapper.Map<LedgerListResponse>(ledgerListResult)),
      errors => Problem(errors)
    );
  }
}
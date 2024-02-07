using BudgetControl.Application.Ledgers.Commands.Create;
using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Application.Ledgers.Queries.Get;
using BudgetControl.Application.Ledgers.Queries.List;
using BudgetControl.Contracts.Ledgers.Request;
using BudgetControl.Contracts.Ledgers.Response;
using BudgetControl.Domain.LedgerAggregate;
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
  [HttpGet("{id}")]
  public async Task<IActionResult> GetLedger(string id)
  {
    ErrorOr<Ledger> ledger = await _mediator.Send(new LedgerGetQuery(id));
    return ledger.Match(
      ledger => Ok(_mapper.Map<LedgerResponse>(ledger)),
      errors => Problem(errors)
    );
  }
  [HttpPost]
  public async Task<IActionResult> CreateLedger([FromBody] LedgerCreateRequest request)
  {
    var userId = HttpContext.User.Claims.First(x => x.Type == "jti").Value;

    var command = _mapper.Map<LedgerCreateCommand>(request with { UserId = userId });
    ErrorOr<Ledger> ledger = await _mediator.Send(command);
    return ledger.Match(
      ledger => Ok(_mapper.Map<LedgerResponse>(ledger)),
      errors => Problem(errors)
    );
  }
}
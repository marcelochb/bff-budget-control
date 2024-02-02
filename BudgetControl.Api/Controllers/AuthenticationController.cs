using BudgetControl.Application.Authentication.Commands.Register;
using BudgetControl.Application.Authentication.Common;
using BudgetControl.Application.Authentication.Queries.Login;
using BudgetControl.Contracts.Authentication.Request;
using BudgetControl.Contracts.Authentication.Response;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BudgetControl.Api.Controllers;
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AuthenticationController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
          authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
          errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(
        authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
        errors => Problem(errors)
        );
    }
}
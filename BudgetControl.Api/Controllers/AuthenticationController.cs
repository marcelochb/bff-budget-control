using BudgetControl.Application.Contratcts;
using BudgetControl.Contracts.Authentication.Request;
using BudgetControl.Contracts.Authentication.Response;
using BudgetControl.Interfaces.Services;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers;
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService<AuthenticationResult> _authenticationService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService<AuthenticationResult> authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
            request.Name,
            request.Email,
            request.Password,
            request.ConfirmPassword);

        return authResult.Match(
          authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
          errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email, request.Password);
        return authResult.Match(
        authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
        errors => Problem(errors)
        );
    }
}
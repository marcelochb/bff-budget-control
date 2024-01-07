using BudgetControl.Application.Contratcts.Authentication;
using BudgetControl.Interfaces.Services.Authentication;
using ErrorOr;

namespace BudgetControl.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService<AuthenticationResult>
{
    public ErrorOr<AuthenticationResult> Login(string Email, string Password)
    {
        return new AuthenticationResult(new UserResult("Name", Email, "Status"), new ConfigResult(Guid.NewGuid()), "Test");
    }

    public ErrorOr<AuthenticationResult> Register(string Name, string Email, string Password, string ConfirmPassword)
    {
        return new AuthenticationResult(new UserResult(Name, Email, "Status"), new ConfigResult(Guid.NewGuid()), "Test");
    }
}
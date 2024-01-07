using ErrorOr;

namespace BudgetControl.Interfaces.Services.Authentication;

public interface IAuthenticationService<T>
{
    ErrorOr<T> Register(string Name,
                              string Email,
                              string Password,
                              string ConfirmPassword);
    ErrorOr<T> Login(string Email, string Password);
}

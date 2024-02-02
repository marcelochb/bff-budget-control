using BudgetControl.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
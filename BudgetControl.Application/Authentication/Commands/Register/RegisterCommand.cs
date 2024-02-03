using BudgetControl.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Commands.Register;

public record RegisterCommand(string Name,
                              string Email,
                              string Password,
                              string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;
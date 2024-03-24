using BudgetControl.Application.Authentication.Contracts;

namespace BudgetControl.Application.Authentication.Common;

public record AuthenticationResult(UserResult User, string Token);
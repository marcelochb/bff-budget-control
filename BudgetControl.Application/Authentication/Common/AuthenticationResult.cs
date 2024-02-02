using BudgetControl.Domain.UserAggregate;

namespace BudgetControl.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
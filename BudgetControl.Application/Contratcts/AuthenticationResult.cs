using BudgetControl.Domain.UserAggregate;

namespace BudgetControl.Application.Contratcts;

public record AuthenticationResult(User User, string Token);
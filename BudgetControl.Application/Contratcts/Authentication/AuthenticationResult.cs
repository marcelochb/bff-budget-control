
using BudgetControl.Domain.Entities;

public record AuthenticationResult(User User, Config Config, string Token);
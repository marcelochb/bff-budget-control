namespace BudgetControl.Application.Contratcts;
using BudgetControl.Domain.Entities;

public record AuthenticationResult(User User, string Token);
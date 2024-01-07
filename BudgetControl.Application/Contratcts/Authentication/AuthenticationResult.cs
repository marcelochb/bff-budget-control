
using BudgetControl.Application.Contratcts.Authentication;

public record AuthenticationResult(UserResult User, ConfigResult Config, string Token);
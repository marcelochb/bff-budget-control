namespace BudgetControl.Application.Authentication.Contracts;

public record UserResult(string Name, string Email, string Status, ConfigResult Config);

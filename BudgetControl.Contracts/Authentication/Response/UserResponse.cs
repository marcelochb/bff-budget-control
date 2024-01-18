namespace BudgetControl.Contracts.Authentication.Response;

public record UserResponse(string Name, string Email, string Status, UserConfigResponse Config);
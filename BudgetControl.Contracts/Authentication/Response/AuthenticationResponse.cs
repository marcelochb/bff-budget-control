namespace BudgetControl.Contracts.Authentication.Response;

public record AuthenticationResponse(UserResponse User, ConfigResponse Config, string Token);
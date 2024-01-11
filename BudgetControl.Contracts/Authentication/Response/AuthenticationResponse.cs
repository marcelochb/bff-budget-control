namespace BudgetControl.Contracts.Authentication.Response;

public record AuthenticationResponse(UserResponse User, string Token);
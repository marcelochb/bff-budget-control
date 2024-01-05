namespace BudgetControl.Contracts.Authentication.Request;
public record RegisterRequest(string Name,
                              string Email,
                              string Password,
                              string ConfirmPassword);

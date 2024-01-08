namespace BudgetControl.Domain.Entities;

public class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Status { get; set; } = null!;
    public Config Config { get; set; } = null!;
}
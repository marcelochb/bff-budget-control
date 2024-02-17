using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate.Entities;

namespace BudgetControl.Domain.UserAggregate;

public sealed class User : AggregateRoot<Guid>
{
    public string Name { get; }
    public string Email { get; }
    public string Password { get; }
    public string Status { get; }

    public UserConfig? Config { get; set; }

    private User(
        Guid userId,
        string name,
        string email,
        string password,
        string status
    ) : base(userId)
    {
        Name = name;
        Email = email;
        Password = password;
        Status = status;
    }

    public static User Create(
        string name,
        string email,
        string password,
        string status
    )
    {
        return new(Guid.NewGuid(), name, email, password, status);
    }

    public  void UpdateConfig(UserConfig config)
    {
        Config = config;
    }
}
using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate.Entities;
using BudgetControl.Domain.UserAggregate.ValueObjects;

namespace BudgetControl.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string Name { get; }
    public string Email { get; }
    public string Password { get; }
    public string Status { get; }

    public UserConfig? Config { get; set; }

    private User(
        UserId userId,
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
        return new(UserId.CreateUnique(), name, email, password, status);
    }

    public  void UpdateConfig(UserConfig config)
    {
        Config = config;
    }
}
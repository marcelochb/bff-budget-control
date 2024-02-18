using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate.Entities;

namespace BudgetControl.Domain.UserAggregate;

public sealed class User : AggregateRoot<Guid>
{
    public string Name { get; private set;}
    public string Email { get;private set; }
    public string Password { get;private set; }
    public string Status { get;private set; }

    public UserConfig? Config { get; private set; }

    private User(
        Guid Id,
        string name,
        string email,
        string password,
        string status
    ) : base(Id)
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
        string status,
        UserConfig? config = null
    )
    {
        var user = new User(
            Guid.NewGuid(),
            name,
            email,
            password,
            status
        );
        if (config is not null) user.UpdateConfig(config);
        return user;
    }
    public void Update(User? user)
    {
        if (user is not null)
        {
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Status = user.Status;
        }
    }

    public  void UpdateConfig(UserConfig config)
    {
        Config = config;
    }
}
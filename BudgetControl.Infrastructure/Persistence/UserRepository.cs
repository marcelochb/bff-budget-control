using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;

namespace BudgetControl.Infrastructure.Persistence;

public class UserRepository : IUserRepository<User>
{
    private static readonly List<User> _users = new();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }

    public void Update(User user)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        if (index > -1) _users[index] = user;
    }

    public User? Get(string id)
    {
        return _users.SingleOrDefault(u => u.Id.Value.ToString() == id);
    }
}
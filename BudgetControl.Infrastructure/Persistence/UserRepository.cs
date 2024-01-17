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
}
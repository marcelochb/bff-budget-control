using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository<User>
{
    private readonly BudgetControlDbContext _context;

    public UserRepository(BudgetControlDbContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        return user;
        // return  _context.Users.SingleOrDefault(u => u.Email == email);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public void Update(User user)
    {
        var userToUpdate = _context.Users.Find(user.Id);
        if (userToUpdate is not null)
        {
            userToUpdate.Update(user);
            _context.Update(userToUpdate);
            _context.SaveChanges();
        }
    }

    public User? Get(string id)
    {
        return _context.Users.SingleOrDefault(u => u.Id.ToString() == id);
    }
}
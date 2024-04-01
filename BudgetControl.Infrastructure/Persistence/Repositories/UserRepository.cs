using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.ValueObjects;
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
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        var userToUpdate = await _context.Users.FindAsync(user.Id);
        if (userToUpdate is not null)
        {
            userToUpdate.Update(user);
            _context.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User?> GetById(Guid id)
    {
        var user = await _context.Users
                            .FindAsync(UserId.Create(id));
        return user;
    }

    public async Task<User?> GetUserByName(string name)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Name == name);
        return user;
    }
}
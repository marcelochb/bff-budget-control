using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.ConfigAggregate.ValueObjects;
using BudgetControl.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class ConfigRepository : IConfigRepository<Config>
{
    private readonly BudgetControlDbContext _context;

    public ConfigRepository(BudgetControlDbContext context)
    {
        _context = context;
    }
    public async Task Add(Config configId)
    {
        await _context.Configs.AddAsync(configId);
        await _context.SaveChangesAsync();
    }

    public async Task<Config?> GetById(Guid id)
    {
        var config = await _context.Configs.FindAsync(ConfigId.Create(id));
        return config;
    }

    public async Task Remove(Guid id)
    {
        var config = await _context.Configs.FirstOrDefaultAsync(x => x.Id.Value == id);
        if (config is not null)
        {
            _context.Configs.Remove(config);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Config configId)
    {
        _context.Configs.Update(configId);
        await _context.SaveChangesAsync();
    }
}

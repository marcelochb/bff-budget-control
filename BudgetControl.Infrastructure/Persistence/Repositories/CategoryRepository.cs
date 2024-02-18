using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Categories;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository<LedgerCategory>
{
    private readonly BudgetControlDbContext _context;

    public CategoryRepository(BudgetControlDbContext context)
    {
        _context = context;
    }

    public async Task<LedgerCategory?> GetById(string ledgerId, string id)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        return ledger?.Categories.SingleOrDefault(c => c.Id.ToString() == id);
    }

    public async Task<bool> GetByName(string ledgerId, string name)
    {
        var ledgers = await _context.Ledgers
            .Include(c => c.Categories)
            .SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        return ledgers?.Categories.Any(c => c.Name == name) ?? false;
    }

    public async Task Add(string ledgerId, LedgerCategory category)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        ledger?.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task Update(string ledgerId, LedgerCategory category)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        var categoryToUpdate = ledger?.Categories.SingleOrDefault(c => c.Id.ToString() == category.Id.ToString());
        if (categoryToUpdate is not null)
        {
            categoryToUpdate.Update(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Remove(string ledgerId, string id)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        ledger?.Categories.Remove(ledger.Categories.Single(c => c.Id.ToString() == id));
        await _context.SaveChangesAsync();
    }

    public async Task<List<LedgerCategory>> GetList(string ledgerId)
    {
        var ledger = await _context.Ledgers
            .Include(c => c.Categories)
            .SingleOrDefaultAsync(c => c.Id.ToString() == ledgerId);
        return ledger?.Categories ?? new List<LedgerCategory>();
    }
}

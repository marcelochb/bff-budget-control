using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Categories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository<LedgerCategory>
{
    private readonly BudgetControlDbContext _context;

    public CategoryRepository(BudgetControlDbContext context)
    {
        _context = context;
    }

    public async Task<LedgerCategory?> GetById(Guid ledgerId, Guid id)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.Value == ledgerId);
        return ledger?.Categories.SingleOrDefault(c => c.Id.Value == id);
    }

    public async Task<bool> GetByName(Guid ledgerId, string name)
    {
        var ledgers = await _context.Ledgers
            .Include(c => c.Categories)
            .SingleOrDefaultAsync(c => c.Id.Value == ledgerId);
        return ledgers?.Categories.Any(c => c.Name == name) ?? false;
    }

    public async Task Add(Guid ledgerId, LedgerCategory category)
    {
        var guidSerializer = new GuidSerializer(GuidRepresentation.Standard);
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        var ledger = await _context.Ledgers.FindAsync(ledgerId);
        if (ledger is not null)
        {
            ledger.Categories.Add(category);
            _context.Update(ledger);
            await _context.SaveChangesAsync();
        }
        return;
    }

    public async Task Update(Guid ledgerId, LedgerCategory category)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.Value == ledgerId);
        var categoryToUpdate = ledger?.Categories.SingleOrDefault(c => c.Id == category.Id);
        if (categoryToUpdate is not null)
        {
            categoryToUpdate.Update(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Remove(Guid ledgerId, Guid id)
    {
        var ledger = await _context.Ledgers.SingleOrDefaultAsync(c => c.Id.Value == ledgerId);
        ledger?.Categories.Remove(ledger.Categories.Single(c => c.Id.Value == id));
        await _context.SaveChangesAsync();
    }

    public async Task<List<LedgerCategory>> GetList(Guid ledgerId)
    {
        var ledger = await _context.Ledgers
            .Include(c => c.Categories)
            .SingleOrDefaultAsync(c => c.Id.Value == ledgerId);
        return ledger?.Categories ?? new List<LedgerCategory>();
    }
}

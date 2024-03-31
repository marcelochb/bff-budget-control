using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;


namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class LedgerRepository : ILedgerRepository<Ledger>
{
    private readonly BudgetControlDbContext _context;

    public LedgerRepository(BudgetControlDbContext context)
    {
        _context = context;
    }

    public async Task Add(Ledger ledger)
    {

        await _context.AddAsync(ledger);

        await _context.SaveChangesAsync();

    }

    public async Task<Ledger?> GetById(Guid id)
    {

        var result = await _context.Ledgers
                                .Include(element => element.Categories)
                                .ThenInclude(element => element.Groups)
                                .ToListAsync();


        return result.Where(element => element.Id.Value == id).FirstOrDefault();
    }

    public async Task<bool> GetByName(string name)
    {
        var ledger = await _context.Ledgers.AnyAsync(element => element.Name == name);
        return ledger;
    }

    public async Task<List<Ledger>> GetLedgersByUserId(Guid userId)
    {
        var result = await _context.Ledgers
                        .Include(element => element.Categories)
                        .ThenInclude(element => element.Groups)
                        .ToListAsync();

        return result.Where(element => element.UserId.Value == userId).ToList();
    }

    public async Task Remove(Guid id)
    {
        var ledger = await _context.Ledgers.FindAsync(id);
        if (ledger is not null)
        {
            _context.Ledgers.Remove(ledger);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Ledger ledger)
    {
        var ledgerToUpdate = await _context.Ledgers.FindAsync(ledger.Id);
        if (ledgerToUpdate is not null)
        {
            ledgerToUpdate.Update(ledger);
            _context.Update(ledgerToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
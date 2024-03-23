using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;
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

        var result = _context.Ledgers.Find(id);


        return result;
    }

    public async Task<bool> GetByName(string name)
    {
        var ledger = await _context.Ledgers.AnyAsync(element => element.Name == name);
        return ledger;
    }

    public List<Ledger> GetLedgersByUserId(Guid userId)
    {
        return _context.Ledgers.Where(element => element.UserId.Value == userId.ToString()).ToList();
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
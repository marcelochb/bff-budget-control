using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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

    public async Task<Ledger?> GetById(string id)
    {
        // var query = Query.Equals(e.Id, id);
        // var ledgers = _context.Ledgers.
        var ledgers = await _context.Ledgers.FindAsync(Builders<Ledger>.Filter.Eq("Id", Guid.Parse(id)));
        // var ledgers = await _context.Ledgers.FirstOrDefaultAsync(element => element.Id.ToString().Split(",")[1] == id);
        // var query =  (from ledger in  _context.Ledgers.AsEnumerable()
        //             where ledger.Id.ToString() == id
        //             select ledger);
        return ledgers;
    }

    public async Task<bool> GetByName(string name)
    {
        var ledger = await _context.Ledgers.AnyAsync(element => element.Name == name);
        return ledger;
    }

    public List<Ledger> GetLedgersByUserId(string userId)
    {
        return _context.Ledgers.Where(element => element.User.Id.ToString() == userId).ToList();
    }

    public async Task Remove(string id)
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
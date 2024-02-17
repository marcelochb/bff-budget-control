using BudgetControl.Domain;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;

namespace BudgetControl.Infrastructure.Persistence.Repositories;

public class LedgerRepository : ILedgerRepository<Ledger>
{
    private readonly BudgetControlDbContext _context;

    public LedgerRepository(BudgetControlDbContext context)
    {
        _context = context;
    }

    public static List<Ledger> ledgers = new();
    public void Add(Ledger ledger)
    {
        ledgers.Add(ledger);
        var movie = Movie.Create(ledger.Name);
        _context.Add(movie);
        _context.SaveChanges();
    }

    public Ledger? GetById(string id)
    {
        return ledgers.SingleOrDefault(element => element.Id.ToString() == id);
    }

    public bool GetByName(string name)
    {
        return ledgers.Any(element => element.Name == name);
    }

    public List<Ledger> GetLedgersByUserId(string userId)
    {
        return ledgers.FindAll(x => x.User.Id.ToString() == userId);
    }

    public void Remove(string id)
    {
        ledgers.Remove(ledgers.Single(element => element.Id.ToString() == id));
    }

    public void Update(Ledger ledger)
    {
        var index = ledgers.FindIndex(element => element.Id.ToString() == ledger.Id.ToString());
        if (index > -1) ledgers[index] = ledger;
    }
}
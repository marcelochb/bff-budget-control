using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;

namespace BudgetControl.Infrastructure.Persistence;

public class LedgerRepository : ILedgerRepository<Ledger>
{
    private static List<Ledger> _ledgers = new();
    public void Add(Ledger ledger)
    {
        _ledgers.Add(ledger);
    }

    public Ledger? GetLedgerById(string id)
    {
        return _ledgers.SingleOrDefault(element => element.Id.Value.ToString() == id);
    }

    public List<Ledger> GetLedgersByUserId(string userId)
    {
        return _ledgers.FindAll(x => x.User.Id.Value.ToString() == userId);
    }

    public void Remove(string id)
    {
        _ledgers.Remove(_ledgers.Single(element => element.Id.ToString() == id));
    }

    public void Update(string id, Ledger ledger)
    {

    }
}
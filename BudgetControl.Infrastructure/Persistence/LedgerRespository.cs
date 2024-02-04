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

    public void Update(Ledger ledger)
    {
        var index = _ledgers.FindIndex(element => element.Id.ToString() == ledger.Id.ToString());
        if (index > -1) _ledgers[index] = ledger;
    }
}
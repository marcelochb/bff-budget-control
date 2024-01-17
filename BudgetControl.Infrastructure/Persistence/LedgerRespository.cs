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

    public Ledger? GetLedgerByName(string name)
    {
        return _ledgers.SingleOrDefault(elemente => elemente.Name == name);
    }

    public void Remove(string id)
    {
        _ledgers.Remove(_ledgers.Single(element => element.Id.ToString() == id));
    }

    public void Update(string id, Ledger ledger)
    {

    }
}
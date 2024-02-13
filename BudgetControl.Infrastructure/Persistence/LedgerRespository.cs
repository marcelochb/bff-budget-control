using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;

namespace BudgetControl.Infrastructure.Persistence;

public class LedgerRepository : ILedgerRepository<Ledger>
{
    public static List<Ledger> ledgers = new();
    public void Add(Ledger ledger)
    {
        ledgers.Add(ledger);
    }

    public Ledger? GetById(string id)
    {
        return ledgers.SingleOrDefault(element => element.Id.Value.ToString() == id);
    }

    public bool GetByName(string name)
    {
        return ledgers.Any(element => element.Name == name);
    }

    public List<Ledger> GetLedgersByUserId(string userId)
    {
        return ledgers.FindAll(x => x.User.Id.Value.ToString() == userId);
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
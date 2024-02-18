using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class LedgerUser : Entity<Guid>
{
    public string Name { get; private set; }

    private LedgerUser(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static LedgerUser Create(Guid id,string name)
    {
        return new LedgerUser(id, name);
    }

    public void Update(LedgerUser ledgerUser)
    {
        Name = ledgerUser.Name;
    }
}
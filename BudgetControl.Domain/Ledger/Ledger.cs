using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.Ledger.Entities;
using BudgetControl.Domain.Ledger.ValueObjects;

namespace BudgetControl.Domain.Ledger;

public sealed class Ledger : AggregateRoot<LedgerId>
{
    public string Name { get; }
    public string Type { get; }
    public string UserName { get; }
    private readonly List<LedgerCategory> _categories = new();

    public IReadOnlyList<LedgerCategory> Categories => _categories.AsReadOnly();

    private Ledger(LedgerId ledgerId, string name, string type, string userName) : base(ledgerId)
    {
        Name = name;
        Type = type;
        UserName = userName;
    }

    public static Ledger Create(string name, string type, string userName)
    {
        return new(
            LedgerId.CreateUnique(),
            name,
            type,
            userName);
    }
}
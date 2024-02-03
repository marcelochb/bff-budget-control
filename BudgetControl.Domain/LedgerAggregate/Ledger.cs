using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;

namespace BudgetControl.Domain.LedgerAggregate;

public sealed class Ledger : AggregateRoot<LedgerId>
{
    public string Name { get; }
    public string Type { get; }
    public string UserName { get; }
    private readonly List<LedgerCategory> _categories = new();

    public IReadOnlyList<LedgerCategory> Categories => _categories.AsReadOnly();

    private Ledger(LedgerId ledgerId, string name, string type, string userName, List<LedgerCategory> categories) : base(ledgerId)
    {
        Name = name;
        Type = type;
        UserName = userName;
        _categories = categories;
    }

    public static Ledger Create(string name, string type, string userName, List<LedgerCategory> categories)
    {
        return new(
            LedgerId.CreateUnique(),
            name,
            type,
            userName,
            categories);
    }
}
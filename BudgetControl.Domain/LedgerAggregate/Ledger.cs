using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate;

namespace BudgetControl.Domain.LedgerAggregate;

public sealed class Ledger : AggregateRoot<LedgerId>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public User User { get; }
    private readonly List<LedgerCategory> _categories = new();

    public IReadOnlyList<LedgerCategory> Categories => _categories.AsReadOnly();

    private Ledger(LedgerId ledgerId, string name, string type, User user, List<LedgerCategory>? categories) : base(ledgerId)
    {
        Name = name;
        Type = type;
        User = user;
        _categories = categories;
    }

    public static Ledger Create(string name, string type, User user, List<LedgerCategory>? categories = null)
    {
        return new(
            LedgerId.CreateUnique(),
            name,
            type,
            user,
            categories);
    }

    public void Update(string name, string type)
    {
        Name = name;
        Type = type;
    }
}
using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.Entities;

namespace BudgetControl.Domain.LedgerAggregate;

public sealed class Ledger : AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public LedgerUser? User { get; private set;}
    private readonly List<LedgerCategory> _categories = new();

    public List<LedgerCategory> Categories => _categories.ToList();

    private Ledger(Guid Id, string name, string type) : base(Id)
    {
        Name = name;
        Type = type;
    }

    public static Ledger Create(string name, string type, LedgerUser? user = null, List<LedgerCategory>? categories = null)
    {
        var ledger = new Ledger(Guid.NewGuid(),
                                name,
                                type);
        if (categories is not null) ledger.AddCategories(categories);
        if (user is not null) ledger.AddUser(user);
        return ledger;
    }

    public void Update(Ledger ledger)
    {
        Name = ledger.Name;
        Type = ledger.Type;
    }
    public void AddCategories(List<LedgerCategory> categories)
    {
        _categories.AddRange(categories);
    }

    public void AddCategory(LedgerCategory category)
    {
        _categories.Add(category);
    }

    public void RemoveCategory(LedgerCategory category)
    {
        _categories.Remove(category);
    }

    public void AddUser(LedgerUser user)
    {
        User = user;
    }
}
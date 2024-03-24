using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.LedgerAggregate.Events;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.ValueObjects;

namespace BudgetControl.Domain.LedgerAggregate;

public sealed class Ledger : AggregateRoot<LedgerId>
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public UserId UserId { get; private set;}
    private readonly List<LedgerCategory> _categories = new();
    // private readonly List<UserId> _usersShare = new();

    public List<LedgerCategory> Categories => _categories.ToList();
    // public List<UserId> UsersShare => _usersShare.ToList();
    private Ledger(LedgerId Id, string name, string type, UserId userId) : base(Id)
    {
        Name = name;
        Type = type;
        UserId = userId;
    }

    public static Ledger Create(string name, string type, UserId userId, List<LedgerCategory>? categories = null, bool isForNewUser = false, User? user = null)
    {
        var ledger = new Ledger(LedgerId.CreateUnique(),
                                name,
                                type,
                                userId);

        if (categories is not null) ledger.AddCategories(categories);

        if (isForNewUser && user is not null) ledger.AddDomainEvent(new LedgerDefaultForNewUser(ledger, user));

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

    #pragma warning disable CS8618
    private Ledger()
    {
    }
    #pragma warning restore CS8618
}
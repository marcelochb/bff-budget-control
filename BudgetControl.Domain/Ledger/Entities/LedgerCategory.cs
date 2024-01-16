using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.Ledger.ValueObjects;

namespace BudgetControl.Domain.Ledger.Entities;

public sealed class LedgerCategory : Entity<LedgerCategoryId>
{
    public string Name { get; }
    public float Goal { get; }
    public string Color { get; }
    private readonly List<CategoryGroup> _groups = new();

    public IReadOnlyList<CategoryGroup> Groups => _groups.AsReadOnly();
    private LedgerCategory(LedgerCategoryId ledgerCategoryId, string name, float goal, string color) : base(ledgerCategoryId)
    {
        Name = name;
        Goal = goal;
        Color = color;
    }

    public static LedgerCategory Create(string name, float goal, string color)
    {
        return new(
                LedgerCategoryId.CreateUnique(),
                name,
                goal,
                color);
    }

}
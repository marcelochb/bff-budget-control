using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class LedgerCategory : Entity<LedgerCategoryId>
{
    public string Name { get; }
    public float Goal { get; }
    public string Color { get; }
    private readonly List<CategoryGroup> _groups = new();

    public IReadOnlyList<CategoryGroup> Groups => _groups.AsReadOnly();
    private LedgerCategory(LedgerCategoryId ledgerCategoryId,
                           string name,
                           float goal,
                           string color,
                           List<CategoryGroup> groups) : base(ledgerCategoryId)
    {
        Name = name;
        Goal = goal;
        Color = color;
        _groups = groups;
    }

    public static LedgerCategory Create(string name,
                                        float goal,
                                        string color,
                                        List<CategoryGroup> groups)
    {
        return new(
                LedgerCategoryId.CreateUnique(),
                name,
                goal,
                color,
                groups);
    }

}
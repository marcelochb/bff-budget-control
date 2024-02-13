using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class LedgerCategory : Entity<LedgerCategoryId>
{
    public string Name { get; }
    public float Goal { get; }
    public string Color { get; }
    private readonly List<CategoryGroup> _groups = new();

    public List<CategoryGroup> Groups => _groups.ToList();
    private LedgerCategory(LedgerCategoryId ledgerCategoryId,
                           string name,
                           float goal,
                           string color,
                           List<CategoryGroup>? groups = null) : base(ledgerCategoryId)
    {
        Name = name;
        Goal = goal;
        Color = color;
        _groups = groups ?? new();
    }

    public static LedgerCategory Create(string name,
                                        float goal,
                                        string color,
                                        List<CategoryGroup>? groups = null)
    {
        return new(
                LedgerCategoryId.CreateUnique(),
                name,
                goal,
                color,
                groups);
    }

}
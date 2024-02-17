using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class CategoryGroup : Entity<Guid>
{
    public string Name { get; }
    public float Goal { get; }

    private CategoryGroup(Guid categoryGroupId, string name, float goal) : base(categoryGroupId)
    {
        Name = name;
        Goal = goal;
    }

    public static CategoryGroup Create(string name, float goal)
    {
        return new(Guid.NewGuid(), name, goal);
    }
}
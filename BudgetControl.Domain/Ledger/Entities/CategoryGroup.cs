using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.Ledger.ValueObjects;

namespace BudgetControl.Domain.Ledger.Entities;

public sealed class CategoryGroup : Entity<CategoryGroupId>
{
    public string Name { get; }
    public float Goal { get; }

    private CategoryGroup(CategoryGroupId categoryGroupId,string name, float goal) : base(categoryGroupId)  
    {
        Name = name;
        Goal = goal;
    }

    public static CategoryGroup Create(string name, float goal)
    {
        return new(CategoryGroupId.CreateUnique(),name, goal);
    }
}
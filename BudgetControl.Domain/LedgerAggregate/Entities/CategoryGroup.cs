using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class CategoryGroup : Entity<Guid>
{
    public string Name { get; private set; }
    public float Goal { get; private set; }

    public Guid LedgerCategoryId { get; private set; }

    private CategoryGroup(Guid id, string name, float goal, Guid ledgerCategoryId) : base(id)
    {
        Name = name;
        Goal = goal;
        LedgerCategoryId = ledgerCategoryId;
    }

    public static CategoryGroup Create(string name, float goal, Guid ledgerCategoryId)
    {
        return new(Guid.NewGuid(), name, goal, ledgerCategoryId);
    }
}
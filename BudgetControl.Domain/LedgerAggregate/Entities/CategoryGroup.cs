using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class CategoryGroup : Entity<CategoryGroupId>
{
    public string Name { get; private set; }
    public float Goal { get; private set; }

    public LedgerCategoryId LedgerCategoryId { get; private set; }
    public LedgerId LedgerId { get; private set; }

    private CategoryGroup(
        CategoryGroupId id,
        string name,
        float goal,
        LedgerCategoryId ledgerCategoryId,
        LedgerId ledgerId) : base(id)
    {
        Name = name;
        Goal = goal;
        LedgerCategoryId = ledgerCategoryId;
        LedgerId = ledgerId;
    }

    public static CategoryGroup Create(
        string name,
        float goal,
        LedgerCategoryId ledgerCategoryId,
        LedgerId ledgerId)
    {
        return new(CategoryGroupId.CreateUnique(), name, goal, ledgerCategoryId, ledgerId);
    }
}
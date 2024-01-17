using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.ValueObjects;

public sealed class CategoryGroupId : ValueObject
{
    public Guid Value { get; }

    private CategoryGroupId(Guid value)
    {
        Value = value;
    }

    public static CategoryGroupId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
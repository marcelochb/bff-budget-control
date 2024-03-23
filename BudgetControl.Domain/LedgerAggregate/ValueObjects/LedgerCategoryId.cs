using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.ValueObjects;

public sealed class LedgerCategoryId : ValueObject
{
    public Guid Value { get; }

    private LedgerCategoryId(Guid value)
    {
        Value = value;
    }

    public static LedgerCategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static LedgerCategoryId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.ValueObjects;

public sealed class LedgerId : ValueObject
{
    public Guid Value { get; }

    private LedgerId(Guid value)
    {
        Value = value;
    }

    public static LedgerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
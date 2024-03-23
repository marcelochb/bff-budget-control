using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.ValueObjects;

public sealed class LedgerId : ValueObject
{
    public Guid Value { get; private set; }

    private LedgerId(Guid value)
    {
        Value = value;
    }

    public static LedgerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static LedgerId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #pragma warning disable CS8618
    private LedgerId()
    {
    }
    #pragma warning restore CS8618
}

using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.ConfigAggregate.ValueObjects;

public sealed class ConfigId : ValueObject
{
    public Guid Value { get; }

    private ConfigId(Guid value)
    {
        Value = value;
    }

    public static ConfigId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static ConfigId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #pragma warning disable CS8618
    private ConfigId()
    {
    }
    #pragma warning restore CS8618
}

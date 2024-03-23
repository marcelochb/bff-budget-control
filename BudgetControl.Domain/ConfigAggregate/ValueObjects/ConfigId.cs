using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.ConfigAggregate.ValueObjects;

public sealed class ConfigId : ValueObject
{
    public string Value { get; }

    private ConfigId(string value)
    {
        Value = value;
    }

    public static ConfigId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }
    public static ConfigId Create(string value)
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

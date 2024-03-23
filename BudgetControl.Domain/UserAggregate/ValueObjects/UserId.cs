using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public string Value { get; }

    private UserId(string value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }
    public static UserId Create(string value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #pragma warning disable CS8618
    private UserId()
    {
    }
    #pragma warning restore CS8618
}
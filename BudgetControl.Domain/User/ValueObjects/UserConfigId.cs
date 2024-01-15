using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.User.ValueObjects;

public sealed class UserConfigId : ValueObject
{
    public Guid Value { get; }

    private UserConfigId(Guid value)
    {
        Value = value;
    }

    public static UserConfigId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
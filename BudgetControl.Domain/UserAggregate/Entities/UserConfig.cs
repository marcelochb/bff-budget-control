using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate.ValueObjects;

namespace BudgetControl.Domain.UserAggregate.Entities;

public sealed class UserConfig : Entity<UserConfigId>
{
    public Guid LedgerId { get; set;}
    private UserConfig(
        UserConfigId Id,
        LedgerId ledgerId)
        : base(Id)
    {
        LedgerId = ledgerId.Value;
    }

    public static UserConfig Create(LedgerId ledgerId)
    {
        return new(UserConfigId.CreateUnique(), ledgerId);
    }
}
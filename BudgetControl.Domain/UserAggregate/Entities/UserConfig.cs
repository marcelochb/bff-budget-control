using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate.ValueObjects;

namespace BudgetControl.Domain.UserAggregate.Entities;

public sealed class UserConfig : Entity<UserConfigId>
{
    public LedgerId LedgerId { get; }
    private UserConfig(
        UserConfigId userConfigId,
        LedgerId ledgerId)
        : base(userConfigId)
    {
        LedgerId = ledgerId;
    }

    public static UserConfig Create(LedgerId ledgerId)
    {
        return new(UserConfigId.CreateUnique(), ledgerId);
    }
}
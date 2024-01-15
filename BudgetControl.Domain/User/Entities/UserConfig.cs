using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.Ledger.ValueObjects;
using BudgetControl.Domain.User.ValueObjects;

namespace BudgetControl.Domain.User.Entities;

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
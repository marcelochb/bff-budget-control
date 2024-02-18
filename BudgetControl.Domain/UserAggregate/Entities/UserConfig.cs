using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.UserAggregate.Entities;

public sealed class UserConfig : Entity<Guid>
{
    public Guid LedgerId { get; }
    private UserConfig(
        Guid Id,
        Guid ledgerId)
        : base(Id)
    {
        LedgerId = ledgerId;
    }

    public static UserConfig Create(Guid ledgerId)
    {
        return new(Guid.NewGuid(), ledgerId);
    }
}
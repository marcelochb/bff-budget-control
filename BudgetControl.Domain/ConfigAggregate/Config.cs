using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.ConfigAggregate.ValueObjects;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;

namespace BudgetControl.Domain.ConfigAggregate;

public sealed class Config : AggregateRoot<ConfigId>
{
    public LedgerId LedgerId { get; private set; }

    private Config(ConfigId Id, LedgerId ledgerId) : base(Id)
    {
        LedgerId = ledgerId;
    }

    public static Config Create(LedgerId ledgerId)
    {
        return new(ConfigId.CreateUnique(), ledgerId);
    }

    #pragma warning disable CS8618
    private Config()
    {
    }
    #pragma warning restore CS8618
}

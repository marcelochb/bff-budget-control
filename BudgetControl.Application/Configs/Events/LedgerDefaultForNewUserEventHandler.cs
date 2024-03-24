using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.LedgerAggregate.Events;
using BudgetControl.Interfaces.Persistence;
using MediatR;

namespace BudgetControl.Application.Configs.Events;

public class LedgerDefaultForNewUserEventHandler : INotificationHandler<LedgerDefaultForNewUser>
{
    private readonly IConfigRepository<Config> _configRepository;

    public LedgerDefaultForNewUserEventHandler(IConfigRepository<Config> configRepository)
    {
        _configRepository = configRepository;
    }

    public async Task Handle(LedgerDefaultForNewUser notification, CancellationToken cancellationToken)
    {
        var config = Config.Create(notification.Ledger.Id, notification.User);
        await _configRepository.Add(config);
    }
}

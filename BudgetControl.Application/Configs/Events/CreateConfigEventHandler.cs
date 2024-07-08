using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.LedgerAggregate.Events;
using BudgetControl.Interfaces.Persistence;
using MediatR;

namespace BudgetControl.Application.Configs.Events;

public class CreateConfigEventHandler : INotificationHandler<CreateConfig>
{
    private readonly IConfigRepository<Config> _configRepository;

    public CreateConfigEventHandler(IConfigRepository<Config> configRepository)
    {
        _configRepository = configRepository;
    }

    public async Task Handle(CreateConfig notification, CancellationToken cancellationToken)
    {
        var config = Config.Create(notification.Ledger.Id, notification.User);
        await _configRepository.Add(config);
    }
}

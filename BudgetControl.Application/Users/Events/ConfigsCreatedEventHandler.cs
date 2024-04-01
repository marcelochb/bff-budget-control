using BudgetControl.Domain.ConfigAggregate.Events;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using MediatR;

namespace BudgetControl.Application.Users.Events;

public class ConfigCreatedEventHandler : INotificationHandler<ConfigCreated>
{
    private readonly IUserRepository<User> _userRepository;

    public ConfigCreatedEventHandler(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(ConfigCreated notification, CancellationToken cancellationToken)
    {
            await Task.CompletedTask;
            notification.User.UpdateConfig(notification.Config.Id);
            // await _userRepository.Update(notification.User);
    }
    
}
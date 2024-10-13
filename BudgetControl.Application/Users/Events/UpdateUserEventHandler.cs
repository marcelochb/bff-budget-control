using BudgetControl.Domain.ConfigAggregate.Events;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using MediatR;

namespace BudgetControl.Application.Users.Events;

public class UpdateUserEventHandler : INotificationHandler<UpdateUser>
{
    private readonly IUserRepository<User> _userRepository;

    public UpdateUserEventHandler(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUser notification, CancellationToken cancellationToken)
    {
            await Task.CompletedTask;
            notification.User.UpdateConfig(notification.Config.Id);
            // await _userRepository.Update(notification.User);
    }
    
}
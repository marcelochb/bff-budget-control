using BudgetControl.Application.Authentication.Common;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;
    private readonly IUserRepository<User> _userRepository;

    public RegisterCommandHandler(IUserRepository<User> userRepository, IJwtTokenGenerator<User> jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
      if (await _userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
        var user = User.Create(name: command.Name,
                               email: command.Email,
                               password: command.Password,
                               status: "Guest");

        await _userRepository.Add(user);

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);
    }
}

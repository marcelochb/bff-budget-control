using BudgetControl.Application.Authentication.Common;
using BudgetControl.Application.Authentication.Contracts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence;
using BudgetControl.Interfaces.Persistence.Authentication;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;
    private readonly IUserRepository<User> _userRepository;
    private readonly IConfigRepository<Config> _configRepository;

    public RegisterCommandHandler(IUserRepository<User> userRepository, IJwtTokenGenerator<User> jwtTokenGenerator, IConfigRepository<Config> configRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _configRepository = configRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
      if (await _userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
        if (await _userRepository.GetUserByName(command.Name) is not null)
        {
            return Errors.User.DuplicateName;
        }
        var user = User.Create(name: command.Name,
                               email: command.Email,
                               password: command.Password,
                               status: "Guest");

        await _userRepository.Add(user);

        var result = await _userRepository.GetUserByEmail(command.Email);

        var config = await _configRepository.GetById(result?.ConfigId?.Value ?? Guid.Empty);
        
        var userResult = new UserResult(
            result?.Name ?? "",
            result?.Email ?? "",
            result?.Status ?? "",
            new ConfigResult(config?.LedgerId.Value.ToString() ?? ""));

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(userResult, token);
    }
}

using BudgetControl.Application.Authentication.Common;
using BudgetControl.Application.Authentication.Contracts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence;
using BudgetControl.Interfaces.Persistence.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BudgetControl.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IConfigRepository<Config> _configRepository;
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository<User> userRepository, IJwtTokenGenerator<User> jwtTokenGenerator, IConfigRepository<Config> configRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _configRepository = configRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredential };
        }

        var config = await _configRepository.GetById(user.ConfigId?.Value ?? Guid.Empty);

        var userResult = new UserResult(
            user.Name,
            user.Email,
            user.Status,
            new ConfigResult(config?.LedgerId.Value.ToString() ?? ""));

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(userResult, token);
    }
}

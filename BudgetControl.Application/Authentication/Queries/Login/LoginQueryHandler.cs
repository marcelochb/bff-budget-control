using BudgetControl.Application.Authentication.Common;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository<User> userRepository, IJwtTokenGenerator<User> jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredential };
        }

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);
    }
}

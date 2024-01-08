using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.Entities;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Services.Authentication;
using ErrorOr;

namespace BudgetControl.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService<AuthenticationResult>
{
        private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;
    private readonly IUserRepository<User> _userRepository;

    public AuthenticationService(IJwtTokenGenerator<User> jwtTokenGenerator, IUserRepository<User> userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1 - Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        // 2 - Validate the password is correct
        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredential };
        }
        
        // 3 - Generate JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user,new Config(),token);
    }

    public ErrorOr<AuthenticationResult> Register(string name, string email, string password, string confirmPassword)
    {
        // 1 - Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // 2 - Create user (generate unique Id) & persiste to DB
        var user = new User{
            Name = name,
            Email = email,
            Password = password,
            Status = "Guest"
        };
        _userRepository.Add(user);
        // 3 - Generate JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);
      return new AuthenticationResult(user, new Config(),token);
    }
}
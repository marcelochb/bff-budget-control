using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.Entities;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledger;
using BudgetControl.Interfaces.Services.Authentication;
using ErrorOr;

namespace BudgetControl.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService<AuthenticationResult>
{
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;
    private readonly IUserRepository<User> _userRepository;
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public AuthenticationService(IJwtTokenGenerator<User> jwtTokenGenerator, IUserRepository<User> userRepository, ILedgerRepository<Ledger> ledgerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _ledgerRepository = ledgerRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredential };
        }
        
        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user,token);
    }

    public ErrorOr<AuthenticationResult> Register(string name, string email, string password, string confirmPassword)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        var ledger = new Ledger{
            Id = Guid.NewGuid(),
            Name = "Default",
            Share = false,
            SharedUsers = [],
            Type = "Expense",
            UserName = name,
            Categories = [
                new Category{
                    Color = "#0000",
                    Goal = 0,
                    Name = "Habitação",
                    Groups = [
                        new Group{Name = "Internet", Goal = 0},
                        new Group{Name = "Celular", Goal = 0},
                        new Group{Name = "Agua", Goal = 0},
                        new Group{Name = "Energia", Goal = 0},
                        new Group{Name = "TV Stream", Goal = 0},
                        new Group{Name = "Manutenção", Goal = 0},
                    ]
                },
                new Category{
                    Color = "#0000",
                    Goal = 0,
                    Name = "Transporte",
                    Groups = [
                        new Group{Name = "Combustível", Goal = 0},
                        new Group{Name = "Seguro", Goal = 0},
                        new Group{Name = "Estacionamento", Goal = 0},
                        new Group{Name = "Manutenção", Goal = 0},
                    ]
                },
                new Category{
                    Color = "#0000",
                    Goal = 0,
                    Name = "Alimentação",
                    Groups = [
                        new Group{Name = "Supermercado", Goal = 0},
                        new Group{Name = "Lanches e afins", Goal = 0},
                    ]
                },
                new Category{
                    Color = "#0000",
                    Goal = 0,
                    Name = "Saúde",
                    Groups = [
                        new Group{Name = "Famácia", Goal = 0},
                        new Group{Name = "Convênio", Goal = 0},
                        new Group{Name = "Consultas e Exames", Goal = 0},
                    ]
                },
                new Category{
                    Color = "#0000",
                    Goal = 0,
                    Name = "Lazer",
                    Groups = [
                        new Group{Name = "Hospedagem", Goal = 0},
                        new Group{Name = "Passagem aérea", Goal = 0},
                        new Group{Name = "Passeios e afins", Goal = 0},
                    ]
                },
            ]
        };
        _ledgerRepository.Add(ledger);        
        var user = new User{
            Name = name,
            Email = email,
            Password = password,
            Status = "Guest"
        };
     
        var config = new Config{LedgerId = ledger.Id};
        user.Config = config;
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user,token);
    }
}
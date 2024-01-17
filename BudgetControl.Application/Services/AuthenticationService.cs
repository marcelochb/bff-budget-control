using BudgetControl.Application.Contratcts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using BudgetControl.Interfaces.Services;
using ErrorOr;

namespace BudgetControl.Application.Services;

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
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Register(string name, string email, string password, string confirmPassword)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        var ledger = Ledger.Create(name: "Default",
                                   type: "Expense",
                                   userName: name,
                                   categories: new List<LedgerCategory>
                                   {
                                        LedgerCategory.Create(name: "Habitação",
                                                            goal: 0,
                                                            color: "#0000",
                                                            groups: new List<CategoryGroup>
                                                            {
                                                                CategoryGroup.Create(name: "Internet", goal: 0),
                                                                CategoryGroup.Create(name: "Celular", goal: 0),
                                                                CategoryGroup.Create(name: "Agua", goal: 0),
                                                                CategoryGroup.Create(name: "Energia", goal: 0),
                                                                CategoryGroup.Create(name: "TV Stream", goal: 0),
                                                                CategoryGroup.Create(name: "Manutenção", goal: 0)
                                                            }),
                                        LedgerCategory.Create(name: "Transporte",
                                                            goal: 0,
                                                            color: "#0000",
                                                            groups: new List<CategoryGroup>
                                                            {
                                                                CategoryGroup.Create(name: "Combustível", goal: 0),
                                                                CategoryGroup.Create(name: "Seguro", goal: 0),
                                                                CategoryGroup.Create(name: "Estacionamento", goal: 0),
                                                                CategoryGroup.Create(name: "Manutenção", goal: 0)
                                                            }),
                                        LedgerCategory.Create(name: "Alimentação",
                                                            goal: 0,
                                                            color: "#0000",
                                                            groups: new List<CategoryGroup>
                                                            {
                                                                CategoryGroup.Create(name: "Supermercado", goal: 0),
                                                                CategoryGroup.Create(name: "Lanches e afins", goal: 0)
                                                            }),
                                        LedgerCategory.Create(name: "Saúde",
                                                            goal: 0,
                                                            color: "#0000",
                                                            groups: new List<CategoryGroup>
                                                            {
                                                                CategoryGroup.Create(name: "Famácia", goal: 0),
                                                                CategoryGroup.Create(name: "Convênio", goal: 0),
                                                                CategoryGroup.Create(name: "Consultas e Exames", goal: 0)
                                                            }),
                                        LedgerCategory.Create(name: "Lazer",
                                                            goal: 0,
                                                            color: "#0000",
                                                            groups: new List<CategoryGroup>
                                                            {
                                                                CategoryGroup.Create(name: "Hospedagem", goal: 0),
                                                                CategoryGroup.Create(name: "Passagem aérea", goal: 0),
                                                                CategoryGroup.Create(name: "Passeios e afins", goal: 0)
                                                            }) 
                                   });
        var user = User.Create(name: name,
                               email: email,
                               password: password,
                               status: "Guest",
                               config: UserConfig.Create(ledger.Id));
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);
    }
}
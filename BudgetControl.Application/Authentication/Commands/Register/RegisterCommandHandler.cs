using BudgetControl.Application.Authentication.Common;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator<User> _jwtTokenGenerator;
    private readonly IUserRepository<User> _userRepository;
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public RegisterCommandHandler(IUserRepository<User> userRepository, IJwtTokenGenerator<User> jwtTokenGenerator, ILedgerRepository<Ledger> ledgerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _ledgerRepository = ledgerRepository;
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
        // var ledger = Ledger.Create(name: "Default",
        //                            type: "Expense",
        //                            user: LedgerUser.Create(user.Id, user.Name),
        //                            categories: new List<LedgerCategory>
        //                            {
        //                                 LedgerCategory.Create(name: "Habitação",
        //                                                     goal: 0,
        //                                                     color: "#0000",
        //                                                     groups: new List<CategoryGroup>
        //                                                     {
        //                                                         CategoryGroup.Create(name: "Internet", goal: 0),
        //                                                         CategoryGroup.Create(name: "Celular", goal: 0),
        //                                                         CategoryGroup.Create(name: "Agua", goal: 0),
        //                                                         CategoryGroup.Create(name: "Energia", goal: 0),
        //                                                         CategoryGroup.Create(name: "TV Stream", goal: 0),
        //                                                         CategoryGroup.Create(name: "Manutenção", goal: 0)
        //                                                     }),
        //                                 LedgerCategory.Create(name: "Transporte",
        //                                                     goal: 0,
        //                                                     color: "#0000",
        //                                                     groups: new List<CategoryGroup>
        //                                                     {
        //                                                         CategoryGroup.Create(name: "Combustível", goal: 0),
        //                                                         CategoryGroup.Create(name: "Seguro", goal: 0),
        //                                                         CategoryGroup.Create(name: "Estacionamento", goal: 0),
        //                                                         CategoryGroup.Create(name: "Manutenção", goal: 0)
        //                                                     }),
        //                                 LedgerCategory.Create(name: "Alimentação",
        //                                                     goal: 0,
        //                                                     color: "#0000",
        //                                                     groups: new List<CategoryGroup>
        //                                                     {
        //                                                         CategoryGroup.Create(name: "Supermercado", goal: 0),
        //                                                         CategoryGroup.Create(name: "Lanches e afins", goal: 0)
        //                                                     }),
        //                                 LedgerCategory.Create(name: "Saúde",
        //                                                     goal: 0,
        //                                                     color: "#0000",
        //                                                     groups: new List<CategoryGroup>
        //                                                     {
        //                                                         CategoryGroup.Create(name: "Famácia", goal: 0),
        //                                                         CategoryGroup.Create(name: "Convênio", goal: 0),
        //                                                         CategoryGroup.Create(name: "Consultas e Exames", goal: 0)
        //                                                     }),
        //                                 LedgerCategory.Create(name: "Lazer",
        //                                                     goal: 0,
        //                                                     color: "#0000",
        //                                                     groups: new List<CategoryGroup>
        //                                                     {
        //                                                         CategoryGroup.Create(name: "Hospedagem", goal: 0),
        //                                                         CategoryGroup.Create(name: "Passagem aérea", goal: 0),
        //                                                         CategoryGroup.Create(name: "Passeios e afins", goal: 0)
        //                                                     })
        //                            });
        // user.UpdateConfig(UserConfig.Create(ledger.Id));
        await _userRepository.Add(user);
        // await _ledgerRepository.Add(ledger);

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);
    }
}

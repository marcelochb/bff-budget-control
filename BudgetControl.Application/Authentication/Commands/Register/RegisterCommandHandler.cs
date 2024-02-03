using BudgetControl.Application.Authentication.Common;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Entities;
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
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
      if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
        var ledger = Ledger.Create(name: "Default",
                                   type: "Expense",
                                   userName: command.Name,
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
        var user = User.Create(name: command.Name,
                               email: command.Email,
                               password: command.Password,
                               status: "Guest",
                               config: UserConfig.Create(ledger.Id));
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);
    }
}

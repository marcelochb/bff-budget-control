using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate.Events;
using BudgetControl.Interfaces.Persistence.Ledgers;
using MediatR;

namespace BudgetControl.Application.Ledgers.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public UserCreatedEventHandler(ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
       var ledger = Ledger.Create(name: "Default",
                                   type: "Expense",
                                   user: LedgerUser.Create(notification.User.Id, notification.User.Name),
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
        await _ledgerRepository.Add(ledger);
        // TODO: Update UserConfig of User with ledger.Id
    }
}
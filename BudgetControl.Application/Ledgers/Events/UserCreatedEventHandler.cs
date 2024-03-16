using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Entities;
using BudgetControl.Domain.UserAggregate.Events;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using MediatR;

namespace BudgetControl.Application.Ledgers.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreated>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    private readonly IUserRepository<User> _userRepository;

    public UserCreatedEventHandler(ILedgerRepository<Ledger> ledgerRepository, IUserRepository<User> userRepository)
    {
        _ledgerRepository = ledgerRepository;
        _userRepository = userRepository;
    }

    public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
       var ledger = Ledger.Create(name: "Default",
                                   type: "Expense",
                                   user: notification.User);        
        
        var habitatCategory = LedgerCategory.Create(name: "Habitação",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        habitatCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Internet", goal: 0,ledgerCategoryId: habitatCategory.Id),
                                    CategoryGroup.Create(name: "Celular", goal: 0,ledgerCategoryId: habitatCategory.Id),
                                    CategoryGroup.Create(name: "Agua", goal: 0,ledgerCategoryId: habitatCategory.Id),
                                    CategoryGroup.Create(name: "Energia", goal: 0,ledgerCategoryId: habitatCategory.Id),
                                    CategoryGroup.Create(name: "TV Stream", goal: 0,ledgerCategoryId: habitatCategory.Id),
                                    CategoryGroup.Create(name: "Manutenção", goal: 0,ledgerCategoryId: habitatCategory.Id)
                                });
        var transportCategory = LedgerCategory.Create(name: "Transporte",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        transportCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Combustível", goal: 0,ledgerCategoryId: transportCategory.Id),
                                    CategoryGroup.Create(name: "Seguro", goal: 0,ledgerCategoryId: transportCategory.Id),
                                    CategoryGroup.Create(name: "Estacionamento", goal: 0,ledgerCategoryId: transportCategory.Id),
                                    CategoryGroup.Create(name: "Manutenção", goal: 0,ledgerCategoryId: transportCategory.Id)
                                });
        var foodCategory = LedgerCategory.Create(name: "Alimentação",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        foodCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Supermercado", goal: 0,ledgerCategoryId: foodCategory.Id),
                                    CategoryGroup.Create(name: "Lanches e afins", goal: 0,ledgerCategoryId: foodCategory.Id)
                                });
        var healthCategory = LedgerCategory.Create(name: "Saúde",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        healthCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Famácia", goal: 0,ledgerCategoryId: healthCategory.Id),
                                    CategoryGroup.Create(name: "Convênio", goal: 0,ledgerCategoryId: healthCategory.Id),
                                    CategoryGroup.Create(name: "Consultas e Exames", goal: 0,ledgerCategoryId: healthCategory.Id)
                                });
        var leisureCategory = LedgerCategory.Create(name: "Lazer",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        leisureCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Hospedagem", goal: 0,ledgerCategoryId: leisureCategory.Id),
                                    CategoryGroup.Create(name: "Passagem aérea", goal: 0,ledgerCategoryId: leisureCategory.Id),
                                    CategoryGroup.Create(name: "Passeios e afins", goal: 0,ledgerCategoryId: leisureCategory.Id)
                                });
        ledger.AddCategories(new List<LedgerCategory> { habitatCategory, transportCategory, foodCategory, healthCategory, leisureCategory });
        await _ledgerRepository.Add(ledger);
        notification.User.UpdateConfig(UserConfig.Create(ledger.Id));
        await _userRepository.Update(notification.User);
    }
}
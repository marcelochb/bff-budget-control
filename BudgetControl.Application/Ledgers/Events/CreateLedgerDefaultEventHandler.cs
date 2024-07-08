using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Events;
using BudgetControl.Interfaces.Persistence;
using BudgetControl.Interfaces.Persistence.Authentication;
using MediatR;

namespace BudgetControl.Application.Ledgers.Events;

public class CreateLedgerDefaultEventHandler : INotificationHandler<CreateLedgerDefault>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public CreateLedgerDefaultEventHandler(ILedgerRepository<Ledger> ledgerRepository, IUserRepository<User> userRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task Handle(CreateLedgerDefault notification, CancellationToken cancellationToken)
    {
       var ledger = Ledger.Create(name: "Default",
                                   type: "Expense",
                                   userId: notification.User.Id,
                                   isForNewUser: true,
                                   user: notification.User);        
        
        var habitatCategory = LedgerCategory.Create(name: "Habitação",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        habitatCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Internet", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Celular", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId : ledger.Id),
                                    CategoryGroup.Create(name: "Agua", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Energia", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId : ledger.Id),
                                    CategoryGroup.Create(name: "TV Stream", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Manutenção", goal: 0,ledgerCategoryId: habitatCategory.Id, ledgerId: ledger.Id),
                                });
        var transportCategory = LedgerCategory.Create(name: "Transporte",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        transportCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Combustível", goal: 0,ledgerCategoryId: transportCategory.Id,ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Seguro", goal: 0,ledgerCategoryId: transportCategory.Id,ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Estacionamento", goal: 0,ledgerCategoryId: transportCategory.Id,ledgerId: ledger.Id),
                                    CategoryGroup.Create(name: "Manutenção", goal: 0,ledgerCategoryId: transportCategory.Id,ledgerId: ledger.Id)
                                });
        var foodCategory = LedgerCategory.Create(name: "Alimentação",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        foodCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Supermercado", goal: 0,ledgerCategoryId: foodCategory.Id,ledgerId:ledger.Id),
                                    CategoryGroup.Create(name: "Lanches e afins", goal: 0,ledgerCategoryId: foodCategory.Id,ledgerId:ledger.Id)
                                });
        var healthCategory = LedgerCategory.Create(name: "Saúde",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        healthCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Famácia", goal: 0,ledgerCategoryId: healthCategory.Id,ledgerId:ledger.Id),
                                    CategoryGroup.Create(name: "Convênio", goal: 0,ledgerCategoryId: healthCategory.Id,ledgerId:ledger.Id),
                                    CategoryGroup.Create(name: "Consultas e Exames", goal: 0,ledgerCategoryId: healthCategory.Id,ledgerId:ledger.Id)
                                });
        var leisureCategory = LedgerCategory.Create(name: "Lazer",
                                                    goal: 0,
                                                    color: "0000",
                                                    ledgerId: ledger.Id);
        leisureCategory.AddGroups(new List<CategoryGroup>
                                {
                                    CategoryGroup.Create(name: "Hospedagem", goal: 0,ledgerCategoryId: leisureCategory.Id,ledgerId:ledger.Id),
                                    CategoryGroup.Create(name: "Passagem aérea", goal: 0,ledgerCategoryId: leisureCategory.Id,ledgerId:ledger.Id),
                                    CategoryGroup.Create(name: "Passeios e afins", goal: 0,ledgerCategoryId: leisureCategory.Id,ledgerId:ledger.Id)
                                });
        ledger.AddCategories(new List<LedgerCategory> { habitatCategory, transportCategory, foodCategory, healthCategory, leisureCategory });
        await _ledgerRepository.Add(ledger);
    }
}
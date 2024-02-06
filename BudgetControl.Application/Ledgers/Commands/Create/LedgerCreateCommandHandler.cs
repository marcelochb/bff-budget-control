using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public class LedgerCreateCommandHandler : IRequestHandler<LedgerCreateCommand, ErrorOr<Ledger>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    private readonly IUserRepository<User> _userRepository;

    public LedgerCreateCommandHandler(ILedgerRepository<Ledger> ledgerRepository, IUserRepository<User> userRepository)
    {
        _ledgerRepository = ledgerRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Ledger>> Handle(LedgerCreateCommand command, CancellationToken cancellationToken)
    {
        var user = _userRepository.Get(command.UserId);
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var ledger = Ledger.Create(name: command.Name,
                                   type: command.Type,
                                   user: user,
                                   categories: CreateCategories(command.Categories));
        _ledgerRepository.Add(ledger);
        return ledger;
    }

    private List<LedgerCategory> CreateCategories(List<LedgerCategoryCreateCommand> categories)
    {
        var _categories = new List<LedgerCategory>();
        foreach (var category in categories)
        {
            var groups = new List<CategoryGroup>();
            foreach (var group in category.Groups)
            {
                groups.Add(CategoryGroup.Create(group.Name, group.Goal));
            }
            _categories.Add(LedgerCategory.Create(category.Name, category.Goal, category.Color, groups));
        }

        return _categories;
    }
}
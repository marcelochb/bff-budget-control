using BudgetControl.Application.Categories.Contracts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Categories;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Categories.Commands;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, ErrorOr<CategoryResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public CategoryCreateCommandHandler(ICategoryRepository<LedgerCategory> categoryRepository, ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ErrorOr<CategoryResult>> Handle(CategoryCreateCommand command, CancellationToken cancellationToken)
    {
        var ledger = await _ledgerRepository.GetById(command.LedgerId);
        if (ledger is null)
        {
            return Errors.Ledger.NotFound;
        }
        var category = LedgerCategory.Create(command.Name, command.Goal, command.Color, ledger.Id);
        ledger.AddCategory(category);
        await _ledgerRepository.Update(ledger);
        return new CategoryResult(category.Name, category.Goal, category.Color);
    }
}

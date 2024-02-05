using BudgetControl.Domain.LedgerAggregate.Entities;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Create.Validators;

public class CategoryGroupCreateCommandValidator : AbstractValidator<CategoryGroup>
{
    public CategoryGroupCreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Goal).NotEmpty();
    }
}
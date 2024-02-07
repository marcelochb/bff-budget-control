using BudgetControl.Domain.LedgerAggregate.Entities;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Common.Validators;

public class CategoryGroupCreateUpdateCommandValidator : AbstractValidator<CategoryGroupCreateUpdateCommand>
{
    public CategoryGroupCreateUpdateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Goal).NotEmpty();
    }
}
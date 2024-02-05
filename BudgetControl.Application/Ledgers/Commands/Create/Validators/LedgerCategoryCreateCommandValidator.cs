using BudgetControl.Domain.LedgerAggregate.Entities;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Create.Validators;

public class LedgerCategoryCreateCommandValidator : AbstractValidator<LedgerCategory>
{
    public LedgerCategoryCreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Goal).NotEmpty();
        RuleFor(x => x.Color).NotEmpty();
        RuleForEach(x => x.Groups).SetValidator(new CategoryGroupCreateCommandValidator());
        RuleFor(x => x.Groups).NotEmpty();
    }
}
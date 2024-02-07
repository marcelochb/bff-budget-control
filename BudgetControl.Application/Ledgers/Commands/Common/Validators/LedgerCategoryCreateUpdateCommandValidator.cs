using BudgetControl.Domain.LedgerAggregate.Entities;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Common.Validators;

public class LedgerCategoryCreateUpdateCommandValidator : AbstractValidator<LedgerCategoryCreateUpdateCommand>
{
    public LedgerCategoryCreateUpdateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Goal).NotEmpty();
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.Groups).NotEmpty();
        RuleForEach(x => x.Groups).SetValidator(new CategoryGroupCreateUpdateCommandValidator());
    }
}
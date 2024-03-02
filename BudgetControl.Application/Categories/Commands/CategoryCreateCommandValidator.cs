using BudgetControl.Application.Categories.Commands;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Common.Validators;

public class LedgerCategoryCreateUpdateCommandValidator : AbstractValidator<CategoryCreateCommand>
{
    public LedgerCategoryCreateUpdateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Goal).NotEmpty();
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.LedgerId).NotEmpty();
    }
}
using BudgetControl.Application.Ledgers.Commands.Common.Validators;
using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Create;
public class LedgerCreateCommandValidator : AbstractValidator<LedgerCreateCommand>
{
    public LedgerCreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
    }
}

using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Create.Validators;

public class LedgerCreateCommandValidator : AbstractValidator<LedgerCreateCommand>
{
    public LedgerCreateCommandValidator()
    {
        RuleFor(x => x.Ledger.Name).NotEmpty();
        RuleFor(x => x.Ledger.Type).NotEmpty();
        RuleFor(x => x.Ledger.Categories).NotEmpty();
        RuleForEach(x => x.Ledger.Categories).SetValidator(new LedgerCategoryCreateCommandValidator());
        RuleFor(x => x.UserId).NotEmpty();
    }
}

using FluentValidation;

namespace BudgetControl.Application.Ledgers.Commands.Update;

public class LedgerUpdateCommandValidator : AbstractValidator<LedgerUpdateCommand>
{
    public LedgerUpdateCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
    }
}

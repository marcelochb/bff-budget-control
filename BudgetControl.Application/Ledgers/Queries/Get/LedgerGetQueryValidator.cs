using FluentValidation;

namespace BudgetControl.Application.Ledgers.Queries.Get;
    public class LedgerGetQueryValidator : AbstractValidator<LedgerGetQuery>
    {
        public LedgerGetQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

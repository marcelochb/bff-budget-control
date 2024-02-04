using FluentValidation;

namespace BudgetControl.Application.Ledgers.Queries.List;

public class LedgerListQueryValidator : AbstractValidator<LedgerListQuery>
{
  public LedgerListQueryValidator()
  {
    RuleFor(v => v.UserId).NotEmpty();
  }
}
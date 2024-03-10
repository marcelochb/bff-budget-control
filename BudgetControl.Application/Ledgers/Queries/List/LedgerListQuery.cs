using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.List;

public record LedgerListQuery(Guid UserId) : IRequest<ErrorOr<LedgerListResult>>;
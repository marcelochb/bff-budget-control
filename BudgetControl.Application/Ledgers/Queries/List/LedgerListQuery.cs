using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.List;

public record LedgerListQuery(string UserId) : IRequest<ErrorOr<LedgerListResult>>;
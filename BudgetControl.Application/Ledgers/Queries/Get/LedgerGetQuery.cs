using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.Get;

public record LedgerGetQuery(Guid Id) : IRequest<ErrorOr<LedgerResult>>;

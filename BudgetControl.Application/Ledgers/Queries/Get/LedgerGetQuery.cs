using BudgetControl.Domain.LedgerAggregate;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.Get;

public record LedgerGetQuery(string Id) : IRequest<ErrorOr<Ledger>>;

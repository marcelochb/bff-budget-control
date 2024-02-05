using BudgetControl.Domain.LedgerAggregate;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public record LedgerCreateCommand(string UserId, Ledger Ledger) : IRequest<ErrorOr<Ledger>>;
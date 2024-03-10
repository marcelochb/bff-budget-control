using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Update;

public record LedgerUpdateCommand(Guid Id,
                                  string Name,
                                  string Type,
                                  Guid UserId) : IRequest<ErrorOr<LedgerUpdateResult>>;
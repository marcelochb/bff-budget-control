using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Update;

public record LedgerUpdateCommand(string Id,
                                  string Name,
                                  string Type,
                                  string UserId) : IRequest<ErrorOr<LedgerUpdateResult>>;
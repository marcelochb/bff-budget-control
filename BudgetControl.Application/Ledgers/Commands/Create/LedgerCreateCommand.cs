using BudgetControl.Application.Ledgers.Contratcts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public record LedgerCreateCommand(string Name,
                                  string Type,
                                  string UserId
                                  ) : IRequest<ErrorOr<LedgerResult>>;
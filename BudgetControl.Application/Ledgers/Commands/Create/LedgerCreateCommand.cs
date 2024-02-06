using BudgetControl.Domain.LedgerAggregate;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public record LedgerCreateCommand(string Name,
                                  string Type,
                                  List<LedgerCategoryCreateCommand> Categories,
                                  string UserId
                                  ) : IRequest<ErrorOr<Ledger>>;
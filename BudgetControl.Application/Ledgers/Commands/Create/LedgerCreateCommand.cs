using BudgetControl.Application.Ledgers.Commands.Common;
using BudgetControl.Domain.LedgerAggregate;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public record LedgerCreateCommand(string Name,
                                  string Type,
                                  List<LedgerCategoryCreateUpdateCommand> Categories,
                                  string UserId
                                  ) : IRequest<ErrorOr<Ledger>>;
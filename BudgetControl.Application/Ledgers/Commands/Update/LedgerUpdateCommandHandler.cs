using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Update;

public class LedgerUpdateCommandHandler : IRequestHandler<LedgerUpdateCommand, ErrorOr<LedgerUpdateResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public LedgerUpdateCommandHandler(ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ErrorOr<LedgerUpdateResult>> Handle(LedgerUpdateCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var ledger = await _ledgerRepository.GetById(command.Id);
        if (ledger is null)
        {
            return Errors.Ledger.NotFound;
        }
        var ledgerToUpdate = Ledger.Create(command.Name, command.Type);
        ledger.Update(ledgerToUpdate);
        await _ledgerRepository.Update(ledger);

        return new LedgerUpdateResult(ledger.Name, ledger.Type);
    }
}

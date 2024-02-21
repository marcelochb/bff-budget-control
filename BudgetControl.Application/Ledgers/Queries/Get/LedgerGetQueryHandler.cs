using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.Get;

public class LedgerGetQueryHandler : IRequestHandler<LedgerGetQuery, ErrorOr<LedgerResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    public LedgerGetQueryHandler(ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ErrorOr<LedgerResult>> Handle(LedgerGetQuery query, CancellationToken cancellationToken)
    {
        var ledger = await _ledgerRepository.GetById(query.Id);
        if (ledger is null)
        {
            return Errors.Ledger.NotFound;
        }
        return new LedgerResult(ledger.Name, ledger.Type);
    }
}


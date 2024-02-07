using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.Get;

public class LedgerGetQueryHandler : IRequestHandler<LedgerGetQuery, ErrorOr<Ledger>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    public LedgerGetQueryHandler(ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ErrorOr<Ledger>> Handle(LedgerGetQuery query, CancellationToken cancellationToken)
    {
        var ledger = _ledgerRepository.GetById(query.Id);
        return ledger;
    }
}


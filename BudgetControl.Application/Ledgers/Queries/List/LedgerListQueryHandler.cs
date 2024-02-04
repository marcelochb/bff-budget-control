using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.List;

public class LedgerListQueryHandler : IRequestHandler<LedgerListQuery, ErrorOr<LedgerListResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;

    public LedgerListQueryHandler(ILedgerRepository<Ledger> ledgerRepository)
    {
        _ledgerRepository = ledgerRepository;
    }

    public async Task<ErrorOr<LedgerListResult>> Handle(LedgerListQuery query, CancellationToken cancellationToken)
    {
      var ledgers = _ledgerRepository.GetLedgersByUserId(query.UserId);
      return new LedgerListResult(ledgers);
    }
}

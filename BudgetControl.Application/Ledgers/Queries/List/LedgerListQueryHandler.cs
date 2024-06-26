using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BudgetControl.Application.Ledgers.Queries.List;

public class LedgerListQueryHandler : IRequestHandler<LedgerListQuery, ErrorOr<LedgerListResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    private readonly IMapper _mapper;

    public LedgerListQueryHandler(ILedgerRepository<Ledger> ledgerRepository, IMapper mapper)
    {
        _ledgerRepository = ledgerRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<LedgerListResult>> Handle(LedgerListQuery query, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
      var ledgers = await _ledgerRepository.GetLedgersByUserId(query.UserId);

      return new LedgerListResult(_mapper.Map<List<LedgerResult>>(ledgers));
    }
}

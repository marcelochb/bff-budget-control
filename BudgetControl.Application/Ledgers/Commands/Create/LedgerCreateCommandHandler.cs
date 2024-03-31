using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BudgetControl.Domain.UserAggregate.ValueObjects;
using MapsterMapper;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public class LedgerCreateCommandHandler : IRequestHandler<LedgerCreateCommand, ErrorOr<LedgerResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    private readonly IUserRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public LedgerCreateCommandHandler(ILedgerRepository<Ledger> ledgerRepository, IUserRepository<User> userRepository, IMapper mapper)
    {
        _ledgerRepository = ledgerRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<LedgerResult>> Handle(LedgerCreateCommand command, CancellationToken cancellationToken)
    {
        if (await _ledgerRepository.GetByName(command.Name))
        {
            return Errors.Ledger.DuplicateName;
        }

        var user = await _userRepository.GetById(Guid.Parse(command.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        } 
        var ledger = Ledger.Create(name: command.Name,
                                   type: command.Type,
                                   userId:user.Id );
        await _ledgerRepository.Add(ledger);
        return _mapper.Map<LedgerResult>(ledger);

    }
}
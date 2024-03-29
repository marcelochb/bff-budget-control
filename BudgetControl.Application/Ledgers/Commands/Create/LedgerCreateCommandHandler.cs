using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.Common.Errors;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Ledgers.Commands.Create;

public class LedgerCreateCommandHandler : IRequestHandler<LedgerCreateCommand, ErrorOr<LedgerResult>>
{
    private readonly ILedgerRepository<Ledger> _ledgerRepository;
    private readonly IUserRepository<User> _userRepository;

    public LedgerCreateCommandHandler(ILedgerRepository<Ledger> ledgerRepository, IUserRepository<User> userRepository)
    {
        _ledgerRepository = ledgerRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<LedgerResult>> Handle(LedgerCreateCommand command, CancellationToken cancellationToken)
    {
        if (await _ledgerRepository.GetByName(command.Name))
        {
            return Errors.Ledger.DuplicateName;
        }

        var user = _userRepository.Get(command.UserId);
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var ledger = Ledger.Create(name: command.Name,
                                   type: command.Type,
                                   user: LedgerUser.Create(user.Id, user.Name));
        await _ledgerRepository.Add(ledger);
        return new LedgerResult(ledger.Name, ledger.Type);
    }
}
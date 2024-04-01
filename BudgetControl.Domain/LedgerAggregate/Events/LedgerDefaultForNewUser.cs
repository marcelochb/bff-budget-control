using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate;

namespace BudgetControl.Domain.LedgerAggregate.Events;

public record LedgerDefaultForNewUser(Ledger Ledger, User User) : IDomainEvent;
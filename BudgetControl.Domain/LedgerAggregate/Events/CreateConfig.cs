using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.UserAggregate;

namespace BudgetControl.Domain.LedgerAggregate.Events;

public record CreateConfig(Ledger Ledger, User User) : IDomainEvent;